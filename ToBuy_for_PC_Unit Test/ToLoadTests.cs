using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToBuy_for_PC;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC_Unit_Test
{
    [TestClass]
    public class ToLoadTests
    {
        private List<ShoppingList> MockShoppingList()
        {
            return new List<ShoppingList>
            {
                new ShoppingList
                {
                    Name = "testShoppingList",
                    IsDone = false,
                    WeekDay = DateTime.Today.DayOfWeek,
                    ToBuys = new List<ToBuy>
                    {
                        new ToBuy{IsDone = false,Name = "testTobuy"}
                    }
                }
            };
        }

        [TestMethod]
        public void ToLoadFunctionTest()
        {
            // Mock LoadData: prepare Mock test Environment
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList()); // Mock LoadData

            // instance MainWindowViewModal to trigger ToLoad()
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            
            // result
            Assert.AreEqual(viewModel.ShoppingLists.Count, 1);
            Assert.AreEqual(viewModel.ShoppingLists[0].Name, "testShoppingList");
            Assert.AreEqual(viewModel.ToBuys.Count, 1);
            Assert.AreEqual(viewModel.ToBuys[0].Name, "testTobuy");
            Assert.IsFalse(viewModel.ToBuys[0].IsDone);
        }
    }
}
