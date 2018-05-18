using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class FridayCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public FridayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // get Friday ShoppingList
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x=>x.WeekDay == DayOfWeek.Friday).ToBuys);
            // set DayWeekTime
            viewModel.DayWeekTime = DayOfWeek.Friday;
        }

        public event EventHandler CanExecuteChanged;
    }
}
