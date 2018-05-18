using System;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.ListWindow
{
    public class AddCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public AddCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // create new ToBuy
            ToBuy newToBuy = new ToBuy{Name = viewModel.WantBuy, IsDone = false};
            // find specific ShoppingList
            var targetShoppingList = viewModel.ShoppingLists.Find(x => x.WeekDay == viewModel.DayWeekTime);
            // add newToBuy to the List for saving
            targetShoppingList.ToBuys.Add(newToBuy);
            // display on screen
            viewModel.ToBuys.Add(newToBuy);

            //todo:save ShoppingLists
            //viewModel.DataAccess.ToSave(viewModel.ToBuys);

            // clean up textbox
            viewModel.WantBuy = "";
        }

        public event EventHandler CanExecuteChanged;
    }
}
