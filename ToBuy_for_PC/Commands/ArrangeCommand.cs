using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToBuy_for_PC.Model;
using ToBuy_for_PC.ViewModel;

namespace ToBuy_for_PC.Commands
{
    public class ArrangeCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public ArrangeCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (viewModel.ToBuys == null)
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            var toBuys = viewModel.ToBuys;


            // move DoneToBuy to last place

            //// find selectedItem index
            //int indexOld = toBuys.ToList().IndexOf(selectedToBuy);
            //// get last item index
            //int lastIndex = toBuys.Count - 1;
            //// move to new place
            //toBuys.Move(indexOld, lastIndex);

            // 按照假到真的顺序重新排序
            List<ToBuy> orderByIsDone = toBuys.OrderBy(x => x.IsDone).ToList();
            // save new 
            viewModel.ToBuys =new ObservableCollection<ToBuy>(orderByIsDone);

        }

        public event EventHandler CanExecuteChanged;
    }
}
