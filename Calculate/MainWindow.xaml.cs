using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculate
{
    /// <summary>
    /// View
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
        }

        private void SendArguments(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            textBox.Text = viewModel.TakeArgument(button.Content.ToString());
        }
    }
}
