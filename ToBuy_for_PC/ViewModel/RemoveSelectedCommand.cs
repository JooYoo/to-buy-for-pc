using System;
using System.Windows.Input;

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
            
            var readyRemove = viewModel.SelectedToBuy;
            viewModel.ToBuys.Remove(readyRemove);
        }

        public event EventHandler CanExecuteChanged;
    }
}
