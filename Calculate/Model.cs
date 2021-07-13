namespace Calculate
{
    /// <summary>
    /// Model - бизнес логика
    /// Business layer
    /// </summary>
    class Model
    {
        private string firstArgument;
        private string operation;
        private string secongArgument;
        
        /// <summary>
        /// UA. Конструктор
        /// ENG. Just ctor
        /// </summary>
        public Model()
        {
            firstArgument = secongArgument = operation = "";
        }
        /// <summary>
        /// UA. Mетод для коректного парсингу даних. Проблема функція бере багато на себе обов'язків
        /// ENG. This function use for correct parse date. Main problem: this function take a lot responsibility
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string Parse(string number)
        {
            double temp;

            if(operation == "")
            {
                if (number == "+" || number == "-" || number == "*" || number == "/")
                {
                    if (firstArgument != "")
                        operation = number;
                }
                else if (number == "+-")
                {
                    double.TryParse(firstArgument, out temp);
                    firstArgument = (-temp).ToString();
                }
                else
                {
                    if (double.TryParse(firstArgument + number, out temp))
                        firstArgument = temp.ToString();
                }
            }
            else if(operation != "")
            {
                if (number == "+" || number == "-" || number == "*" || number == "/")
                {
                    if(secongArgument != "")
                        Calculate();
                    operation = number;
                }
                else if(number == "+-")
                {
                    double.TryParse(secongArgument, out temp);
                    secongArgument = (-temp).ToString();
                }
                else
                {
                    if (double.TryParse(secongArgument + number, out temp))
                        secongArgument = temp.ToString();
                }
            }

            return CreateResult();
        }
        /// <summary>
        /// UA. Створює рядок який повертаеться, як аргумент за посиланням
        /// ENG. Create string which return as an arguments to the link
        /// </summary>
        /// <param name="result"></param>
        private string CreateResult()
        {
            string result;
            result = firstArgument;
            if (operation != "")
                result += " " + operation;
            if(secongArgument != "")
                result += " " + secongArgument;

            return result;
        }
        /// <summary>
        /// UA. Проводить розрахунки в залежності від знаку 
        /// ENG. Do calculate. Information comments from Junior ;D
        /// </summary>
        private void Calculate()
        {
            switch(operation)
            {
                case "+":
                    {
                        firstArgument = (double.Parse(firstArgument) + double.Parse(secongArgument)).ToString();
                        secongArgument = operation = "";
                        break;
                    }
                case "-":
                    {
                        firstArgument = (double.Parse(firstArgument) - double.Parse(secongArgument)).ToString();
                        secongArgument = operation = "";
                        break;
                    }
                case "*":
                    {
                        firstArgument = (double.Parse(firstArgument) * double.Parse(secongArgument)).ToString();
                        secongArgument = operation = "";
                        break;
                    }
                case "/":
                    {
                        firstArgument = (double.Parse(firstArgument) / double.Parse(secongArgument)).ToString();
                        secongArgument = operation = "";
                        break;
                    }
            }
        }

        public void Clean()
        {
            firstArgument = operation = secongArgument = "";
        }
    }
}
