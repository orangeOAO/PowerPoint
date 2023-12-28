using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace PowerPoint
{
    public class Shape
    {
        protected string _shapeName = "";
        protected ShapeType _shapeType = new ShapeType();
        protected Point _point1 = new Point(0, 0);
        protected Point _point2 = new Point(0, 0);
        protected Point _temporaryPoint1 = new Point(0, 0);
        protected Point _temporaryPoint2 = new Point(0, 0);
        //private bool IsShapeSelected =false;
        //protected Point _pointSelect = new Point(0, 0);
        public Shape(Point point1, Point point2)
        {
            _temporaryPoint1 = _point1 = point1;
            _temporaryPoint2 = _point2 = point2;
        }

        public Shape()
        {

        }

        //名
        public string GetShapeName() 
        {
            return _shapeName;
        }

        //GetInfo
        public string GetInfo()
        {
            return FormatCoordinate(TransformCoordinate(_point1, _point2)[0]) + Constant.COMMA + FormatCoordinate(TransformCoordinate(_point1, _point2)[1]);
        }

        //Format
        private string FormatCoordinate(Point point)
        {
            return Constant.LEFT + point.X + Constant.COMMA + point.Y + Constant.RIGHT;
        }

        public virtual bool IsShapeSelected {
            get;
            set;
        }

        //point1
        public Point GetPoint1()
        {
            return _point1;
        }

        //point2
        public Point GetPoint2()
        {
            return _point2;
        }

        //Bounds
        public bool GetInShape(Point mousePoint)
        {
            int left = Math.Min(_point1.X, _point2.X);
            int right = Math.Max(_point1.X, _point2.X);
            int top = Math.Min(_point1.Y, _point2.Y);
            int bottom = Math.Max(_point1.Y, _point2.Y);
            IsShapeSelected = mousePoint.X >= left - ( 1 + 1 + 1) && mousePoint.X <= right + (1 + 1 + 1) &&
                mousePoint.Y - (1 + 1 + 1) >= top && mousePoint.Y <= bottom + (1 + 1 + 1);
            if (IsShapeSelected)
            {
                _pointSelect = mousePoint;
            }
            else
            {
                _temporaryPoint1 = new Point(0, 0);
                _temporaryPoint2 = new Point(0, 0);
            }
            return IsShapeSelected;
        }

        //Draw
        public virtual void Draw(IGraphics graphics)
        {
        }

        //DrawBox
        public virtual void DrawBox(IGraphics graphics)
        {
        }

        

        private Point _pointSelect;

        ////ShapeName
        public string _shape 
        {
            get
            {
                return GetShapeName();
            }
        }

        ////Info
        public string _information 
        {
            get 
            {
                return GetInfo();
            }
        }

        //SetFirstPoint
        public void SetFirstPoint(Point point1)
        {
            _point1 = point1;
        }

        //SetTemporaryPoint
        public void SetTemporaryPoint()
        {
            _temporaryPoint1 = _point1;
            _temporaryPoint2 = _point2;
        }

        //SetSecondPoint
        public void SetSecondPoint(Point point2)
        {
            _point2 = point2;
        }

        //TransformCoordinate
        private Point[] TransformCoordinate(Point point1, Point point2)
        {
            Point[] points = new Point[1 + 1] { new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y)), new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y)) };
            //if(_shapeType != ShapeType.LINE)
            //{
            //    _point1 = points[0];
            //    _point2 = points[1];
            //}
            return points;            
        }

        //MoveCalculate
        public void MoveCalculate(Point mousePoint)
        {
            _point1.X = _temporaryPoint1.X + (mousePoint.X - _pointSelect.X);
            _point1.Y = _temporaryPoint1.Y + (mousePoint.Y - _pointSelect.Y);
            _point2.X = _temporaryPoint2.X + (mousePoint.X - _pointSelect.X);
            _point2.Y = _temporaryPoint2.Y + (mousePoint.Y - _pointSelect.Y);
        }

        //MoveBybias
        public virtual void MoveShapeByBias(Size bias)
        {
            _point1.X = _point1.X + bias.Width;
            _point1.Y = _point1.Y + bias.Height;
            _point2.X = _point2.X + bias.Width;
            _point2.Y = _point2.Y + bias.Height;

        }

        /// scale
        public void Scale(float scale)
        {
            _point1.X = (int)(_point1.X * scale);
            _point1.Y = (int)(_point1.Y * scale);
            _point2.X = (int)(_point2.X * scale);
            _point2.Y = (int)(_point2.Y * scale);
        }

        //Resize
        public void SetResizeShapePoint(Point mousePoint)
        {
            _point2 = mousePoint;
        }

        //ReturnCalculateEightPoint
        public bool GetInResizeShape(Point mousePoint)
        {
            Point finalPoint = TransformCoordinate(_point1, _point2)[1];
            int left = finalPoint.X - Constant.HALF_HANDLE_SIZE;
            int right = finalPoint.X + Constant.HALF_HANDLE_SIZE;
            int top = finalPoint.Y - Constant.HALF_HANDLE_SIZE;
            int bottom = finalPoint.Y + Constant.RESIZE_HANDLE_SIZE;
            return mousePoint.X >= left && mousePoint.X <= right &&
                mousePoint.Y >= top && mousePoint.Y <= bottom;
        }

    }
    public enum ShapeType
    {
        CIRCLE,
        LINE,
        RECTANGLE,
        ARROW
    }
}
