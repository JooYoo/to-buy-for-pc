using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ToBuy_for_PC.ListWindow;

namespace ToBuy_for_PC
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // connect view and viewModel
            DataContext = new MainWindowViewModel();

            
            // start window loacation center
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
        
        // close app: save data or cancel
        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // save data
                var toBuys = ((MainWindowViewModel)DataContext).ToBuys;
                ((MainWindowViewModel)DataContext).DataAccess.ToSave(toBuys);
            }
        }
    }
}
