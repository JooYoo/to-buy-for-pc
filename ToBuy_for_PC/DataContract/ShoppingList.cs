using System;
using System.Collections.Generic;

namespace ToBuy_for_PC.DataContract
{
    public class ShoppingList : ToBuy
    {
        public List<ToBuy> ToBuys { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}
