using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    public class Model
    {

        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private BindingList<Shape> _shapesList = new BindingList<Shape>();
        private readonly Factory _factory = new Factory();
        Shape _hint;
        private Point _firstPoint = new Point(0, 0);
        public enum ModelState
        {
            Normal,
            Drawing,
            Select,
            Resize
        }
        public bool _record 
        {
            get;
            set;
        }
        public int _selectShapeIndex 
        {
            get;
            set;
        }
        public bool _moveShape 
        {
            get;
            set;
        }

        public bool _resizeShape 
        {
            get;
            set;
        }

        //CreateShape
        public virtual void CreateShape(ShapeType shapeType)
        {
            _shapesList.Add(_factory.CreateShape(shapeType));
            NotifyModelChanged();

        }

        //回傳目前的ShapesList
        public virtual BindingList<Shape> GetShapes()
        {
            return _shapesList;
        }

        //DeleteShape
        public virtual void DeleteShape(int index)
        {
            _shapesList.RemoveAt(index);
            NotifyModelChanged();
            _selectShapeIndex = -1;
        }

        //DeleteSelectShape
        public virtual void DeleteSelectShape()
        {
            if (_selectShapeIndex != -1)
            {
                _shapesList.RemoveAt(_selectShapeIndex);
                NotifyModelChanged();
            }
            _selectShapeIndex = -1;

        }

        //GetShapeCount
        public virtual int GetShapeCount()
        {
            return _shapesList.Count;
        }

        //Notify
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        //Press
        public virtual void PressedPointer(Point point, ShapeType type)
        {
            if (point.X > 0 && point.Y > 0)
            {
                _firstPoint.X = point.X;
                _firstPoint.Y = point.Y;
                _hint = _factory.CreateShape(type);
                _hint.SetFirstPoint(_firstPoint);
            }
        }

        //MovePoint
        public virtual void MovedPointer(Point point)
        {
            _hint.SetSecondPoint(point);
            NotifyModelChanged();
        }

        //Release Pointer
        public virtual void ReleasedPointer(Point point, ShapeType type)
        {
            Shape hint = _factory.CreateShape(type);
            hint.SetFirstPoint(_firstPoint);
            hint.SetSecondPoint(point);
            _shapesList.Add(hint);
            NotifyModelChanged();
            _record = false;
        }

        //Clear
        public virtual void Clear()
        {
            _shapesList.Clear();
            ClearSelectBox();
            NotifyModelChanged();
        }

        //DrawShape
        public virtual void DrawShape(IGraphics graphics)
        {

            for (int count = _shapesList.Count - 1; count >= 0; count--)
            {
                _shapesList[count].Draw(graphics);
            }
        }

        //DrawSelected
        public virtual void DrawBox(IGraphics graphics)
        {

            for (int count = _shapesList.Count - 1; count >= 0; count--)
            {
                if (count == _selectShapeIndex)
                {
                    _shapesList[count].DrawBox(graphics);
                }
            }
        }

        //DrawHint
        public virtual void DrawHint(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        //DetectInShape
        public virtual void DetectInShape(Point mousePoint)
        {
            _moveShape = false;
            _selectShapeIndex = -1;
            ClearSelectBox();
            for (int count = _shapesList.Count - 1; count >= 0 ; count--)
            {
                if (_shapesList[count].GetInShape(mousePoint))
                {
                    _shapesList[count].SetTemporaryPoint();
                    _moveShape = true;
                    _selectShapeIndex = count;
                    break;
                }
            }
            //_moveShape = false;
            NotifyModelChanged();
        }

        //ClearBox
        public virtual void ClearSelectBox()
        {
            foreach (Shape shape in _shapesList)
            {
                shape.IsShapeSelected = false;
            }
            NotifyModelChanged();
        }

        //MoveShape
        public virtual void MoveShape(Point mousePoint)
        {
            if (_moveShape && _selectShapeIndex != -1)
            {
                _shapesList[_selectShapeIndex].MoveCalculate(mousePoint);
                NotifyModelChanged();
            }
        }

        //setResizePoint
        private void SetResizePoint(Shape shape, Point point)
        {
            shape.SetResizeShapePoint(point);
        }

        //ResizeShape
        public virtual void ResizeShape(Point mousePoint)
        {
            foreach (var shape in _shapesList)
            {
                if (shape.IsShapeSelected && _resizeShape)
                {
                    SetResizePoint(shape, mousePoint);
                    NotifyModelChanged();
                }
            }
        }

        //GetInResizeShape
        private bool GetInResizeShape(Shape shape, Point point)
        {
            return shape.GetInResizeShape(point);
        }

        //ChangeCursor
        public virtual bool DecideToChangeCursor(Point mousePoint)
        {
            if (_record)
            {
                return _resizeShape;
            }
            foreach (var shape in _shapesList)
            {
                if (shape.IsShapeSelected && GetInResizeShape(shape, mousePoint))
                {
                    if (_resizeShape)
                    {
                        _record = true;
                    }
                    return true;
                }
            }
            _record = false;
            return false;
        }

    }
}
