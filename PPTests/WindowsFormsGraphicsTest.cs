using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using System.Windows.Forms;
using PowerPoint;
using PowerPoint.ShowModel;
using PowerPoint.IState;

namespace PPTests
{
    [TestClass]
    public class WindowsFormsGraphicsAdaptorTest
    {
        private WindowsGraphics _windowsFormsGraphicsAdaptor;
        // private Mock<Graphics> _mockGraphics;
        Graphics _graphics;
        
        // test
        [TestInitialize]
        public void Initialize()
        {
            // _mockGraphics = new Mock<Graphics>();
            _graphics = Graphics.FromImage(new Bitmap(1, 1));
            _windowsFormsGraphicsAdaptor = new WindowsGraphics(_graphics);
        }
        
        // test
        [TestMethod]
        public void ClearAllTest()
        {
            _windowsFormsGraphicsAdaptor.ClearAll();
        }

        // test
        [TestMethod]
        public void DrawLineTest()
        {
            _windowsFormsGraphicsAdaptor.DrawLine(new Pen(Color.Black), new Point(1, 1), new Point(2, 2));
            // _mockGraphics.Verify(g => g.DrawLine(It.IsAny<Pen>(), It.IsAny<Point>(), It.IsAny<Point>()), Times.Once);
        }
        
        // test
        [TestMethod]
        public void DrawLineTest_WithLineType()
        {
            _windowsFormsGraphicsAdaptor.DrawLine(new Pen(Color.Black), new Point(1, 1), new Point(2, 2));
        }
        
        // test
        [TestMethod]
        public void DrawRectangleTest()
        {
            _windowsFormsGraphicsAdaptor.DrawRectangle(new Pen(Color.Black), new Point(1, 1), new Point(2, 2));
            _windowsFormsGraphicsAdaptor.DrawRectangle(new Pen(Color.Black), new Point(2, 2), new Point(1, 1));
        }
        
        // test
        [TestMethod]
        public void DrawCircleeTest()
        {
            _windowsFormsGraphicsAdaptor.DrawCircle(new Pen(Color.Black), new Point(1, 1), new Point(2, 2));
        }
        
        // test
        [TestMethod]
        public void DrawSelectPointTest()
        {
            _windowsFormsGraphicsAdaptor.DrawCircleSelectBox(new Point(1, 1), new Point(1, 1));
            _windowsFormsGraphicsAdaptor.DrawLineSelectBox(new Point(2, 2), new Point(1, 1));
            _windowsFormsGraphicsAdaptor.DrawCircleSelectBox(new Point(2, 2), new Point(1, 1));
        }
        
        // test
        [TestMethod]
        public void DrawSelectTest()
        {
            _windowsFormsGraphicsAdaptor.DrawRectangleSelectBox(new Point(2, 2), new Point(1, 1));
        }
    }
}