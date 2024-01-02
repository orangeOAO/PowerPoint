using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public class Circle : Shape
    {
        public Circle(Point point1, Point point2) : base(point1, point2)
        {
            _shapeName = Constant.CIRCLE;
            _shapeType = ShapeType.CIRCLE;
        }

        public Circle()
        {
            _shapeName = Constant.CIRCLE;
            _shapeType = ShapeType.CIRCLE;
        }

        //DrawCircle
        public override void Draw(IGraphics graphics)
        {
            Pen pen = new Pen(Color.BlueViolet, Constant.TWO);
            graphics.DrawCircle(pen, _point1, _point2);
        }

        //DrawCircleBox
        public override void DrawBox(IGraphics graphics)
        {
            graphics.DrawCircleSelectBox(_point1, _point2);
        }
    }
}
