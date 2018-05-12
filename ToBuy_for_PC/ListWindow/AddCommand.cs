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
            // add new item to List
            var wantBuy = viewModel.WantBuy;
            viewModel.ToBuys.Add(new ToBuy{Name = wantBuy, IsDone = false});
            // clean up textbox
            viewModel.WantBuy = "";
        }

        public event EventHandler CanExecuteChanged;
    }
}
