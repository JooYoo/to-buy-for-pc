using System.Collections.Generic;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.OperationContract
{
    public interface IDataAccess
    {
        //void ToSave(ObservableCollection<ToBuy> toBuys);
        //List<ToBuy> ToLoad();

        void ToSave(List<ShoppingList> shoppingLists);
        List<ShoppingList> ToLoad();
    }
}
