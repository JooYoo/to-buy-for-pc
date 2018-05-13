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
            var readyRemove = viewModel.SelectedToBuy;
            // remove item
            viewModel.ToBuys.Remove(readyRemove);
            // save change
            viewModel.DataAccess.ToSave(viewModel.ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}
