using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class TuesdayCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public TuesdayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // find Tuesday shoppingList
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x => x.WeekDay == DayOfWeek.Tuesday).ToBuys);
            // set DayTime
            viewModel.DayWeekTime = DayOfWeek.Tuesday;
        }

        public event EventHandler CanExecuteChanged;
    }
}
