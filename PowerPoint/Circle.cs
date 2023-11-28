﻿using System;
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
            graphics.DrawCircle(Pens.Brown, _point1, _point2);
        }

        //DrawCircleBox
        public override void DrawBox(IGraphics graphics)
        {
            graphics.DrawCircleSelectBox(_point1, _point2);
        }
    }
}