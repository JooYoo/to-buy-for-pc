using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
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
                var shoppingLists = ((MainWindowViewModel)DataContext).ShoppingLists;
                ((MainWindowViewModel)DataContext).DataAccess.ToSave(shoppingLists);
            }
        }
        //
        private void btnRightMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }
        private void btnRightMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowRightMenu", btnRightMenuHide, btnRightMenuShow, pnlRightMenu);
        }
        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = Visibility.Visible;
                //btnShow.Visibility = Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                //btnHide.Visibility = Visibility.Hidden;
                btnShow.Visibility = Visibility.Visible;
            }
        }
    }
}
