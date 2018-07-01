using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToBuy_for_PC;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.ListWindow;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC_Unit_Test
{
    [TestClass]
    public class ToSaveTests
    {
        private List<ShoppingList> MockShoppingList()
        {
            return new List<ShoppingList>
            {
                new ShoppingList
                {
                    IsDone = false,
                    Name = "test",
                    ToBuys = new List<ToBuy> (),
                    WeekDay = DateTime.Today.DayOfWeek
                }
            };
        }


        [TestMethod]
        public void ToSaveAddCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList); // Mock LoadData

            // call AddCommand() once so that ToSave() will be called
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.AddCommand.Execute(null);

            // TestResult: ToSave() will be called once
            dataAccessMock.Verify(m => m.ToSave(It.IsAny<List<ShoppingList>>()), Times.Exactly(1));
        }

        [TestMethod]
        public void ToSaveArrangeCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList()); // Mock LoadData

            // call ArrangeCommand() once so that ToSave() will be called
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.ArrangeCommand.Execute(null);

            // TestResult: ToSave() will be called once
            dataAccessMock.Verify(m => m.ToSave(It.IsAny<List<ShoppingList>>()), Times.Once);
        }

        [TestMethod]
        public void ToSaveClearCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList());

            // input one Item
            var viewModel = new MainWindowViewModel(dataAccessMock.Object); // instance MainWindowViewModel
            viewModel.WantBuy = "newItem";

            // pressed add button
            var addCommand = new AddCommand(viewModel);
            addCommand.Execute(null);

            // before clear
            Assert.AreEqual(viewModel.ToBuys.Count, 1);
            Assert.AreEqual(viewModel.ToBuys[0].Name, "newItem");
            Assert.IsFalse(viewModel.ToBuys[0].IsDone);

            // clean item up
            var clearCommand = new ClearCommand(viewModel);
            clearCommand.Execute(null);

            // after clear
            Assert.AreEqual(viewModel.ToBuys.Count, 0);
        }

        [TestMethod]
        public void ToSaveRemoveCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList());

            // input one Item
            var viewModel = new MainWindowViewModel(dataAccessMock.Object); // instance MainWindowViewModel
            viewModel.WantBuy = "newItem";

            // pressed add button
            var addCommand = new AddCommand(viewModel);
            addCommand.Execute(null);

            // before remove
            Assert.AreEqual(viewModel.ToBuys.Count, 1);
            Assert.AreEqual(viewModel.ToBuys[0].Name, "newItem");
            Assert.IsFalse(viewModel.ToBuys[0].IsDone);

            // set selected Item
            viewModel.SelectedToBuy = viewModel.ToBuys[0];

            // delete selected
            var removeSelectedCommand = new RemoveSelectedCommand(viewModel);
            removeSelectedCommand.Execute(null);

            // after clear
            Assert.AreEqual(viewModel.ToBuys.Count, 0);
        }

        [TestMethod]
        public void ToSaveFunctionTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(MockShoppingList()); // Mock LoadData

            // call ArrangeCommand() once so that ToSave() will be called
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.WantBuy = "newItem"; // create a new data 

            // after AddCommand() called the ToSave()
            var addCommand = new AddCommand(viewModel);
            addCommand.Execute(null);

            // result
            Assert.AreEqual(viewModel.ToBuys.Count, 1);
            Assert.AreEqual(viewModel.ToBuys[0].Name, "newItem");
            Assert.IsFalse(viewModel.ToBuys[0].IsDone);
        }
    }
}
