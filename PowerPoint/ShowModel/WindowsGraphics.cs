using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint.ShowModel
{
    public class WindowsGraphics : IGraphics
    {
        readonly Graphics _graphics;
        const int TWO = 2;
        
        public WindowsGraphics(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //ClearAll
        public void ClearAll()
        {
        }
        
        //DrawLine
        public void DrawLine(Pen pen, Point point1, Point point2)
        {
            _graphics.DrawLine(pen, (float)point1.X, (float)point1.Y, (float)point2.X,
                (float)point2.Y);
        }

        //DrawRectangle
        public void DrawRectangle(Pen pen, Point point1, Point point2)
        {
            float width = System.Math.Abs(point2.X - point1.X);
            float height = System.Math.Abs(point2.Y - point1.Y);
            float fix1 = point1.X;
            float fix2 = point1.Y;
            if (point1.X > point2.X)
            {
                fix1 -= width;
            }
            if (point1.Y > point2.Y)
            {
                fix2 -= height;
            }
            _graphics.DrawRectangle(pen, fix1, fix2, width, height);
        }

        //DrawRectangleSelectBox
        public void DrawLineSelectBox(Point point1, Point point2)
        {
            float width = System.Math.Abs(point2.X - point1.X);
            float height = System.Math.Abs(point2.Y - point1.Y);
            float fix1 = point1.X;
            float fix2 = point1.Y;
            if (point1.X > point2.X)
            {
                fix1 -= width;
            }
            if (point1.Y > point2.Y)
            {
                fix2 -= height;
            }
            DrawResizeHandles(_graphics, width, height, fix1, fix2);
        }

        //DrawRectangleSelectBox
        public void DrawRectangleSelectBox(Point point1, Point point2)
        {
            float width = System.Math.Abs(point2.X - point1.X);
            float height = System.Math.Abs(point2.Y - point1.Y);
            float fix1 = point1.X;
            float fix2 = point1.Y;
            if (point1.X > point2.X)
            {
                fix1 -= width;
            }
            if (point1.Y > point2.Y)
            {
                fix2 -= height;
            }
            DrawResizeHandles(_graphics,width,height,fix1,fix2);
        }

        //DrawCircleBox
        public void DrawCircleSelectBox(Point point1, Point point2)
        {
            float width = System.Math.Abs(point2.X - point1.X);
            float height = System.Math.Abs(point2.Y - point1.Y);
            float fix1 = point1.X;
            float fix2 = point1.Y;
            if (point1.X > point2.X)
            {
                fix1 -= width;
            }
            if (point1.Y > point2.Y)
            {
                fix2 -= height;
            }
            DrawResizeHandles(_graphics, width, height, fix1, fix2);
        }

        //DrawHandle
        private void DrawHandle(Graphics graphics, float xPoint, float yPoint)
        {
            graphics.DrawEllipse(Pens.Red, xPoint, yPoint, Constant.RESIZE_HANDLE_SIZE, Constant.RESIZE_HANDLE_SIZE);
        }

        //調整大小的點
        private void DrawResizeHandles(Graphics graphics, float width, float height, float x1, float x2)
        {
            float centerX = x1 + width / TWO;
            float centerY = x2 + height / TWO - Constant.HALF_HANDLE_SIZE ;
            DrawHandle(graphics, centerX, x2 - Constant.HALF_HANDLE_SIZE);
            DrawHandle(graphics, centerX, x2 + height - Constant.HALF_HANDLE_SIZE);
            DrawHandle(graphics, x1 - Constant.HALF_HANDLE_SIZE, centerY);
            DrawHandle(graphics, x1 + width - Constant.HALF_HANDLE_SIZE, centerY);
            DrawHandle(graphics, x1 - Constant.HALF_HANDLE_SIZE, x2 - Constant.HALF_HANDLE_SIZE); // 左上角
            DrawHandle(graphics, x1 + width - Constant.HALF_HANDLE_SIZE, x2 - Constant.HALF_HANDLE_SIZE); // 右上角
            DrawHandle(graphics, x1 - Constant.HALF_HANDLE_SIZE, x2 + height - Constant.HALF_HANDLE_SIZE); // 左下角
            DrawHandle(graphics, x1 + width - Constant.HALF_HANDLE_SIZE, x2 + height - Constant.HALF_HANDLE_SIZE); // 右下角
            graphics.DrawRectangle(Pens.Brown, x1, x2, width, height);
        }

        //DrawCircle
        public void DrawCircle(Pen pen, Point point1, Point point2)
        {
            _graphics.DrawEllipse(pen, (float)point1.X, (float)point1.Y, (float)(point2.X - point1.X),
            (float)(point2.Y - point1.Y));
        }
    }
}
