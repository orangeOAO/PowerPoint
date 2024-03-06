using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using PowerPoint;
using PointerInputDevice = OpenQA.Selenium.Interactions.PointerInputDevice;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;

namespace PPTests
{
    [TestClass]
    public class PowerPointTests
    {

        private const string CIRCLE = "◯";
        private const string RECTANGLE = "⬜";
        private const string LINE = "╱";
        private const string PANEL1 = "_drawPanel";
        private const string UNDO = "↶";
        private const string REDO = "↷";
        const string MENU_FORM = "Form1";
        const string DATA_GRID = "_dataGridView1";
        const string SHAPE_CHINESE = "形狀";
        const string INFO_CHINESE = "資訊";
        const string DELETE_CHINESE = "刪除";
        const string CIRCLE_CHINESE = "圓形";
        const string RECTANGLE_CHINESE = "矩形";
        const string LINE_CHINESE = "線";
        const string NEW_CHINESE = "新增";

        private Robot _robot;
        private WindowsElement _canvas;
        private WindowsElement _flowLayoutPanel1;
        private Random _random;
        //n
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "PowerPoint";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
            var targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "PowerPoint.exe");
            // Assert.AreEqual("hi", targetAppPath);
            _robot = new Robot(targetAppPath, MENU_FORM);
            _random = new Random();
            _flowLayoutPanel1 = _robot.FindElementById("_pagePanel");
            _canvas = _robot.FindElementById(PANEL1);
        }

        //aa
        public IReadOnlyCollection<AppiumWebElement> GetSlide()
        {
            return _flowLayoutPanel1.FindElementsByAccessibilityId("OAO");
            // return _robot.FindElementById(FLOW_LAYOUT_PANEL1)
            // .FindElementsByClassName("WindowsForms10.Window.8.app.0.141b42a_r8_ad1");
        }

        // get info
        public string GetInfo(Point point1, Point point2)
        {
            return FormatCoordinate(point1) + Constant.COMMA + FormatCoordinate(point2);
        }
        
        // format coordinate
        private string FormatCoordinate(PointF point)
        {
            return Constant.LEFT + (int)point.X + Constant.COMMA + (int)point.Y + Constant.RIGHT;
        }
        
        // test
        public Interaction CreateMoveTo(PointerInputDevice device, int x, int y)
        {
            var size = _canvas.Size;
            return device.CreatePointerMove(_canvas, x - size.Width/2 , y-size.Height/2 , TimeSpan.Zero);
        }
        
        // draw
        public void DrawShape(string shapeName, Point leftTop, Point rightBottom)
        {
            _canvas = _robot.FindElementById(PANEL1);
            _robot.ClickByElementName(shapeName);
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointer = new PointerInputDevice(PointerKind.Pen);
            actionBuilder
                .AddAction(CreateMoveTo(pointer, leftTop.X, leftTop.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, rightBottom.X, rightBottom.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
        }

        // get state
        public AccessibleStates GetButtonState(string name)
        {
            string stateValue = _robot.FindElementByName(name).GetAttribute("LegacyState");
            return (AccessibleStates)Enum.Parse(typeof(AccessibleStates), stateValue);
        }

        // test
        [TestCleanup]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // test
        [TestMethod]
        public void TestCircle()
        {
            //Assert.AreEqual(_canvas.Size, new Size(100, 100));
            try
            {
                _robot.ClickByElementName(CIRCLE);
                Point point1 = new Point(10, 10);
                Point point2 = new Point(200, 200);
                //point1 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
                //point2 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
                Assert.AreEqual(AccessibleStates.Checked, GetButtonState(CIRCLE) & AccessibleStates.Checked);
                DrawShape(CIRCLE, point1, point2);
                //Debug.Print(_robot.FindElementByName(SHAPE_CHINESE).Text);
                Assert.AreEqual(CIRCLE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);

                Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
                _robot.ClickByElementName(DELETE_CHINESE + " 資料列 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("测试中出现异常: " + ex.ToString());
                throw; // 重新抛出异常，以便测试框架可以捕获它
            }

        }

        //    // test
        [TestMethod]
        public void TestRectangle()
        {
            _robot.ClickByElementName(RECTANGLE);
            Point point1 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            Point point2 = new Point(Constant.TWO_HUNDRED, Constant.TWO_HUNDRED);
            //point1 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
            //point2 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
            Assert.AreEqual(AccessibleStates.Checked, GetButtonState(RECTANGLE) & AccessibleStates.Checked);
            DrawShape(RECTANGLE, point1, point2);
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
            Assert.AreEqual(RECTANGLE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);
            _robot.ClickByElementName(DELETE_CHINESE + " 資料列 0");
        }

        // test
        [TestMethod]
        public void TestLine()
        {
            _robot.ClickByElementName(LINE);
            Point point1 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            Point point2 = new Point(Constant.TWO_HUNDRED, Constant.TWO_HUNDRED);
            //point1 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
            //point2 = new Point(point1.X * 10 / 8, point2.Y * 10 / 8);
            Assert.AreEqual(AccessibleStates.Checked, GetButtonState(LINE) & AccessibleStates.Checked);
            DrawShape(LINE, point1, point2);
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
            Assert.AreEqual(LINE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);
            _robot.ClickByElementName(DELETE_CHINESE + " 資料列 0");
        }

        // test
        [TestMethod]
        public void TestDataGridViewCircle()
        {
            Point point1 = new Point(_random.Next(0, _canvas.Size.Width), _random.Next(0, _canvas.Size.Height));
            Point point2 = new Point(_random.Next(point1.X, _canvas.Size.Width), _random.Next(point1.Y, _canvas.Size.Height));
            _robot.FindElementByName("開啟").Click();
            _robot.FindElementByName(CIRCLE_CHINESE).Click();
            _robot.ClickByElementName(NEW_CHINESE);
            _robot.FindElementByName(Constant.TOP_LEFT_X).SendKeys(point1.X.ToString());
            _robot.FindElementByName(Constant.TOP_LEFT_Y).SendKeys(point1.Y.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_X).SendKeys(point2.X.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_Y).SendKeys(point2.Y.ToString());
            _robot.FindElementByName("OK").Click();
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
            Assert.AreEqual(CIRCLE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);

        }
        //// test
        [TestMethod]
        public void TestDataGridViewRectangle()
        {
            Point point1 = new Point(_random.Next(0, _canvas.Size.Width), _random.Next(0, _canvas.Size.Height));
            Point point2 = new Point(_random.Next(point1.X, _canvas.Size.Width), _random.Next(point1.Y, _canvas.Size.Height));
            _robot.FindElementByName("開啟").Click();
            _robot.FindElementByName(RECTANGLE_CHINESE).Click();
            _robot.ClickByElementName(NEW_CHINESE);
            _robot.FindElementByName(Constant.TOP_LEFT_X).SendKeys(point1.X.ToString());
            _robot.FindElementByName(Constant.TOP_LEFT_Y).SendKeys(point1.Y.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_X).SendKeys(point2.X.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_Y).SendKeys(point2.Y.ToString());
            _robot.FindElementByName("OK").Click();
        }

        // test
        [TestMethod]
        public void TestDataGridViewLine()
        {
            Point point1 = new Point(_random.Next(0, _canvas.Size.Width), _random.Next(0, _canvas.Size.Height));
            Point point2 = new Point(_random.Next(point1.X, _canvas.Size.Width), _random.Next(point1.Y, _canvas.Size.Height));
            _robot.FindElementByName("開啟").Click();
            _robot.FindElementByName(LINE_CHINESE).Click();
            _robot.ClickByElementName(NEW_CHINESE);
            _robot.FindElementByName(Constant.TOP_LEFT_X).SendKeys(point1.X.ToString());
            _robot.FindElementByName(Constant.TOP_LEFT_Y).SendKeys(point1.Y.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_X).SendKeys(point2.X.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_Y).SendKeys(point2.Y.ToString());
            _robot.FindElementByName("OK").Click();
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
        }

        //// test
        [TestMethod]
        public void TestMoveShape()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            Point middlePoint = new Point((point1.X + point2.X) / Constant.TWO, (point1.Y + point2.Y) / Constant.TWO);
            DrawShape(CIRCLE, point1, point2);
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointer = new PointerInputDevice(PointerKind.Pen);
            actionBuilder
                .AddAction(CreateMoveTo(pointer, point1.X, point1.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, point2.X, point2.Y))
                .AddAction(CreateMoveTo(pointer, point2.X, point2.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, middlePoint.X, middlePoint.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, middlePoint.X + Constant.ONE_HUNDRED, middlePoint.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
            Assert.AreEqual(GetInfo(new Point(Constant.ONE_HUNDRED+10, 10), new Point(Constant.TWO_HUNDRED, Constant.ONE_HUNDRED)), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
        }

        //// test
        [TestMethod]
        public void TestDrawUndoRedo()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            DrawShape(CIRCLE, point1, point2);
            _robot.FindElementByName(UNDO).Click();
            Assert.AreEqual("0", _robot.FindElementById(DATA_GRID).GetAttribute("Grid.RowCount"));
            _robot.FindElementByName(REDO).Click();
            Assert.AreEqual(CIRCLE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
        }

        //// test
        [TestMethod]
        public void TestMoveUndoRedo()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            Point middlePoint = new Point((point1.X + point2.X) / Constant.TWO, (point1.Y + point2.Y) / Constant.TWO);
            DrawShape(CIRCLE, point1, point2);
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointer = new PointerInputDevice(PointerKind.Pen);
            actionBuilder
                .AddAction(CreateMoveTo(pointer, point1.X, point1.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, point2.X, point2.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, middlePoint.X, middlePoint.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, middlePoint.X + Constant.ONE_HUNDRED, middlePoint.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
            _robot.FindElementByName(UNDO).Click();
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
            _robot.FindElementByName(REDO).Click();
            Assert.AreEqual(GetInfo(new Point(Constant.ONE_HUNDRED+10, 10), new Point(Constant.TWO_HUNDRED, Constant.ONE_HUNDRED)), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
        }

        //// test
        //[TestMethod]
        public void TestDataGridViewUndoRedo()
        {
            Point point1 = new Point(_random.Next(0, _canvas.Size.Width), _random.Next(0, _canvas.Size.Height));
            Point point2 = new Point(_random.Next(point1.X, _canvas.Size.Width), _random.Next(point1.Y, _canvas.Size.Height));
            _robot.FindElementByName("開啟").Click();
            _robot.FindElementByName(CIRCLE_CHINESE).Click();
            _robot.ClickByElementName(NEW_CHINESE);
            _robot.FindElementByName(Constant.TOP_LEFT_X).SendKeys(point1.X.ToString());
            _robot.FindElementByName(Constant.TOP_LEFT_Y).SendKeys(point1.Y.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_X).SendKeys(point2.X.ToString());
            _robot.FindElementByName(Constant.BOTTOM_RIGHT_Y).SendKeys(point2.Y.ToString());
            _robot.FindElementByName("OK").Click();
            _robot.FindElementByName(UNDO).Click();
            _robot.FindElementByName(REDO).Click();
            Assert.AreEqual(GetInfo(point1, point2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);
            Assert.AreEqual(CIRCLE_CHINESE, _robot.FindElementByName(SHAPE_CHINESE + " 資料列 0").Text);

        }

        ////    // test
        [TestMethod]
        public void TestResizeUndoRedo()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);
            Point newPoint2 = new Point(Constant.TWO_HUNDRED, Constant.TWO_HUNDRED);
            Point middlePoint = new Point((point1.X + point2.X) / Constant.TWO, (point1.Y + point2.Y) / Constant.TWO);
            DrawShape(CIRCLE, point1, point2);
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointer = new PointerInputDevice(PointerKind.Pen);
            actionBuilder
                .AddAction(CreateMoveTo(pointer, point2.X, point2.Y))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left))
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, Constant.TWO_HUNDRED, Constant.TWO_HUNDRED))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, middlePoint.X, middlePoint.Y))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
            _robot.Sleep(1.0);
            _robot.FindElementByName(UNDO).Click();
            _robot.FindElementByName(REDO).Click();
            Assert.AreEqual(GetInfo(point1, newPoint2), _robot.FindElementByName(INFO_CHINESE + " 資料列 0").Text);

        }
        //test
        [TestMethod]
        public void TestSplitContainer()
        {
            Point point1 = new Point(10, 10);
            Point point2 = new Point(Constant.ONE_HUNDRED, Constant.ONE_HUNDRED);

            
            _robot.FindElementByName("_splitContainerRight").Click();
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointer = new PointerInputDevice(PointerKind.Pen);
            actionBuilder
                .AddAction(pointer.CreatePointerDown(MouseButton.Left))
                .AddAction(CreateMoveTo(pointer, Constant.TWO_HUNDRED, Constant.TWO_HUNDRED))
                .AddAction(pointer.CreatePointerUp(MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
            _robot.Sleep(1.0);
            Assert.AreEqual(_robot.FindElementByName("_splitContainerRight").Size.Height/ _robot.FindElementByName("_splitContainerRight").Size.Width,9/16);

        }

        //page
        [TestMethod]
        public void TestPageAdd()
        {
            _robot.ClickByElementName("+");
            Assert.AreEqual(2, GetSlide().Count);
        }

        // test
        [TestMethod]
        public void TestNewDeletePage()
        {
            _robot.ClickByElementName("+");
            Assert.AreEqual(2, GetSlide().Count);
            Actions actions = new Actions(_robot.GetDriver());
            actions.SendKeys(OpenQA.Selenium.Keys.Delete).Perform();
            Assert.AreEqual(1, GetSlide().Count);
        }


    }
}
