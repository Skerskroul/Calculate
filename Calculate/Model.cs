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
                //if(!OperationWithNumber(symbol))
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
            if (symbol == "=")
                Calculate();
            else if (symbol != "=" && operation == "")
                operation = symbol;
            else if (symbol != "=" && operation != "" && secondArgument.ToString() == "")
                operation = symbol;
            else if(symbol != "=" && operation != "" && secondArgument.ToString() != "")
            {
                Calculate();
                operation = symbol;
            }
        }

        //private bool OperationWithNumber(string symbol)
        //{
        //    //if (secondArgument.ToString() != "")
        //        //return NumberOperation(ref secondArgument, symbol);
        //    //else if (firstArgument.ToString() != "")
        //        //return NumberOperation(ref firstArgument, symbol);
        //    return false;
        //}

        //private bool NumberOperation(ref Number number, string symbol)
        //{
        //    switch (symbol)
        //    {
        //        case "+/-":
        //            {
        //                return number.ResetSign();
        //            }
        //    }
        //    return false;
        //}

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
        private void Calculate()
        {
            double first, second;
            double.TryParse(firstArgument.ToString(), out first);
            double.TryParse(secondArgument.ToString(), out second);

            switch (operation)
            {
                case "+":
                    {
                        firstArgument.SetNumber((first + second).ToString());
                        break;
                    }
                case "-":
                    {
                        firstArgument.SetNumber((first - second).ToString());
                        break;
                    }
                case "*":
                    {
                        firstArgument.SetNumber((first * second).ToString());
                        break;
                    }
                case "/":
                    {
                        firstArgument.SetNumber((first / second).ToString());
                        break;
                    }
                default:
                    {
                        firstArgument.SetNumber((first).ToString());
                        break;
                    }
            }
            secondArgument.Clear();
            operation = "";
        }

        public void Clean()
        {

        }
    }
}
