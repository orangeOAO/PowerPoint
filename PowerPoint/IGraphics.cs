using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    public interface IGraphics
    {
        //clear
        void ClearAll();

        //DrawLine
        void DrawLine(Pen pen, Point point1, Point point2);

        //DrawRectangle
        void DrawRectangle(Pen pen, Point point1, Point point2);

        //DrawRectangleSelectBox
        void DrawRectangleSelectBox(Point point1, Point point2);

        //DrawCircleSelectBox
        void DrawCircleSelectBox(Point point1, Point point2);

        //DrawLineSelectBox
        void DrawLineSelectBox(Point point1, Point point2);

        //DrawCircle
        void DrawCircle(Pen pen, Point point1, Point point2);
    }
}
