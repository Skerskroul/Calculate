namespace Calculate
{
    /// <summary>
    /// организовывает взаимосвязь с View и Model
    /// organization connect with View and ViewModel
    /// </summary>
    class ViewModel
    {
        private readonly Model mathModel;

        public ViewModel()
        {
            mathModel = new Model();
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
        /// UA.  Для очищення всіх даних
        /// END. For clean date
        /// </summary>
        public void CleanAll()
        {
            mathModel.Clean();
        }
    }
}
