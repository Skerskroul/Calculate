namespace Calculate
{
    /// <summary>
    /// Model - бизнес логика
    /// Business layer
    /// </summary>
    class Model
    {
        private Number firstArgument;
        private string operation;
        private Number secondArgument;
        private Buffer buffer;

        public Model()
        {
            firstArgument = new Number();
            secondArgument = new Number();
            buffer = new Buffer();

            firstArgument.Clear();
            secondArgument.Clear();
            buffer.MemoryClear();
            operation = "";
        }

        public string TakeArgument(string symbol)
        {
            bool work = false;

            if (!work)
                work = ParseNumber(symbol);
            if (!work)
                work = CleanOperation(symbol);
            if(!work)
                work = MemoryOperation(symbol);
            if (!work)
                work = ParseOperation(symbol);
            

            return CreateResult();
        }

        private bool ParseNumber(string symbol)
        {
            if (operation == "" && firstArgument.AddSymbol(symbol))
                return true;
            else if (operation != "" && secondArgument.AddSymbol(symbol))
                return true;
            return false;
        }

        private bool ParseOperation(string symbol)
        {
            if (UnaryCalculate(symbol))//+/-, kor, 1/x
                return true;
            else if (UnaryCalculateWithTwoArgument(symbol))//%
                return true;
            else if (BinaryOperation(symbol))
                return true;
            return false;
        }

        private string CreateResult()
        {
            string result;
            result = firstArgument.ToString();
            if (operation != "")
                result += " " + operation;
            if( secondArgument.ToString() != "")
                result += " " + secondArgument.ToString();

            return result;
        }

        private bool BinaryCalculate()
        {
            ListBinaryOperation listBinaryOperation = new ListBinaryOperation();
            ICalcBinary calcBinary = null;
            double first, second;

            double.TryParse(firstArgument.ToString(), out first);
            double.TryParse(secondArgument.ToString(), out second);

            if (listBinaryOperation.CheckOperation(operation, out calcBinary))
            {
                firstArgument.SetNumber(calcBinary.Calc(first, second).ToString());
                secondArgument.Clear();
                operation = "";
                return true;
            }
            return false;
        }

        private bool UnaryCalculate(string symbol)
        {
            ListUnaryOperation listUnaryOperation = new ListUnaryOperation();
            ICalcUnary calcUnary = null;
            double first;

            if (listUnaryOperation.CheckOperation(symbol, out calcUnary))
            {
                Number temp = WhatOperand();

                double.TryParse(temp.ToString(), out first);

                temp.SetNumber(calcUnary.Calc(first).ToString());

                return true;
            }
            return false;
        }

        private bool UnaryCalculateWithTwoArgument(string symbol)
        {
            ListUnaryOperationWithTwoArgument listUnaryOperationWithTwoArgument = new ListUnaryOperationWithTwoArgument();
            ICalcUnaryWithTwoArgument calcUnaryWithTwoArgument = null;
            double first, second;

            double.TryParse(firstArgument.ToString(), out first);
            double.TryParse(secondArgument.ToString(), out second);

            if(listUnaryOperationWithTwoArgument.CheckOperation(symbol, out calcUnaryWithTwoArgument))
            {
                Number temp = WhatOperand();

                temp.SetNumber(calcUnaryWithTwoArgument.Calc(first, second).ToString());

                return true;
            }
            return false;
        }

        private bool BinaryOperation(string symbol)
        {
            bool result = false;

            if (symbol == "=")//total
                result = BinaryCalculate();
            else if ((symbol != "=" && operation == "") || (symbol != "=" && operation != "" && secondArgument.ToString() == ""))//
                operation = symbol;
            else if (symbol != "=" && operation != "" && secondArgument.ToString() != "")//
            {
                result = BinaryCalculate();
                operation = symbol;
            }
            return result;
        }

        private Number WhatOperand()
        {
            if (secondArgument.ToString() != "")
                return secondArgument;
            else
                return firstArgument;
        }

        public bool CleanOperation(string symbol)//CE, C, back
        {
            if(symbol == "C")
            {
                ClearAll();
                return true;
            }
            else if(symbol == "CE")
            {
                WhatOperand().Clear();
                return true;
            }
            else if(symbol == "back")
            {
                WhatOperand().ClearLastSign();
                return true;
            }
            return false;
        }

        private void ClearAll()
        {
            firstArgument.Clear();
            secondArgument.Clear();
            operation = "";
        }

        private bool MemoryOperation(string symbol)//MC, MS, MR, M+, M-
        {
            if (symbol == "MC")
            {
                buffer.MemoryClear();
                return true;
            }
            else if (symbol == "MS")
            {
                buffer.MemorySave(WhatOperand().ToString());
                return true;
            }
            else if (symbol == "MR")
            {
                if (secondArgument.ToString() == "")
                    secondArgument.SetNumber(buffer.MemoryRead);
                else
                    firstArgument.SetNumber(buffer.MemoryRead);
                return true;
            }
            else if (symbol == "M+")
            {
                buffer.MemoryAdd(WhatOperand().ToString());
                return true;
            }
            else if (symbol == "M-")
            {
                buffer.MemorySubstract(WhatOperand().ToString());
                return true;
            }
            return false;
        }
    }
}