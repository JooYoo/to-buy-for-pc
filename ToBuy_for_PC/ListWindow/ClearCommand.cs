﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.ListWindow
{
    public class ClearCommand:ICommand
    {
        private MainWindowViewModel viewModel;
        public ClearCommand(MainWindowViewModel mainWindowViewModel)
        {
            viewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.ToBuys = new ObservableCollection<ToBuy>();
            // save data
            viewModel.DataAccess.ToSave(viewModel.ToBuys);
        }

        public event EventHandler CanExecuteChanged;
    }
}