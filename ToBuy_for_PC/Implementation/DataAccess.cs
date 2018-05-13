using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC.Implementation
{
    public class DataAccess:IDataAccess
    {
        public void ToSave(ObservableCollection<ToBuy> toBuys)
        {
            using (StreamWriter file = File.CreateText(@"ToBuyData.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;    // Json formating 
                serializer.Serialize(file, toBuys);
            }
        }

        public List<ToBuy> ToLoad()
        {
            try
            {
                using (StreamReader file = File.OpenText(@"ToBuyData.json"))
                {
                    var deserializer = new JsonSerializer();
                    List<ToBuy> result = (List<ToBuy>)deserializer.Deserialize(file, typeof(List<ToBuy>));
                    
                    return result;
                }
            }
            catch (Exception e)
            {
                return new List<ToBuy>()
                {
                    new ToBuy{Name = "sample. apple", IsDone = false},
                    new ToBuy{Name = "sample. pizza", IsDone = false},
                    new ToBuy{Name = "sample. beer", IsDone = false}
                };
            }
        }
    }
}
