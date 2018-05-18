using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class MondayCommand : ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public MondayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // find Monday list to display on DataGrid
            viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x => x.WeekDay == DayOfWeek.Monday).ToBuys);
            // set DayTime
            viewModel.DayWeekTime = DayOfWeek.Monday;
        }
        public event EventHandler CanExecuteChanged;
    }
}
