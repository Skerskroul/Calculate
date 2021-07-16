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
            number = first = second = point = "";
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

        public void ClearLastSign()
        {
            if (second != "")
            {
                second = Erase(second);
                if(second == "")
                    point = "";
            }
            else if (first != "")
                first = Erase(first);
            number = first + point + second;
        }

        private string Erase(string str)
        {
            int size = str.Length - 1;

            string result = "";

            for (int i = 0; i < size; i++)
                result += str[i];
            return result;
        }

        public override string ToString()
        {
            return number;
        }
    }

    class Buffer
    {
        public string buff = "0";

        public void MemorySave(string number) => buff = number;

        public string MemoryRead { get { return buff; } }

        public void MemoryAdd(string number) => buff = (double.Parse(buff) + double.Parse(number)).ToString();

        public void MemorySubstract(string number) => buff = (double.Parse(buff) - double.Parse(number)).ToString();

        public void MemoryClear() => buff = "0";
    }

}