using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToBuy_for_PC.DataContract;

namespace ToBuy_for_PC.OperationContract
{
    public interface IDataAccess
    {
        void ToSave(ObservableCollection<ToBuy> toBuys);
        List<ToBuy> ToLoad();
    }
}
