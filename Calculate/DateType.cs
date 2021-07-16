namespace Calculate
{
    class Number
    {
        private string first;
        private string point;
        private string second;
        private string number;

        public bool AddSymbol(string symbol)
        {
            int temp;
            if (symbol == ",")
                point = symbol;
            else if (int.TryParse(symbol, out temp))
            {
                if (point != ",")
                    first += symbol;
                else
                    second += symbol;
            }
            else
                return false;
            number = first + point + second;
            return true;
        }

        public void SetNumber(string number)
        {
            Clear();
            this.number = number;
        }

        public void Clear()
        {
            number = first = "";
            second = point = "";
        }

        public bool ResetSign()
        {
            int temp;

            if (!int.TryParse(first, out temp))
                return false;

            first = (-temp).ToString();
            number = first + point + second;

            return true;
        }

        public override string ToString()
        {
            return number;
        }
    }
}
