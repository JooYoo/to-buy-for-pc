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
    }
}
