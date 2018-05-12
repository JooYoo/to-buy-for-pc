using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToBuy_for_PC.Annotations;
using ToBuy_for_PC.Commands;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.ViewModel;

namespace ToBuy_for_PC.ListWindow
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string wantBuy;
        private ObservableCollection<ToBuy> toBuys;
        private ToBuy selectedToBuy;


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
            // Textbox
            WantBuy = "e.g. apple ...";
            // DataGrid
            ToBuys = ToBuyData();
            // ClearButton
            ClearCommand = new ClearCommand(this);
            // AddButton
            AddCommand = new AddCommand(this);
            // Remove item Button
            RemoveSelectedCommand = new RemoveSelectedCommand(this);
            // arrange Button
            ArrangeCommand = new ArrangeCommand(this);
        }

        // mock Data
        private ObservableCollection<ToBuy> ToBuyData()
        {
            return new ObservableCollection<ToBuy>
            {
                new ToBuy{Name = "Buy1", IsDone = false},
                new ToBuy{Name = "Buy2", IsDone = false},
                new ToBuy{Name = "Buy3", IsDone = false}
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
