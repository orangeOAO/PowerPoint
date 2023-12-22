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
        private int _canvasWidth=450;
        private int _canvasHeight=450;
      
        readonly Random _random = new Random();
        //Factory
        public Shape CreateShape(ShapeType shapeType)
        {   
            
            Point point1 = new Point(_random.Next(0, _canvasWidth), _random.Next(0, _canvasHeight));
            Point point2 = new Point(_random.Next(0, _canvasWidth), _random.Next(0, _canvasHeight));
            switch (shapeType)
            {
                case ShapeType.LINE:
                    return new Line(point1, point2);
                case ShapeType.RECTANGLE:
                    return new Rectangle(point1, point2);
                case ShapeType.CIRCLE:
                    return new Circle(point1, point2);
                default:
                    return new Rectangle(point1, point2);
            }
        }

        //ResizeCanvas
        public void ResizeCanvas(int width, int height)
        {
            _canvasWidth = width;
            _canvasHeight = height;
        }
    }
}
