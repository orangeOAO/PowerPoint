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
        private const int BORDER1 = 0;
        private const int BORDER2 = 100;
        readonly Random _random = new Random();
        //Factory
        public Shape CreateShape(ShapeType shapeType)
        {
            Point point1 = new Point(_random.Next(BORDER1, BORDER2), _random.Next(BORDER1, BORDER2));
            Point point2 = new Point(_random.Next(BORDER1, BORDER2), _random.Next(BORDER1, BORDER2));
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
    }
}
