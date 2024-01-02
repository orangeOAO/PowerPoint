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
        public event CommandManager.HandleUndoRedoHistoryEventHandler _undoRedoHistoryChanged;
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public delegate void StateChangedEventHandler(State state);
        public event StateChangedEventHandler _stateChanged;
        //private BindingList<Shape> _shapesList = new BindingList<Shape>();
        private BindingList<Page> _pagesList = new BindingList<Page>();
        private readonly Factory _factory = new Factory();
        private CommandManager _commandManager;
        private State _currentState;
        private bool _isPress;
        private int _canvasWidth;
        private Point _lastPoint;
        private Point _startPoint;
        private Point _point1;
        private Point _point2;
        Shape _hint;
        private Point _firstPoint = new Point(0, 0);
        public enum ModelState
        {
            Normal,
            Drawing,
            Select,
            Resize
        }
        public int _selectPageIndex {
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

        public Model()
        {
            _commandManager = new CommandManager();
            _commandManager._undoRedoHistoryChanged += SetUndoRedoHistory;
            _selectShapeIndex = -1;
            _currentState = new PointState();
            _pagesList.Add(new Page());
            _selectPageIndex = 0;
        }

        //setState

        public virtual void SetState(State state)
        {
            _currentState = state;
            NotifyStateChanged(_currentState);
            //Debug.WriteLine(_currentState);
        }

        //CreateShape
        public virtual void CreateShape(ShapeType shapeType)
        {
            _factory.SetPoint(_point1, _point2);
            var shape = _factory.CreateShape(shapeType);
            _pagesList[_selectPageIndex].CreateShapeInPage(shape);
            //_shapesList.Add(shape);
            HandleCreateShape(shape);
            NotifyModelChanged();

        }

        //SetPoint
        public virtual void SetShapePoint(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        //回傳目前的ShapesList
        public virtual BindingList<Shape> GetShapes()
        {
            //return _shapesList;
            return _pagesList[_selectPageIndex].GetShapes();
        }

        //DeleteShape
        public virtual void DeleteShapeByUndo(int index)
        {
            _pagesList[_selectPageIndex].DeleteShapeInPage(index);
            //_shapesList.RemoveAt(index);
            NotifyModelChanged();
        }

        //DeleteShape
        public virtual void DeleteShape(int index)
        {
            if (index != -1)
            {
                _commandManager.Execute(new DeleteCommand(this, _pagesList[_selectPageIndex].GetShapes()[index], index));
                _pagesList[_selectPageIndex].DeleteShapeInPage(index);
                //_shapesList.RemoveAt(index);
            }
            _selectShapeIndex = -1;
            NotifyModelChanged();
        }
        //DeleteSelectShape
        public virtual void DeleteSelectShape()
        {
            if (_selectShapeIndex != -1)
            {
                _commandManager.Execute(new DeleteCommand(this, _pagesList[_selectPageIndex].GetShapes()[_selectShapeIndex], _selectShapeIndex));
                _pagesList[_selectPageIndex].DeleteShapeInPage(_selectShapeIndex);
                //_shapesList.RemoveAt(_selectShapeIndex);
                NotifyModelChanged();
            }
            _selectShapeIndex = -1;
        }

        //GetShapeCount
        public virtual int GetShapeCount()
        {
            //return _shapesList.Count;
            return _pagesList[_selectPageIndex].GetShapes().Count;
        }

        //Notify
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        //Notify
        public void NotifyStateChanged(State state)
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
            _pagesList[_selectPageIndex].CreateShapeInPage(hint);

            //_shapesList.Add(hint);
            HandleDrawShape(hint);
            NotifyModelChanged();
        }

        //Clear
        public virtual void Clear()
        {
            _pagesList.Clear();
            //_shapesList.Clear();
            ClearSelectBox();
            NotifyModelChanged();
        }

        //DrawShape
        public virtual void DrawShape(IGraphics graphics)
        {
            for (int count = _pagesList[_selectPageIndex].GetShapes().Count-1; count >= 0; count--)
            {
                _pagesList[_selectPageIndex].GetShapes()[count].Draw(graphics);
            }
            //for (int count = _shapesList.Count - 1; count >= 0; count--)
            //{
            //    _shapesList[count].Draw(graphics);
            //}
        }

        //DrawSelected
        public virtual void DrawBox(IGraphics graphics)
        {
            for (int count = _pagesList[_selectPageIndex].GetShapes().Count - 1; count >= 0; count--)
            {
                if (count == _selectShapeIndex)
                {
                    _pagesList[_selectPageIndex].GetShapes()[count].DrawBox(graphics);
                }
            }
            //for (int count = _shapesList.Count - 1; count >= 0; count--)
            //{
            //    if (count == _selectShapeIndex)
            //    {
            //        _shapesList[count].DrawBox(graphics);
            //    }
            //}
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
            for (int count = _pagesList[_selectPageIndex].GetShapes().Count - 1; count >= 0; count--)
            {
                if (_pagesList[_selectPageIndex].GetShapes()[count].GetInShape(mousePoint))
                {
                    _moveShape = true;
                    _pagesList[_selectPageIndex].GetShapes()[count].SetTemporaryPoint();
                    _selectShapeIndex = count;
                    break;
                }
            }
        }

        //ClearBox
        public virtual void ClearSelectBox()
        {
            foreach (Shape shape in _pagesList[_selectPageIndex].GetShapes())
            {
                shape.IsShapeSelected = false;
            }
            NotifyModelChanged();
        }

        //MoveShape
        public virtual void MoveShape(Point mousePoint)
        {
            if (_selectShapeIndex != -1)
            {
                _pagesList[_selectPageIndex].GetShapes()[_selectShapeIndex].MoveCalculate(mousePoint);
                NotifyModelChanged();
            }
        }

        //MoveShapeByBias
        public virtual void MoveShapeByBias(Size bias, int index)
        {
            _pagesList[_selectPageIndex].GetShapes()[index].MoveShapeByBias(bias);
            NotifyModelChanged();
        }

        //setResizePoint
        public void SetResizePoint(int index, Point point)
        {
            _pagesList[_selectPageIndex].GetShapes()[index].SetResizeShapePoint(point);
            NotifyModelChanged();
        }

        //ResizeShape
        public virtual void ResizeShape(Point mousePoint)
        {
            //for(int i = 0; i < _pagesList[_selectPageIndex].GetShapes().Count; i++)
            //{
            _pagesList[_selectPageIndex].GetShapes()[_selectShapeIndex].SetResizeShapePoint(mousePoint);
            SetResizePoint(_selectShapeIndex, mousePoint);
            //}
        }

        //GetInResizeShape
        public bool GetInResizeShape(Shape shape, Point point)
        {
            return shape.GetInResizeShape(point);
        }

        //ChangeCursor
        public virtual bool ChangeToResizeMode(Point mousePoint)
        {
            foreach (var shape in _pagesList[_selectPageIndex].GetShapes())
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
            foreach (var shape in _pagesList[_selectPageIndex].GetShapes())
            {
                shape.Scale((float)width / (float)_canvasWidth);
            }
            _canvasWidth = width;
            _factory.ResizeCanvas(width, height);
            NotifyModelChanged();
        }

        //// handle
        public virtual void HandleCreateShape(Shape shape)
        {
            _commandManager.Execute(new AddCommand(this, shape, _pagesList[_selectPageIndex].GetShapes().Count - 1));
        }

        //// handle
        public virtual void HandleMoveShape(int index, Size bias)
        {
            _commandManager.Execute(new MoveCommand(this, index, bias));
        }

        //// handle
        public virtual void HandleDrawShape(Shape shape)
        {
            _commandManager.Execute(new DrawingCommand(this, shape, _pagesList[_selectPageIndex].GetShapes().Count - 1));
        }

        //handle
        public virtual void HandleResizeShape(Point upPoint)
        {
            _commandManager.Execute(new ResizeCommand(this, _selectShapeIndex, upPoint, _startPoint));

        }

        ////set
        public void SetUndoRedoHistory(bool isUndo, bool isRedo)
        {
            if (_undoRedoHistoryChanged != null)
            {
                _undoRedoHistoryChanged(isUndo, isRedo);
            }
        }

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
        public virtual void InsertShape(Shape shape, int index)
        {
            _pagesList[_selectPageIndex].GetShapes().Insert(index, shape);
            NotifyModelChanged();
        }

        //mouseUP
        public void MouseUp(Point point)
        {
            _isPress = false;
            _currentState.ReleasedPointer(this,point);
            _lastPoint = point;
            if (GetState() == ModelState.Select && _selectShapeIndex !=-1)
            {
                Size bias = new Size(_lastPoint.X - _startPoint.X, _lastPoint.Y - _startPoint.Y);
                HandleMoveShape(_selectShapeIndex, bias);
            }
            else if (GetState() == ModelState.Resize && _selectShapeIndex != -1)
            {
                HandleResizeShape(point);
            }
        }

        //mouseUP
        public void MouseDown(Point point)
        {
            _isPress = true;
            _currentState.PressedPointer(this, point);
            _startPoint = point;
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
        public virtual Model.ModelState GetState()
        {
            return _currentState.GetState();
        }

        //addPage
        public void AddPage()
        {
            _pagesList.Add(new Page());
        }

        //deletePage
        public void DeletePage()
        {
            _pagesList.RemoveAt(_selectPageIndex);
            if (_selectPageIndex >= _pagesList.Count())
            {
                _selectPageIndex--;
            }
            SetPageIndex(_selectPageIndex);
        }

        //SetPageIndex
        public void SetPageIndex(int index)
        {
            _selectPageIndex = index;
            Debug.Print($"Page = {index}");
        }

        //GetPageCount
        public int GetPageCount()
        {
            return _pagesList.Count;
        }

        //getPage
        public int GetClickPage()
        {
            return _selectPageIndex;
        }
    }
}
