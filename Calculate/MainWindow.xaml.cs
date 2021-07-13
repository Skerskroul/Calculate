using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// View
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel;
        private string result = "";
        private bool send_point = false;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
        }

        private void memoryClear_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void memoryRead_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void memorySave_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void memoryAdd_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void memoryDifference_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clearLast_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Call clear all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAll_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            //viewModel.CleanAll();
        }

        private void koren_Click(object sender, RoutedEventArgs e)
        {

        }

        private void perCent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DivisionX_Click(object sender, RoutedEventArgs e)
        {

        }

        private void total_Click(object sender, RoutedEventArgs e)
        {

        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            send_point = true;
        }
        
        private void SendArgument(string argument)
        {
            if (send_point)
            {
                send_point = false;

                if (argument == "0" || argument == "1" || argument == "2" || argument == "3" || argument == "4" || argument == "5" || argument == "6"
                    || argument == "7" || argument == "8" || argument == "9")
                    result = viewModel.TakeArgument("," + argument);
            }
            else
                result = viewModel.TakeArgument(argument);
            textBox.Text = result;
        }





        private void Add_Number(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            SendArgument(button.Content.ToString());
        }
    }
}
