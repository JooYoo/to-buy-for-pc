using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC.Implementation
{
    public class DataAccess : IDataAccess
    {
        public void ToSave(List<ShoppingList> shoppingLists)
        {
            using (StreamWriter file = File.CreateText(@"ToBuyData.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, shoppingLists);
            }
        }

        public List<ShoppingList> ToLoad()
        {
            try
            {
                using (StreamReader file = File.OpenText(@"ToBuyData.json"))
                {
                    var deserializer = new JsonSerializer();
                    List<ShoppingList> shoppingLists =
                        (List<ShoppingList>)deserializer.Deserialize(file, typeof(List<ShoppingList>));
                    return shoppingLists;
                }

            }
            catch (Exception e)
            {
                var shoppingLists = new List<ShoppingList>();

                ShoppingList MonList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Monday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Apple", IsDone = false } }
                };
                ShoppingList TueList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Tuesday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Banana", IsDone = false } }
                };
                ShoppingList WedList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Wednesday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Cake", IsDone = false } }
                };
                ShoppingList ThurList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Thursday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Donut", IsDone = false } }
                };
                ShoppingList FridayList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Friday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Egg", IsDone = false } }
                };
                ShoppingList SatList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Saturday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Fig", IsDone = false } }
                };
                ShoppingList SunList = new ShoppingList
                {
                    WeekDay = DayOfWeek.Sunday,
                    ToBuys = new List<ToBuy> { new ToBuy { Name = "Grape", IsDone = false } }
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
}
