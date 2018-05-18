using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class SundayCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public SundayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // get Sunday shoppingList
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                 (viewModel.ShoppingLists.Find(x => x.WeekDay == DayOfWeek.Sunday).ToBuys);
            // set DayTime
            viewModel.DayWeekTime = DayOfWeek.Sunday;
        }

        public event EventHandler CanExecuteChanged;
    }
}
