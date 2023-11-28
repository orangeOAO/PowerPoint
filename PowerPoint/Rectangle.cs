using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public class Rectangle : Shape
    {
        public Rectangle(Point point1, Point point2) : base(point1, point2)
        {
            _shapeName = Constant.RECTANGLE;
            _shapeType = ShapeType.RECTANGLE;
        }

        public Rectangle()
        {
            _shapeName = Constant.RECTANGLE;
            _shapeType = ShapeType.RECTANGLE;
        }

        //DrawRectangle
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(Pens.Brown, _point1, _point2);
        }

        //DrawBox
        public override void DrawBox(IGraphics graphics)
        {
            graphics.DrawRectangleSelectBox(_point1, _point2);
        }
    }
}
