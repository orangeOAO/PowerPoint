using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using PowerPoint;
using System.Windows.Forms;
using System;
using PowerPoint.IState;
using System.Collections.Generic;
using PowerPoint.ShowModel;

namespace PPTests
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

        // test
        [TestMethod]
        public void HandleUndoRedoHistoryChangedTest()
        {
            bool isCalled = false;
            _showModel._undoRedoHistoryChanged += (test, test2) => { isCalled = true; };
            _showModel.HandleUndoRedoHistoryChanged(true, true);
            Assert.IsTrue(isCalled);
        }

        // test
        [TestMethod]
        public void HandlePropertyChangedTest()
        {
            // 创建对象实例
 

            // 设置 _isButtonChecked 数组
            _privateShowModel.SetField("_isButtonChecked", new bool[4] { false, false, false, true }); // 假设 ShapeType.ARROW 对应索引 3

            // 订阅 PropertyChanged 事件并记录触发次数和参数
            var propertyChangedEvents = new List<string>();
            _showModel.PropertyChanged += (sender, e) =>
            {
                propertyChangedEvents.Add(e.PropertyName);
            };

            // 调用方法
            _showModel.HandlePropertyChanged();

            // 验证 PropertyChanged 是否触发了四次
            Assert.AreEqual(4, propertyChangedEvents.Count);
            Assert.IsTrue(propertyChangedEvents.Contains(Constant.IS_LINE_CHECKED));
            Assert.IsTrue(propertyChangedEvents.Contains(Constant.IS_RECTANGLE_CHECKED));
            Assert.IsTrue(propertyChangedEvents.Contains(Constant.IS_CIRCLE_CHECKED));
            Assert.IsTrue(propertyChangedEvents.Contains(Constant.IS_MOUSE_CHECKED));
        }

        //test
        [TestMethod]
        [DataRow(ShapeType.LINE)]
        [DataRow(ShapeType.CIRCLE)]
        [DataRow(ShapeType.ARROW)]
        [DataRow(ShapeType.RECTANGLE)]
        public void SetState(ShapeType shapetype)
        {
            bool isCalled = false;
            _showModel._cursorChanged += (cursorType) => { isCalled = true; };
            _showModel.HandleStateChange(new SelectState());
            Assert.IsTrue(isCalled);
            isCalled = false;
            _showModel.HandleStateChange(new PointState());
            Assert.IsTrue(isCalled);
            isCalled = false;
            _showModel.HandleStateChange(new DrawingState(shapetype));
            Assert.IsTrue(isCalled);
            isCalled = false;
            _showModel.HandleStateChange(new ResizeState());
            Assert.IsTrue(isCalled);
            isCalled = false;
        }

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

            _showModel.HandleButtonClick(0);
            var button = (bool[])_privateShowModel.GetField("_isButtonChecked");
            Assert.AreEqual(true, button[0]);
            _showModel.HandleButtonClick((int)ShapeType.ARROW);
            button = (bool[])_privateShowModel.GetField("_isButtonChecked");
            Assert.AreEqual(true, button[(int)ShapeType.ARROW]);


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
            
            bool[] test = { false, false, true, false};
            _privateShowModel.SetField("_isButtonChecked",test);
            _showModel.ReleasedPointer(point);
            var button = (bool[])_privateShowModel.GetField("_isButtonChecked");
            Assert.IsTrue(button[(int)ShapeType.ARROW]);

        }

        //Resuze
        [TestMethod]
        public void ResizeTest()
        {
            _showModel.ResizeCanvas(100, 200);
            _mockModel.Verify(m => m.ResizeCanvas(100, 200), Times.Once());

        }

        //Resuze
        [TestMethod]
        public void ButtonDataBindingTest()
        {
            bool[] test = { true, true, true, true };
            _privateShowModel.SetField("_isButtonChecked", test);
            Assert.IsTrue(_showModel.IsCircleButtonChecked);
            Assert.IsTrue(_showModel.IsRectangleButtonChecked);
            Assert.IsTrue(_showModel.IsMouseButtonChecked);
            Assert.IsTrue(_showModel.IsLineButtonChecked);
        }

        //Resuze
        [TestMethod]
        public void RedoAndUndoTest()
        {
            _showModel.Undo();
            _mockModel.Verify(m => m.Undo(), Times.Once);

            _showModel.Redo();
            _mockModel.Verify(m => m.Redo(), Times.Once);
        }
    }
}