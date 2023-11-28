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
            Selected,
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
        public void CreateShape(ShapeType shapeType)
        {
            _shapesList.Add(_factory.CreateShape(shapeType));
            NotifyModelChanged();

        }

        //回傳目前的ShapesList
        public BindingList<Shape> GetShapes()
        {
            return _shapesList;
        }

        //DeleteShape
        public void DeleteShape(int index)
        {
            _shapesList.RemoveAt(index);
            NotifyModelChanged();
            _selectShapeIndex = -1;
        }

        //DeleteSelectShape
        public void DeleteSelectShape(int index)
        {
            if (_selectShapeIndex != -1)
            {
                _shapesList.RemoveAt(index);
                NotifyModelChanged();
            }
            _selectShapeIndex = -1;
        }

        //GetShapeCount
        public int GetShapeCount()
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
        public void PressedPointer(Point point, ShapeType type)
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
        public void MovedPointer(Point point)
        {
            _hint.SetSecondPoint(point);
            NotifyModelChanged();
        }

        //Release Pointer
        public void ReleasedPointer(Point point, ShapeType type)
        {
            Shape hint = _factory.CreateShape(type);
            hint.SetFirstPoint(_firstPoint);
            hint.SetSecondPoint(point);
            _shapesList.Add(hint);
            NotifyModelChanged();
            _record = false;
        }

        //Clear
        public void Clear()
        {
            _shapesList.Clear();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {

            for (int count = _shapesList.Count - 1; count >= 0; count--)
            {
                _shapesList[count].Draw(graphics);
                if (_shapesList[count].IsShapeSelected)
                {
                    _shapesList[count].DrawBox(graphics);
                }
            }
        }

        //DrawBox
        public void DrawBox()
        {
            NotifyModelChanged();
        }

        //DrawHint
        public void DrawHint(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        //initialize
        private void InitializeSelect()
        {
            foreach (var shape in _shapesList)
            {
                shape.IsShapeSelected = false;
            }
            _record = false;
        }

        //DetectInShape
        public void DetectInShape(Point mousePoint)
        {
            _moveShape = false;
            _selectShapeIndex = -1;
            InitializeSelect();
            for (int count = _shapesList.Count - 1; count >= 0 ; count--)
            {
                _shapesList[count].Bounds(mousePoint);
                
                if (_shapesList[count].IsShapeSelected)
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
        public void ClearSelectBox()
        {
            foreach (Shape shape in _shapesList)
            {
                shape.ClearSelectBox();
            }
            NotifyModelChanged();
        }

        //MoveShape
        public void MoveShape(Point mousePoint)
        {
            if (_moveShape && _selectShapeIndex !=-1)
            {
                _shapesList[_selectShapeIndex].MoveCalculate(mousePoint);
                NotifyModelChanged();
            }
        }

        //ResizeShape
        public void ResizeShape(Point mousePoint)
        {
            foreach (var shape in _shapesList)
            {
                if (shape.IsShapeSelected && _resizeShape)
                {
                    shape.SetResizeShapePoint(mousePoint);
                    NotifyModelChanged();
                }
            }
        }

        //ChangeCursor
        public bool DecideToChangeCursor(Point mousePoint)
        {
            if (_record)
            {
                return _resizeShape;
            }
            foreach (var shape in _shapesList)
            {
                if (shape.IsShapeSelected && shape.GetInResizeShape(mousePoint))
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
