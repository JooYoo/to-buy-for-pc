using System;
using System.Windows.Input;

namespace ToBuy_for_PC.ListWindow
{
    public class RemoveSelectedCommand:ICommand
    {
        private MainWindowViewModel viewModel;
        public RemoveSelectedCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // get the removeBt
            var readyRemove = viewModel.SelectedToBuy;
            // find specific ShoppingList
            var targetShoppingList = viewModel.ShoppingLists.Find(x => x.WeekDay == viewModel.DayWeekTime);
            // remove item
            targetShoppingList.ToBuys.Remove(readyRemove);
            // display on screen
            viewModel.ToBuys.Remove(readyRemove);

            // save change
            viewModel.DataAccess.ToSave(viewModel.ShoppingLists);
        }

        public event EventHandler CanExecuteChanged;
    }
}
