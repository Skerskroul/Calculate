namespace Calculate
{
    /// <summary>
    /// организовывает взаимосвязь с View и Model
    /// organization connect with View and ViewModel
    /// </summary>
    class ViewModel
    {
        private readonly MathModel mathModel;

        public ViewModel()
        {
            mathModel = new MathModel();
        }
        /// <summary>
        /// UA. Отримує аргументи з View. В подальшому буде мінятися.
        /// ENG. Take argument from View. It will be modificate in the future.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public string TakeArgument(string argument)
        {
            return mathModel.Parse(argument);
        }
        /// <summary>
        /// 
        /// </summary>
        public void CleanAll()
        {
            mathModel.Clean();
        }

    }
}
