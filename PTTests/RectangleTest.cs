using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPoint;
using System;

namespace PTTests
{
    [TestClass]
    public class RectangleTest
    {
        private Mock<IGraphics> _mockGraphics;
        private Circle _circle;

        //test
        [TestInitialize]
        public void Setup()
        {
            _mockGraphics = new Mock<IGraphics>();
            _circle = new Circle();
            _circle = new Circle(new Point(1, 1), new Point(2, 2));
        }
        [TestMethod]
        // test
        public void DrawTest()
        {
            _circle.Draw(_mockGraphics.Object);

            _mockGraphics.Verify(g => g.DrawCircle(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }

        // test
        [TestMethod]
        public void CircleTest_GetPoint()
        {
            var circle = new Circle(new Point(1, 1), new Point(5, 5));
            Assert.AreEqual(Constant.CIRCLE, circle.GetShapeName());
            Assert.AreEqual(new Point(1, 1), circle.GetPoint1());
            Assert.AreEqual(new Point(5, 5), circle.GetPoint2());
        }
    }
}
