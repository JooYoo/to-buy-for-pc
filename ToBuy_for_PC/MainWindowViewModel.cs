using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToBuy_for_PC.Annotations;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.Implementation;
using ToBuy_for_PC.ListManager;
using ToBuy_for_PC.ListWindow;
using ToBuy_for_PC.OperationContract;
using ToBuy_for_PC.SideDrawer;

namespace ToBuy_for_PC
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string wantBuy;
        private ObservableCollection<ToBuy> toBuys;
        private ToBuy selectedToBuy;
        private DayOfWeek dayWeekTime; 

        public IDataAccess DataAccess { get; set; }
        public IShoppingListManager ShoppingListManager { get; set; }

        public List<ShoppingList> ShoppingLists { get; set; }
        public DayOfWeek DayWeekTime 
        {
            get { return dayWeekTime; }
            set
            {
                dayWeekTime = value;
                OnPropertyChanged();
            }
        }
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

        public ICommand MondayCommand { get; set; }
        public ICommand TuesdayCommand { get; set; }
        public ICommand WednesdayCommand { get; set; }
        public ICommand ThursdayCommand { get; set; }
        public ICommand FridayCommand { get; set; }
        public ICommand SaturdayCommand { get; set; }
        public ICommand SundayCommand { get; set; }

        public MainWindowViewModel(IDataAccess dataAccess = null, IShoppingListManager shoppingListManager = null)
        {
            // prepare for Unit Test
            DataAccess = dataAccess ?? new DataAccess();
            ShoppingListManager = shoppingListManager ?? new ShoppingListManager();

            // Get all data
             ShoppingLists = DataAccess.ToLoad();

            // set WeekDay
            DayWeekTime = DateTime.Today.DayOfWeek;
            // Textbox: placeholder
            WantBuy = "e.g. apple ...";
            // DataGrid: load data from Json
            // Todo: temporary use fake shoppingList for initialize
            ToBuys = new ObservableCollection<ToBuy>(ShoppingListManager.TodayShoppingList(ShoppingLists));
            // ClearButton
            ClearCommand = new ClearCommand(this);
            // AddButton
            AddCommand = new AddCommand(this);
            // Remove item Button
            RemoveSelectedCommand = new RemoveSelectedCommand(this);
            // arrange Button
            ArrangeCommand = new ArrangeCommand(this);
            // Monday ... Sunday Button
            MondayCommand = new MondayCommand(this);
            TuesdayCommand = new TuesdayCommand(this);
            WednesdayCommand = new WednesdayCommand(this);
            ThursdayCommand = new ThursdayCommand(this);
            FridayCommand = new FridayCommand(this);
            SaturdayCommand = new SaturdayCommand(this);
            SundayCommand = new SundayCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
