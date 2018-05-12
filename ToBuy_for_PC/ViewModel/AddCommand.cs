using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToBuy_for_PC.Model;

namespace ToBuy_for_PC.ViewModel
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
