using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Command.Tests
{
    [TestClass]
    public class ResizeCommandTest
    {
        private PowerPoint.Command.ResizeCommand _resizeCommand;
        private Mock<Model> _mockModel;
        private Shape _shape;
        private int _index;
        private Model _model;

        // test
        [TestInitialize]
        public void Setup()
        {
            _mockModel = new Mock<Model>();
            _shape = new Shape();
            _model = new Model();
            _index = 0;

            _model.CreateShape(ShapeType.CIRCLE);
            _resizeCommand = new PowerPoint.Command.ResizeCommand(_model, _index, new Point(1,1), new Point(2,2));
        }
       
        // test
        [TestMethod]
        public void ExecutResizesShapeAtGivenIndex()
        {
            _resizeCommand.Execute();
        }

        // test
        [TestMethod]
        public void UndoResizeShapeAtGivenIndex()
        {
            _resizeCommand.Undo();
        }
    }
}
