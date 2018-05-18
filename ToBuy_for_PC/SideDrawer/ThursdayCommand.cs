using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class ThursdayCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public ThursdayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // get shoppingList for Thursday
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x=>x.WeekDay == DayOfWeek.Thursday).ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}
