using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToBuy_for_PC.ListWindow;
using ToBuy_for_PC.ViewModel;

namespace ToBuy_for_PC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        // Textbox place holder
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            textBox.Text = String.Empty;
        }
        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            if (textBox.Text == String.Empty)
            {
                textBox.Text = "e.g. apple ...";
            }
        }
    }
}
