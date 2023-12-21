using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using PowerPoint;
using System.Windows.Forms;
using System;
using PowerPoint.IState;

namespace PowerPoint.ShowModel.Tests
{
    [TestClass]
    public class PresentationModelTests
    {
        private Mock<Model> _mockModel;
        private ShowModel _showModel;
        PrivateObject _privateShowModel;

        // test
        [TestInitialize]
        public void Setup()
        {
            _mockModel = new Mock<Model>();
            _showModel = new ShowModel(_mockModel.Object);
            _privateShowModel = new PrivateObject(_showModel);
        }

        // test
        [TestMethod]
        public void HandleModelChangedTest()
        {
            bool isCalled = false;
            _showModel._modelChanged += () => { isCalled = true; };
            _showModel.HandleModelChanged();
            Assert.IsTrue(isCalled);
        }

        ////test
        //[TestMethod]
        //public void SetState()
        //{
        //    State _state = new DrawingState(ShapeType.RECTANGLE);
        //    _showModel.SetState(_state);
        //    Assert.AreEqual(Model.ModelState.Drawing, _showModel.GetCurrentState());
        //    _state = new PointState();
        //    _showModel.SetState(_state);
        //    Assert.AreEqual(Model.ModelState.Normal, _showModel.GetCurrentState());
        //}

        //test
        [TestMethod]
        public void ModelClearTest()
        {
            _showModel.Clear();
            _mockModel.Verify(m => m.Clear(), Times.Once);
        }

        // test
        [TestMethod]
        public void GetShapesTest()
        {
            _showModel.GetShapes();
            _mockModel.Verify(m => m.GetShapes(), Times.Once);
        }

        // test
        [TestMethod]
        public void CreateShapeTest()
        {
            _showModel.InsertShape(ShapeType.LINE);

            _mockModel.Verify(m => m.CreateShape(ShapeType.LINE), Times.Once);
        }

        // test
        [TestMethod]
        public void DeleteShapeTest()
        {
            _showModel.DeleteShape(1);

            _mockModel.Verify(m => m.DeleteShape(1), Times.Once);
        }

        // test
        [TestMethod]
        public void DeleteSelectShapeTest()
        {
            
            _showModel.DeleteSelectShape();
            
            
            _mockModel.Verify(m => m.DeleteSelectShape(), Times.Once);
        }

        // test
        [TestMethod]
        public void HandleButtonClickTest()
        {
            ToolStripButton _lineButton = new ToolStripButton();
            ToolStripButton _circleButton = new ToolStripButton();
            ToolStripButton _rectangleButton = new ToolStripButton();
            ToolStripButton _selectButton = new ToolStripButton();
            ToolStripButton[] buttonArray = {_lineButton, _rectangleButton, _circleButton, _selectButton };
            //_showModel.HandleButtonClick(buttonArray,3);

            Assert.AreEqual(true, buttonArray[3].Checked);
        }

        // test
        [TestMethod]
        public void ReleaseButtonClickTest()
        {
            ToolStripButton _lineButton = new ToolStripButton();
            ToolStripButton _circleButton = new ToolStripButton();
            ToolStripButton _rectangleButton = new ToolStripButton();
            ToolStripButton _selectButton = new ToolStripButton();
            _lineButton.Checked = true;
            ToolStripButton[] buttonArray = { _lineButton, _rectangleButton, _circleButton, _selectButton };
            //_showModel.ReleaseButtonClick(buttonArray);

            foreach(var button in buttonArray)
            {
                Assert.AreEqual(false, button.Checked);
            }
            
        }

        //test
        //[TestMethod]
        //public void ChangeCursorTest()
        //{
        //    Point point = new Point(10, 10);
        //    _mockModel.Setup(m => m.DecideToChangeCursor(It.IsAny<Point>())).Returns(true);
        //    _showModel.ChangeCursor(point);
        //    Assert.AreEqual(Model.ModelState.Resize, _showModel.GetCurrentState());

        //    _mockModel.Setup(m => m.DecideToChangeCursor(It.IsAny<Point>())).Returns(false);

        //    //// 模擬一組形狀，其中一個被選中
        //    var _selectedShape = new Mock<Shape>();
        //    _selectedShape.Setup(s => s.IsShapeSelected).Returns(true);

        //    var _unselectedShape = new Mock<Shape>();
        //    _unselectedShape.Setup(s => s.IsShapeSelected).Returns(false);

        //    _mockModel.Setup(m => m.GetShapes()).Returns(new System.ComponentModel.BindingList<Shape> { _selectedShape.Object, _unselectedShape.Object });
        //    _showModel.ChangeCursor(point);
        //    Assert.AreEqual(Model.ModelState.Select, _showModel.GetCurrentState());

        //}

        //Press
        [TestMethod]
        public void PressedPointerTest()
        {
            var point = new Point(10, 10);
            var mockState = new Mock<State>();
            _showModel.PressedPointer(point);
            mockState.Object.PressedPointer(_mockModel.Object, point);
            mockState.Verify(m => m.PressedPointer(It.IsAny<Model>(), It.IsAny<Point>()), Times.Once);
        }

        //ClearSelectBox
        [TestMethod]
        public void ClearSelectBoxTest()
        {
            var point = new Point(10, 10);
            var mockState = new Mock<State>();
            _showModel.ClearSelectBox();
            _mockModel.Verify(m => m.ClearSelectBox(), Times.Once);
        }

        //Move
        [TestMethod]
        public void MovedPointerTest()
        {
            var point = new Point(10, 10);
            var mockState = new Mock<State>();
            _showModel.MovedPointer(point);
            mockState.Object.MovedPointer(_mockModel.Object, point, true);
            mockState.Verify(m => m.MovedPointer(It.IsAny<Model>(), It.IsAny<Point>(), true), Times.Once);
        }

        //Release
        [TestMethod]
        public void ReleasedPointerTest()
        {
            var point = new Point(10, 10);
            var mockState = new Mock<State>();
            _showModel.ReleasedPointer(point);
            mockState.Object.ReleasedPointer(_mockModel.Object, point);
            mockState.Verify(m => m.ReleasedPointer(It.IsAny<Model>(), It.IsAny<Point>()), Times.Once);
        }
    }
}