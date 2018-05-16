using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToBuy_for_PC.DataContract;
using ToBuy_for_PC.ListWindow;
using ToBuy_for_PC.OperationContract;

namespace ToBuy_for_PC_Unit_Test
{
    [TestClass]
    public class ToSaveTests
    {
        [TestMethod]
        public void ToSaveAddCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(new List<ToBuy>()); // Mock LoadData

            // call AddCommand() once so that ToSave() will be called
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.AddCommand.Execute(null);

            // TestResult: ToSave() will be called once
            dataAccessMock.Verify(m => m.ToSave(It.IsAny<ObservableCollection<ToBuy>>()), Times.Exactly(1));
        }

        [TestMethod]
        public void ToSaveArrangeCommandTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(new List<ToBuy>()); // Mock LoadData

            // call ArrangeCommand() once so that ToSave() will be called
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.ArrangeCommand.Execute(null);

            // TestResult: ToSave() will be called once
            dataAccessMock.Verify(m => m.ToSave(It.IsAny<ObservableCollection<ToBuy>>()), Times.Once);
        }

        [TestMethod]
        public void ToSaveFunctionTest()
        {
            // fake LoadData
            var dataAccessMock = new Mock<IDataAccess>(); // instance a Mock for IDataAccess
            dataAccessMock.Setup(m => m.ToLoad()).Returns(new List<ToBuy>()); // Mock LoadData

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

        [TestMethod]
        public void TestMethod2()
        {
            //Preparation
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock.Setup(m => m.ToLoad()).Returns(new List<ToBuy> { new ToBuy { IsDone = false, Name = "Test" } });
            var viewModel = new MainWindowViewModel(dataAccessMock.Object);
            viewModel.WantBuy = "Test123";
            var addCommand = new AddCommand(viewModel);

            //Test
            addCommand.Execute(null);

            //Validation
            dataAccessMock.Verify(m => m.ToSave(It.IsAny<ObservableCollection<ToBuy>>()), Times.Exactly(1));
            Assert.AreEqual(viewModel.WantBuy, string.Empty);
        }
    }
}
