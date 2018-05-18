using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.SideDrawer
{
    public class SaturdayCommand:ICommand
    {
        private readonly MainWindowViewModel viewModel;
        public SaturdayCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
           // get shoppingList for Saturday
           viewModel.ToBuys = new ObservableCollection<ToBuy>
                (viewModel.ShoppingLists.Find(x=>x.WeekDay == DayOfWeek.Saturday).ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}
