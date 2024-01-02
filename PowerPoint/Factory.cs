using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    public class Factory
    {
        private int _canvasWidth = Constant.CANVAS_WIDTH;
        private int _canvasHeight = Constant.CANVAS_HEIGHT;
        private Point _point1;
        private Point _point2;

        readonly Random _random = new Random();
        //Factory
        public Shape CreateShape(ShapeType shapeType)
        {   
            if (_point1 == new Point(0,0) || _point2 == new Point(0, 0))
            {
                _point1 = new Point(_random.Next(0, _canvasWidth), _random.Next(0, _canvasHeight));
                _point2 = new Point(_random.Next(0, _canvasWidth), _random.Next(0, _canvasHeight));
            }
            switch (shapeType)
            {
                case ShapeType.LINE:
                    return new Line(_point1, _point2);
                case ShapeType.RECTANGLE:
                    return new Rectangle(_point1, _point2);
                case ShapeType.CIRCLE:
                    return new Circle(_point1, _point2);
                default:
                    return new Rectangle(_point1, _point2);
            }
        }

        //ResizeCanvas
        public void ResizeCanvas(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
        }

        //setPoint
        public void SetPoint(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }
    }
}
