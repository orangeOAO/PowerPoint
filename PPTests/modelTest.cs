using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System.Drawing;
using System;
using System.ComponentModel;
using Moq;
using PowerPoint.IState;

namespace PPTests
{
    [TestClass]
    public class modelTest
    {
        private Model _model;
        private PrivateObject _privateModel;
        private Mock<IGraphics> _mockGraphics;

        //initialize
        [TestInitialize]
        public void Setup()
        {
            _model = new Model();
            _privateModel = new PrivateObject(_model);
            _mockGraphics = new Mock<IGraphics>();
        }

        //test
        [TestMethod]
        public void ModelTest_SetState()
        {
            
            var mockState = new Mock<State>();
            _model.SetState(mockState.Object);
            var currentState = _privateModel.GetField("_currentState");
            Assert.AreEqual(mockState.Object, currentState);
        }

        //test
        [TestMethod]
        public void ModelTest_HandleModelChange()
        {
            bool isCalled = false;
            _model._modelChanged += () => { isCalled = true; };
            _model.NotifyModelChanged();
            Assert.IsTrue(isCalled);
        }

        //test
        [TestMethod]
        public void ModelTest_NotifyStateChanged()
        {
            bool isCalled = false;
            PowerPoint.IState.PointState pointState = new PowerPoint.IState.PointState();
            _model._stateChanged += (state) => { isCalled = true; };
            _model.NotifyStateChanged(pointState);
            Assert.IsTrue(isCalled);
        }

        //test
        [TestMethod]
        public void ModelTest_CreateShape()
        {
            BindingList<Shape> _shapeList = new BindingList<Shape> { new Line(), new Circle(), new PowerPoint.Rectangle() };
            _model.CreateShape(ShapeType.LINE);
            _model.CreateShape(ShapeType.CIRCLE);
            _model.CreateShape(ShapeType.ARROW);
            Assert.AreEqual(3,_model.GetShapeCount());
        }

        //test
        [TestMethod]
        public void ModelTest_DeleteShape()
        {
            BindingList<Shape> _shapeList = new BindingList<Shape> { new Line(), new Circle()};
            _model.CreateShape(ShapeType.LINE);
            _model.CreateShape(ShapeType.CIRCLE);
            _model.CreateShape(ShapeType.RECTANGLE);
            _model.DeleteShape(2);
            Assert.AreEqual(2, _model.GetShapeCount());
        }

        //test
        [TestMethod]
        public void ModelTest_DeleteSelectShape()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.CreateShape(ShapeType.CIRCLE);
            _model._selectShapeIndex = 1;
            _model.DeleteSelectShape();
            Assert.AreEqual(1, _model.GetShapeCount());
            Assert.AreEqual(-1, _model._selectShapeIndex);
        }

