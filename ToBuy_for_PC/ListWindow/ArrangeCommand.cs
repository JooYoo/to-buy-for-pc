using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.ListWindow
{
    public class ArrangeCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public ArrangeCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (viewModel.ToBuys == null)
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            // find specific ShoppingList
            var targetShoppingList = viewModel.ShoppingLists.Find(x => x.WeekDay == viewModel.DayWeekTime);
            // Reorder: false - true
            var orderByIsDone = targetShoppingList.ToBuys.OrderBy(x => x.IsDone).ToList();
            // new order list is the Current List
            targetShoppingList.ToBuys = orderByIsDone;
            // display List
            viewModel.ToBuys = new ObservableCollection<ToBuy>(orderByIsDone);
            // todo: save data
            //viewModel.DataAccess.ToSave(viewModel.ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}
