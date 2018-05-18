using System.Collections.Generic;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.OperationContract
{
    public interface IShoppingListManager
    {
        List<ToBuy> TodayShoppingList(List<ShoppingList> allList);
    }
}