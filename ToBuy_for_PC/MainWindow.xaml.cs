using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            TextBox textBox = (TextBox)sender;
            textBox.Text = String.Empty;
        }
        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
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

        //Side Drawer
        private bool IsShowMenu;
        private void btnDrawer_Click(object sender, RoutedEventArgs e)
        {
            if (IsShowMenu == false)
            {
                ShowHideMenu("sbShowDrawer", bodDrawer);
                IsShowMenu = true;
            }
            else
            {
                ShowHideMenu("sbHideDrawer", bodDrawer);
                IsShowMenu = false;
            }
        }
        private void ShowHideMenu(string Storyboard, Border border)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(border);
        }
    }
}
