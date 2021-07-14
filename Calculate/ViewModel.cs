using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculate
{
    /// <summary>
    /// организовывает взаимосвязь с View и Model
    /// organization connect with View and ViewModel
    /// </summary>
    class ViewModel : INotifyPropertyChanged
    {
        private string result = "0";
        private Model model = new Model();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickButton
        {
            get
            {
                return new RelayCommand((obj) =>
                    {
                        Result = model.Parse(obj.ToString());
                    });
            }
        }
    }
}
