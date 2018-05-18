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
        private DateTime dayWeekTime; // todo: display current day of week

        public IDataAccess DataAccess { get; set; }
        public IShoppingListManager ShoppingListManager { get; set; }

        public List<ShoppingList> ShoppingLists { get; set; }
        public DateTime DayWeekTime // todo: display current day of week
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
            ShoppingLists = FakeShoppingLists();
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

        private List<ShoppingList> FakeShoppingLists()
        {
            var shoppingLists = new List<ShoppingList>();

            ShoppingList MonList = new ShoppingList
            {
                WeekDay = DayOfWeek.Monday,
                ToBuys = new List<ToBuy>
               {
                   new ToBuy { Name = "Mon1", IsDone = false},
                   new ToBuy { Name = "Mon1", IsDone = false},
                   new ToBuy { Name = "Mon1", IsDone = false},
               }
            };
            ShoppingList TueList = new ShoppingList
            {
                WeekDay = DayOfWeek.Tuesday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Tue1", IsDone = false},
                    new ToBuy { Name = "Tue2", IsDone = false},
                    new ToBuy { Name = "Tue3", IsDone = false},
                }
            };
            ShoppingList WedList = new ShoppingList
            {
                WeekDay = DayOfWeek.Wednesday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Wed1", IsDone = false},
                    new ToBuy { Name = "Wed2", IsDone = false},
                    new ToBuy { Name = "Wed3", IsDone = false},
                }
            };
            ShoppingList ThurList = new ShoppingList
            {
                WeekDay = DayOfWeek.Thursday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Thur1", IsDone = false},
                    new ToBuy { Name = "Thur2", IsDone = false},
                    new ToBuy { Name = "Thur3", IsDone = false},
                }
            };
            ShoppingList FridayList = new ShoppingList
            {
                WeekDay = DayOfWeek.Friday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Fri1", IsDone = false},
                    new ToBuy { Name = "Fri2", IsDone = false},
                    new ToBuy { Name = "Fri3", IsDone = false},
                }
            };
            ShoppingList SatList = new ShoppingList
            {
                WeekDay = DayOfWeek.Saturday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Sat1", IsDone = false},
                    new ToBuy { Name = "Sat2", IsDone = false},
                    new ToBuy { Name = "Sat3", IsDone = false},
                }
            };
            ShoppingList SunList = new ShoppingList
            {
                WeekDay = DayOfWeek.Sunday,
                ToBuys = new List<ToBuy>
                {
                    new ToBuy { Name = "Sun1", IsDone = false},
                    new ToBuy { Name = "Sun2", IsDone = false},
                    new ToBuy { Name = "Sun3", IsDone = false},
                }
            };

            shoppingLists.Add(MonList);
            shoppingLists.Add(TueList);
            shoppingLists.Add(WedList);
            shoppingLists.Add(ThurList);
            shoppingLists.Add(FridayList);
            shoppingLists.Add(SatList);
            shoppingLists.Add(SunList);

            return shoppingLists;
        }
    }
}
