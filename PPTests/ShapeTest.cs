using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PowerPoint;
using System.Drawing;
using Moq;

namespace PTTests
{
    [TestClass]
    public class ShapeTest
    {
        private Mock<IGraphics> _mockGraphics;
        private Circle _circle;
        private PowerPoint.Rectangle _rectangle;
        private Line _line;
       

        //test
        [TestInitialize]
        public void Setup()
        {
            _mockGraphics = new Mock<IGraphics>();
            _circle = new Circle(new Point(1, 1), new Point(2, 2));
            _line = new Line(new Point(1, 1), new Point(2, 2));
            _rectangle = new PowerPoint.Rectangle(new Point(1, 1), new Point(2, 2));
        }
        // test
        [TestMethod]
        public void CreateTest()
        {
            
        }

        // test
        [TestMethod]
        public void CircleDrawTest()
        {
            _circle.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void RectangleDrawTest()
        {
            _rectangle.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawRectangle(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void LineDrawTest()
        {
            _line.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawLine(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void CircleDrawBoxTest()
        {
            var test = new Shape();
            test.DrawBox(_mockGraphics.Object);
            _circle.DrawBox(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawCircleSelectBox(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void RectangleDrawBoxTest()
        {
            _rectangle.DrawBox(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawRectangleSelectBox(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void LineDrawBoxTest()
        {
            _line.DrawBox(_mockGraphics.Object);
            _mockGraphics.Verify(g => g.DrawLineSelectBox(It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void CircleTest_GetPoint()
        {
            var circle = new Circle(new Point(1, 1), new Point(5, 5));
            Assert.AreEqual(Constant.CIRCLE, circle.GetShapeName());
            Assert.AreEqual(new Point(1,1), circle.GetPoint1());
            Assert.AreEqual(new Point(5,5), circle.GetPoint2());
        }


        //test
        [TestMethod]
        public void RectangleTest_GetPoint()
        {
            var rectangle = new PowerPoint.Rectangle(new Point(1, 1), new Point(5, 5));
            Assert.AreEqual(Constant.RECTANGLE, rectangle.GetShapeName());
            Assert.AreEqual(new Point(1, 1), rectangle.GetPoint1());
            Assert.AreEqual(new Point(5, 5), rectangle.GetPoint2());
        }

        //test
        [TestMethod]
        public void LineTest_GetPoint()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(5, 5));
            Assert.AreEqual(Constant.LINE, line.GetShapeName());
            Assert.AreEqual(new Point(1, 1), line.GetPoint1());
            Assert.AreEqual(new Point(5, 5), line.GetPoint2());
        }

        //test
        [TestMethod]
        public void LineTest_InResizeShape_WhenPoint1IsGreaterThanPoint2()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(10, 10));
            Assert.AreEqual(true,line.GetInResizeShape(new Point(10,10)));
            Assert.AreEqual(false, line.GetInResizeShape(new Point(3,3)));
        }

        //test
        [TestMethod]
        public void LineTest_InSResizehape_WhenPoint1IsSmallerThanPoint2()
        {
            var line = new PowerPoint.Line(new Point(5, 5), new Point(1, 1));

            Assert.AreEqual(true, line.GetInResizeShape(new Point(5, 5)));
            Assert.AreEqual(false, line.GetInResizeShape(new Point(1, 5)));
        }

        //test
        [TestMethod]

        public void LineTest_IsSelected()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            line.IsShapeSelected = true;
            Assert.AreEqual(true, line.GetInShape(new Point(20, 20)));
            line.IsShapeSelected = false;
            Assert.AreEqual(false, line.GetInShape(new Point(36, 36)));
            line.IsShapeSelected = true;
            Assert.AreEqual(false, line.GetInShape(new Point(37, 37)));
            line.IsShapeSelected = false;
            Assert.AreEqual(false, line.GetInShape(new Point(37, 37)));
        }

        //test
        [TestMethod]
        public void TransformCoordinate_Test()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            var shapeName = line._shape;
            //PrivateObject privateObject = new PrivateObject(line);
            //privateObject.GetField("")
            Assert.AreEqual("(1, 1), (30, 30)", line._information);
            Assert.AreEqual("線", shapeName);
            Assert.AreEqual("線", line.GetShapeName());
            Assert.AreEqual("(1, 1), (30, 30)", line.GetInfo());
        }

        //test
        [TestMethod]
        public void SetPoint_Test()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            line.SetFirstPoint(new Point(10, 20));
            line.SetSecondPoint(new Point(40, 40));
            Assert.AreEqual("(10, 20), (40, 40)", line._information);
        }

        //test
        [TestMethod]
        public void TestLineMoveCalculate()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            var privateObject = new PrivateObject(line, new PrivateType(typeof(PowerPoint.Shape)));
            line.SetTemporaryPoint();
            privateObject.SetField("_pointSelect", new Point(10, 10));
            line.MoveCalculate(new Point(15, 15));

            Assert.AreEqual("{X=6,Y=6}", line.GetPoint1().ToString());
            Assert.AreEqual("{X=35,Y=35}", line.GetPoint2().ToString());
        }

        //test
        [TestMethod]
        public void TestSetResizeShapePoint()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            line.SetResizeShapePoint(new Point(20, 20));
            Assert.AreEqual("{X=20,Y=20}", line.GetPoint2().ToString());
        }

        //test
        [TestMethod]
        public void TestScale()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            line.Scale((float)0.5);
            Assert.AreEqual("{X=15,Y=15}", line.GetPoint2().ToString());
        }

        //test
        [TestMethod]
        public void TestisSelected()
        {
            var line = new PowerPoint.Line(new Point(1, 1), new Point(30, 30));
            var circle = new PowerPoint.Shape();
            circle.SetFirstPoint(new Point(1, 1));
            circle.SetSecondPoint(new Point(2, 2));
            line.IsShapeSelected = false;
            Assert.AreEqual(false, line.IsShapeSelected);
            Assert.AreEqual(new Point(1, 1), circle.GetPoint1());
            Assert.AreEqual(new Point(2, 2), circle.GetPoint2());
        }

        //test
        [TestMethod]
        public void TestShape()
        {
            var line = new PowerPoint.Line();
            var circle = new PowerPoint.Circle();
            var rectangle = new PowerPoint.Rectangle();
            line.SetFirstPoint(new Point(1, 1));
            line.SetSecondPoint(new Point(2, 2));
            circle.SetFirstPoint(new Point(1, 1));
            circle.SetSecondPoint(new Point(2, 2));
            rectangle.SetFirstPoint(new Point(3, 3));
            rectangle.SetSecondPoint(new Point(4, 4));
            line.IsShapeSelected = false;
            Assert.AreEqual(false, line.IsShapeSelected);
            Assert.AreEqual(new Point(1, 1), line.GetPoint1());
            Assert.AreEqual(new Point(2, 2), line.GetPoint2());
            Assert.AreEqual(new Point(1, 1), circle.GetPoint1());
            Assert.AreEqual(new Point(2, 2), circle.GetPoint2());
            Assert.AreEqual(new Point(3, 3), rectangle.GetPoint1());
            Assert.AreEqual(new Point(4, 4), rectangle.GetPoint2());
        }

        //test
        [TestMethod]
        public void TestMoveShapeBybias()
        {
            var line = new PowerPoint.Line();
            line.SetFirstPoint(new Point(1, 1));
            line.SetSecondPoint(new Point(2, 2));

            line.MoveShapeByBias(new Size(10, 10));

            Assert.AreEqual(new Point(11, 11), line.GetPoint1());
            Assert.AreEqual(new Point(12, 12), line.GetPoint2());
            
        }


    }
}
