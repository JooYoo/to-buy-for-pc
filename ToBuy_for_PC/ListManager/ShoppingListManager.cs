using System;
using System.Collections.Generic;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC.ListManager
{
    public class ShoppingListManager : IShoppingListManager
    {
        public List<ToBuy> TodayShoppingList(List<ShoppingList> allList)
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
            ShoppingList todayShoppingList = allList.Find(x => x.WeekDay == today);

            return todayShoppingList.ToBuys;
        }

        // fake ShoppingLists for Testing
        public List<ShoppingList> FakeShoppingLists()
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
