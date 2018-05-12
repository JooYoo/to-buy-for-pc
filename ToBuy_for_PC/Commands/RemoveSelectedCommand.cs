using System;
using System.Windows.Input;
using ToBuy_for_PC.ListWindow;

namespace ToBuy_for_PC.ViewModel
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
            // remove item
            var readyRemove = viewModel.SelectedToBuy;
            viewModel.ToBuys.Remove(readyRemove);
        }

        public event EventHandler CanExecuteChanged;
    }
}
