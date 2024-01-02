using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public class Line : Shape
    {
        public Line(Point point1, Point point2) : base(point1, point2)
        {
            _shapeName = Constant.LINE;
            _shapeType = ShapeType.LINE;
        }

        public Line()
        {
            _shapeName = Constant.LINE;
            _shapeType = ShapeType.LINE;
        }

        //DrawLine
        public override void Draw(IGraphics graphics)
        {
            Pen pen = new Pen(Color.Gray, Constant.TWO);
            graphics.DrawLine(pen, _point1, _point2);
        }

        //DrawBox
        public override void DrawBox(IGraphics graphics)
        {
            graphics.DrawLineSelectBox(_point1, _point2);
        }
    }
}