        //test
        [TestMethod]
        public void ModelTest_IsSelected()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.GetShapes()[0].SetFirstPoint(new Point(3, 5));
            _model.GetShapes()[0].SetSecondPoint(new Point(30, 30));
            _model.GetShapes()[0].IsShapeSelected = true;
            _model.DetectInShape(new Point(10, 10));
            Assert.AreEqual(0, _model._selectShapeIndex);
            Assert.AreEqual(true, _model._moveShape);
            _model.DetectInShape(new Point(40, 40));
            Assert.AreEqual(-1, _model._selectShapeIndex);
            Assert.AreEqual(false, _model._moveShape);
        }

        //test
        [TestMethod]
        public void ModelTest_PressPointer()
        {
            var point = new Point(10, 10);
            _privateModel.SetField("_hint", new Shape());

            _privateModel.Invoke("PressedPointer", point, ShapeType.CIRCLE);

            Assert.AreEqual(point, ((Shape)_privateModel.GetField("_hint")).GetPoint1());
        }

        //test
        [TestMethod]
        public void ModelTest_MovePointer()
        {
            var point = new Point(10, 10);
            _privateModel.SetField("_hint", new Shape());

            _privateModel.Invoke("MovedPointer", point);

            Assert.AreEqual(point, ((Shape)_privateModel.GetField("_hint")).GetPoint2());
        }

        //test
        [TestMethod]
        public void ModelTest_ReleasePointer()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(2, 2);
            int initialCount = _model.GetShapes().Count;

            _model.PressedPointer(point1, ShapeType.LINE);
            _model.ReleasedPointer(point2, ShapeType.LINE);

            Assert.AreEqual(initialCount + 1, _model.GetShapes().Count);
        }

        //test
        [TestMethod]
        public void ModelTest_MoveShape()
        {
            var point = new Point(1, 1);
            _model.CreateShape(ShapeType.LINE);
            _model.GetShapes()[0].SetFirstPoint(point);
            _model.GetShapes()[0].SetSecondPoint(new Point(10, 10));
            _model.DetectInShape(new Point(4,4));

            var newPoint = new Point(7, 7);
            _model.MoveShape(newPoint);

            Assert.AreEqual(new Point(4,4), _model.GetShapes()[0].GetPoint1());
        }

        // test
        [TestMethod]
        public void ModelTest_DrawShapesTest()
        {
            _model.CreateShape(ShapeType.LINE);

            _privateModel.SetField("_firstPoint", new Point());

            _model.DrawShape(_mockGraphics.Object);

            _mockGraphics.Verify(graphics => graphics.DrawLine(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void ModelTest_DrawBoxTest()
        {
            _model.CreateShape(ShapeType.LINE);

            _model._selectShapeIndex = 0;

            _model.DrawBox(_mockGraphics.Object);

            _mockGraphics.Verify(graphics => graphics.DrawLineSelectBox(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }


        // test
        [TestMethod]
        public void ModelTest_DrawHitTest()
        {
            _privateModel.SetField("_hint", new Shape());

            _privateModel.Invoke("DrawHint", _mockGraphics.Object);

            _mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Never);
        }

        //test
        [TestMethod]
        public void ModelTest_ResizeShape()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.GetShapes()[0].SetFirstPoint(new Point(3, 5));
            _model.GetShapes()[0].SetSecondPoint(new Point(30, 30));
            _model.GetShapes()[0].IsShapeSelected = true;
            _model.ResizeShape(new Point(20, 20));
            Assert.AreEqual(20, _model.GetShapes()[0].GetPoint2().X);
            Assert.AreEqual(20, _model.GetShapes()[0].GetPoint2().Y);
        }

        //test
        [TestMethod]
        public void ModelTest_ChangeCursor()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.GetShapes()[0].SetFirstPoint(new Point(3, 5));
            _model.GetShapes()[0].SetSecondPoint(new Point(30, 30));
            Assert.AreEqual(true, _model.ChangeToResizeMode(new Point(30, 30)));
            Assert.AreEqual(false, _model.ChangeToResizeMode(new Point(20, 20)));
            Assert.AreEqual(false, _model.ChangeToResizeMode(new Point(40, 40)));
        }

        //test
        [TestMethod]
        public void ModelTest_ClearBox()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.CreateShape(ShapeType.CIRCLE);
            _model.CreateShape(ShapeType.RECTANGLE);
            foreach(var shape in _model.GetShapes())
            {
                shape.IsShapeSelected = true;
            }
            _model.ClearSelectBox();
            foreach (var shape in _model.GetShapes())
            {
                Assert.AreEqual(false, shape.IsShapeSelected);
            }
        }

        //test
        [TestMethod]
        public void ModelTest_Clear()
        {
            _model.CreateShape(ShapeType.LINE);
            _model.CreateShape(ShapeType.CIRCLE);
            _model.CreateShape(ShapeType.RECTANGLE);
            _model.Clear();
            Assert.AreEqual(0, _model.GetShapeCount());
        }

        //test
        [TestMethod]
        public void ModelTest_ResizeCanvas()
        {
            _privateModel.SetField("_canvasWidth",100);

            _privateModel.SetField("_shapesList", new BindingList<Shape> { new Line(new Point(10,10), new Point(20,20)), new Circle(new Point(10, 10), new Point(20, 20)), new PowerPoint.Rectangle(new Point(10, 10), new Point(20, 20)) });
            _model.ResizeCanvas(20, 100);
            Assert.AreEqual(new Point(2, 2),_model.GetShapes()[0].GetPoint1());
            Assert.AreEqual(new Point(4, 4), _model.GetShapes()[0].GetPoint2());
        }

        //test
        [TestMethod]
        public void ModelTest_GetState()
        {
            _privateModel.SetField("_currentState",new PowerPoint.IState.PointState());
            Assert.AreEqual(Model.ModelState.Normal, _model.GetState());
        }
    }
}
