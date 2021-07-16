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

        public Model()
        {
            firstArgument = new Number();
            secondArgument = new Number();
            firstArgument.Clear();
            secondArgument.Clear();
            operation = "";
        }
        /// <summary>
        /// UA. Mетод для коректного парсингу даних. Проблема функція бере багато на себе обов'язків
        /// ENG. This function use for correct parse date. Main problem: this function take a lot responsibility
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string DoSomething(string symbol)
        {
            if (!ParseNumber(symbol))
                ParseOperation(symbol);

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

        private void ParseOperation(string symbol)
        {
            if (UnaryCalculate(symbol))//+/-, kor, 1/x
                return;
            else if (UnaryCalculateWithTwoArgument(symbol))//%
                return;
            else if (CalculateBinaryOperation(symbol))
                return;
            
        }

        /// <summary>
        /// UA. Створює рядок який повертаеться, як аргумент за посиланням
        /// ENG. Create string which return as an arguments to the link
        /// </summary>
        /// <param name="result"></param>
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
        /// <summary>
        /// UA. Проводить розрахунки в залежності від знаку 
        /// ENG. Do calculate. Information comments from Junior ;D
        /// </summary>
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

        private bool CalculateBinaryOperation(string symbol)
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

        public void Clean()
        {

        }
    }
}
