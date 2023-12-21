using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using PowerPoint.Command;
using PowerPoint.IState;

namespace PowerPoint
{
    public class Model
    {
        public event CommandStart.HandleUndoRedoHistoryEventHandler _undoRedoHistoryChanged;
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public delegate void StateChangedEventHandler(State state);
        public event StateChangedEventHandler _stateChanged;
        private BindingList<Shape> _shapesList = new BindingList<Shape>();
        private readonly Factory _factory = new Factory();
        private CommandStart _commandManager;
        private State _currentState;
        private bool _isPress;
        private int _canvasWidth;
        Shape _hint;
        private Point _firstPoint = new Point(0, 0);
        public enum ModelState
        {
            Normal,
            Drawing,
            Select,
            Resize
        }
        public bool _record {
            get;
            set;
        }
        public int _selectShapeIndex {
            get;
            set;
        }
        public bool _moveShape {
            get;
            set;
        }

        public bool _resizeShape {
            get;
            set;
        }

        public Model()
        {
            //_commandManager = new CommandStart();
            //_commandManager._undoRedoHistoryChanged += SetUndoRedoHistory;
            _selectShapeIndex = -1;
            _currentState = new PointState();
        }

        //setState

        public virtual void SetState(State state)
        {
            _currentState = state;
            NotifyStateChanged(_currentState);
            Debug.WriteLine(_currentState);
        }

        //CreateShape
        public virtual void CreateShape(ShapeType shapeType)
        {
            var shape = _factory.CreateShape(shapeType);
            _shapesList.Add(shape);
            //HandleInsertShape(shape);
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
            if (index != -1)
            {
                //_commandManager.Execute(new DeleteCommand(this, _shapesList[index], index));
                _shapesList.RemoveAt(index);
            }
            _selectShapeIndex = -1;
            NotifyModelChanged();
        }
        //DeleteSelectShape
        public virtual void DeleteSelectShape()
        {
            if (_selectShapeIndex != -1)
            {
                //_commandManager.Execute(new DeleteCommand(this, _shapesList[_selectShapeIndex], _selectShapeIndex));
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

        //Notify
        void NotifyStateChanged(State state)
        {
            if (_stateChanged != null)
            {
                _stateChanged(state);
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
            for (int count = _shapesList.Count - 1; count >= 0; count--)
            {
                if (_shapesList[count].GetInShape(mousePoint))
                {
                    _moveShape = true;
                    _shapesList[count].SetTemporaryPoint();
                    _selectShapeIndex = count;
                    break;
                }
            }
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
                SetResizePoint(shape, mousePoint);
                NotifyModelChanged();
            }
        }

        //GetInResizeShape
        public bool GetInResizeShape(Shape shape, Point point)
        {
            return shape.GetInResizeShape(point);
        }

        //ChangeCursor
        public virtual bool ChangeToResizeMode(Point mousePoint)
        {
            foreach (var shape in _shapesList)
            {
                if (GetInResizeShape(shape, mousePoint))
                {
                    return true;
                }
            }
            return false;
        }

        //ResizeCanvas
        public virtual void ResizeCanvas(int width, int height)
        {
            foreach (var shape in _shapesList)
            {
                shape.Scale((float)width / (float)_canvasWidth);
            }
            _canvasWidth = width;
            _factory.ResizeCanvas(width, height);
            NotifyModelChanged();
        }

        //// handle
        //public virtual void HandleInsertShape(Shape shape)
        //{
        //    _commandManager.Execute(new AddCommand(this, shape, _shapesList.Count - 1));
        //}

        //// handle
        //public virtual void HandleMoveShape(int index, Size bias)
        //{
        //    _commandManager.Execute(new MoveCommand(this, index, bias));
        //}

        //// handle
        //public virtual void HandleDrawShape(Shape shape)
        //{
        //    _commandManager.Execute(new DrawingCommand(this, shape, _shapesList.Count - 1));
        //}

        ////set
        //public void SetUndoRedoHistory(bool isUndo, bool isRedo)
        //{
        //    if (_undoRedoHistoryChanged != null)
        //    {
        //        _undoRedoHistoryChanged(isUndo, isRedo);
        //    }
        //}

        // undo
        public virtual void Undo()
        {
            _commandManager.Undo();
        }

        // redo
        public virtual void Redo()
        {
            _commandManager.Redo();
        }

        //insert
        public virtual void InsertShapeByShape(Shape shape, int index)
        {
            _shapesList.Insert(index, shape);
            NotifyModelChanged();
        }

        //mouseUP
        public void MouseUp(Point point)
        {
            _isPress = false;
            _currentState.ReleasedPointer(this,point);
        }

        //mouseUP
        public void MouseDown(Point point)
        {
            _isPress = true;
            _currentState.PressedPointer(this, point);
            
        }

        //mouseUP
        public void MouseMove(Point point)
        {
            _currentState.MovedPointer(this, point, _isPress);
        }

        //mouseDraw
        public void Draw(System.Drawing.Graphics graphics)
        {
            _currentState.Draw(this, graphics);
        }

        //Get

    }
}
