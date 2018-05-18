using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class WednesdayCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public WednesdayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // get shoppingList
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x=>x.WeekDay == DayOfWeek.Wednesday).ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}
