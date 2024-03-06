using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PowerPoint.Command.Tests
{
    [TestClass]
    public class DeleteCommandTests
    {
        private DeleteCommand _removeCommand;
        private Mock<Model> _mockModel;
        private Shape _shape;
        private int _index;

        // test
        [TestInitialize]
        public void Setup()
        {
            _mockModel = new Mock<Model>();
            _shape = new Shape();
            _index = 0;
            _removeCommand = new DeleteCommand(_mockModel.Object, _shape, _index);
        }

        // test
        [TestMethod]
        public void ExecuteRemovesShapeAtGivenIndex()
        {
            _removeCommand.Execute();

            _mockModel.Verify(m => m.DeleteShapeByUndo(_index), Times.Once);
        }

        // test
        [TestMethod]
        public void UndoInsertsShapeAtGivenIndex()
        {
            _removeCommand.Undo();

            _mockModel.Verify(m => m.InsertShape(_shape, _index), Times.Once);
        }
    }
}