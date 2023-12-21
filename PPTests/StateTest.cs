using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPoint;
using PowerPoint.IState;
using PowerPoint.ShowModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTests
{
    [TestClass]
    public class StateTest
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
        //// test
        [TestMethod]
        public void Drawing_DrawTest()
        {
            // 假設 DrawingState 的建構子接受一個 ShapeType 參數
            State _state = new DrawingState(ShapeType.LINE);

            // 使用 Moq 設定 _mockModel 的 DrawShape 方法
            _mockModel.Setup(m => m.DrawShape(It.IsAny<WindowsGraphics>()));

            // 設定 _showModel 的狀態
            _showModel.SetState(_state);

            // 執行繪圖操作
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(100, 100));
            _showModel.Draw(graphics);

            // 驗證 DrawShape 是否被呼叫
            _mockModel.Verify(m => m.DrawShape(It.IsAny<WindowsGraphics>()), Times.Once);
        }

        //// test
        [TestMethod]
        public void Resize_DrawTest()
        {
            // 假設 DrawingState 的建構子接受一個 ShapeType 參數
            State _state = new ResizeState();

            // 使用 Moq 設定 _mockModel 的 DrawShape 方法
            _mockModel.Setup(m => m.DrawShape(It.IsAny<WindowsGraphics>()));
            _mockModel.Setup(m => m.DrawBox(It.IsAny<WindowsGraphics>()));

            // 設定 _showModel 的狀態
            _showModel.SetState(_state);

            // 執行繪圖操作
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(100, 100));
            _showModel.Draw(graphics);

            // 驗證 DrawShape 是否被呼叫
            _mockModel.Verify(m => m.DrawShape(It.IsAny<WindowsGraphics>()), Times.Once);
            _mockModel.Verify(m => m.DrawBox(It.IsAny<WindowsGraphics>()), Times.Once);
        }

        //// test
        [TestMethod]
        public void Point_DrawTest()
        {
            // 假設 DrawingState 的建構子接受一個 ShapeType 參數
            State _state = new PointState();

            // 使用 Moq 設定 _mockModel 的 DrawShape 方法
            _mockModel.Setup(m => m.DrawShape(It.IsAny<WindowsGraphics>()));

            // 設定 _showModel 的狀態
            _showModel.SetState(_state);

            // 執行繪圖操作
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(100, 100));
            _showModel.Draw(graphics);

            // 驗證 DrawShape 是否被呼叫
            _mockModel.Verify(m => m.DrawShape(It.IsAny<WindowsGraphics>()), Times.Once);
        }

        //// test
        [TestMethod]
        public void Select_DrawTest()
        {
            // 假設 DrawingState 的建構子接受一個 ShapeType 參數
            State _state = new SelectState();

            // 使用 Moq 設定 _mockModel 的 DrawShape 方法
            _mockModel.Setup(m => m.DrawShape(It.IsAny<WindowsGraphics>()));
            _mockModel.Setup(m => m.DrawBox(It.IsAny<WindowsGraphics>()));

            // 設定 _showModel 的狀態
            _showModel.SetState(_state);

            // 執行繪圖操作
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(100, 100));
            _showModel.Draw(graphics);

            // 驗證 DrawShape 是否被呼叫
            _mockModel.Verify(m => m.DrawShape(It.IsAny<WindowsGraphics>()), Times.Once);
            _mockModel.Verify(m => m.DrawBox(It.IsAny<WindowsGraphics>()), Times.Once);
        }

        // test
        [TestMethod]
        public void SelectState_PressedPointerTest()
        {
            var selectState = new SelectState();
            Point _testPoint = new Point(1, 1);
            selectState.PressedPointer(_mockModel.Object, _testPoint);
            _mockModel.Verify(m => m.DetectInShape(_testPoint), Times.Once);
        }

        // test
        [TestMethod]
        public void PointState_PressedPointerTest()
        {
            var pointState = new PointState();
            Point _testPoint = new Point(1, 1);

            pointState.PressedPointer(_mockModel.Object, _testPoint);
            _mockModel.Verify(m => m.DetectInShape(_testPoint), Times.Once);
        }

        // test
        [TestMethod]
        public void DrawingState_PressedPointerTest()
        {
            var shape = ShapeType.RECTANGLE;
            var drawingState = new DrawingState(shape);
            Point _testPoint = new Point(1, 1);
            drawingState.PressedPointer(_mockModel.Object, _testPoint);
            _mockModel.Verify(m => m.PressedPointer(_testPoint, shape), Times.Once);
        }

        // test
        [TestMethod]
        public void ResizeState_PressedPointerTest()
        {
            var resizeState = new ResizeState();
            Point _testPoint = new Point(1, 1);

            resizeState.MovedPointer(_mockModel.Object, _testPoint, true);
            Assert.AreEqual(true, _mockModel.Object._resizeShape);
        }

        //test
        [TestMethod]
        public void Select_MovedPointerTest()
        {
            var selectState = new SelectState();
            var point = new Point(10, 10);
            selectState.MovedPointer(_mockModel.Object, point, true);
            // 驗證 MovedPointer 方法是否在適當的條件下被呼叫
            _mockModel.Verify(m => m.MoveShape(It.IsAny<Point>()), Times.Once);

        }

        //test
        [TestMethod]
        public void Resize_MovedPointerTest()
        {
            var resizeState = new ResizeState();
            var point = new Point(10, 10);
            resizeState.MovedPointer(_mockModel.Object, point, true);
            _mockModel.Verify(m => m.ResizeShape(It.IsAny<Point>()), Times.Once);

        }

        //test
        [TestMethod]
        public void Drawing_MovedPointerTest()
        {
            var drawingState = new DrawingState(ShapeType.LINE);
            var point = new Point(10, 10);

            drawingState._isPressed = true;
            drawingState.MovedPointer(_mockModel.Object, point, true);

            _mockModel.Verify(m => m.MovedPointer(It.IsAny<Point>()), Times.Once);
        }

        //test
        [TestMethod]
        public void Point_MovedPointerTest()
        {
            var pointState = new PointState();
            var point = new Point(10, 10);

            pointState.MovedPointer(_mockModel.Object, point, true);

            _mockModel.Verify(m => m.MoveShape(It.IsAny<Point>()), Times.Once);

        }

        //test
        [TestMethod]
        public void Select_ReleasedPointerTest()
        {
            var point = new Point(1, 1);

            var state = new SelectState();
            state.ReleasedPointer(_mockModel.Object, point);


            Assert.AreEqual(false, _mockModel.Object._moveShape);
        }

        //test
        [TestMethod]
        public void Resize_ReleasedPointerTest()
        {
            var point = new Point(1, 1);

            var state = new ResizeState();
            state.ReleasedPointer(_mockModel.Object, point);


            Assert.AreEqual(false, _mockModel.Object._moveShape);
            Assert.AreEqual(false, _mockModel.Object._resizeShape);
        }

        //test
        [TestMethod]
        public void Point_ReleasedPointerTest()
        {
            var point = new Point(1, 1);

            var state = new PointState();
            state.ReleasedPointer(_mockModel.Object, point);


            Assert.AreEqual(false, _mockModel.Object._moveShape);
        }

        //test
        [TestMethod]
        public void Drawing_ReleasedPointerTest()
        {
            var point = new Point(1, 1);

            var state = new DrawingState(ShapeType.CIRCLE);
            state._isPressed = true;
            state.ReleasedPointer(_mockModel.Object, point);


            Assert.AreEqual(false, _mockModel.Object._moveShape);
        }

        //test
        [TestMethod]
        public void Drawing_GetState()
        {
            var point = new Point(1, 1);

            var state = new DrawingState(ShapeType.CIRCLE);

            Assert.AreEqual(Model.ModelState.Drawing, state.GetState());
        }

        //test
        [TestMethod]
        public void Point_GetState()
        {
            var point = new Point(1, 1);

            var state = new PointState();

            Assert.AreEqual(Model.ModelState.Normal, state.GetState());
        }

        //test
        [TestMethod]
        public void Select_GetState()
        {
            var point = new Point(1, 1);

            var state = new SelectState();

            Assert.AreEqual(Model.ModelState.Select, state.GetState());
        }

        //test
        [TestMethod]
        public void Resize_GetState()
        {
            var point = new Point(1, 1);

            var state = new ResizeState();

            Assert.AreEqual(Model.ModelState.Resize, state.GetState());
        }
    }
}
