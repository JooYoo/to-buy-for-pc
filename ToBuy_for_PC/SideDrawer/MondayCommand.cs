using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToBuy_for_PC.ListWindow;

namespace ToBuy_for_PC.SideDrawer
{
    public class MondayCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public MondayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
