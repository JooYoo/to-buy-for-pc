using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.ListWindow
{
    public class ClearCommand:ICommand
    {
        private MainWindowViewModel viewModel;
        public ClearCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // find specific ShoppingList
            var targetShoppingList = viewModel.ShoppingLists.Find(x => x.WeekDay == viewModel.DayWeekTime);
            // clean up the List
            targetShoppingList.ToBuys = new List<ToBuy>();
            // display on Screen
            viewModel.ToBuys = new ObservableCollection<ToBuy>();

            // save Changes
            viewModel.DataAccess.ToSave(viewModel.ShoppingLists);
        }

        public event EventHandler CanExecuteChanged;
    }
}
