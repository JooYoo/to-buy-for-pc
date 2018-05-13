using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToBuy_for_PC.Annotations;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.Implementation;

namespace ToBuy_for_PC.ListWindow
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string wantBuy;
        private ObservableCollection<ToBuy> toBuys;
        private ToBuy selectedToBuy;

        public DataAccess DataAccess { get; set; }

        public string WantBuy
        {
            get { return wantBuy; }
            set
            {
                wantBuy = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ToBuy> ToBuys
        {
            get { return toBuys; }
            set
            {
                toBuys = value;
                OnPropertyChanged();
            }
        }

        public ToBuy SelectedToBuy
        {
            get { return selectedToBuy; }
            set
            {
                selectedToBuy = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveSelectedCommand { get; set; }
        public ICommand ArrangeCommand { get; set; }

        public MainWindowViewModel()
        {
            // instance DataAccess
            DataAccess = new DataAccess();
            // Textbox: placeholder
            WantBuy = "e.g. apple ...";
            // DataGrid: load data from Json
            ToBuys = new ObservableCollection<ToBuy>(DataAccess.ToLoad());
            // ClearButton
            ClearCommand = new ClearCommand(this);
            // AddButton
            AddCommand = new AddCommand(this);
            // Remove item Button
            RemoveSelectedCommand = new RemoveSelectedCommand(this);
            // arrange Button
            ArrangeCommand = new ArrangeCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
