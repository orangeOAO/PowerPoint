using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint.Command;

namespace PowerPoint
{
    public partial class Model
    {
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
            _currentState.ReleasedPointer(this, point);
            _lastPoint = point;
            if (GetState() == ModelState.Select && _selectShapeIndex != -1)
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

        //insertPage
        public void InsertPage(int index)
        {
            _pagesList.Insert(index, new Page());
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
            //Debug.Print($"Page = {index}");
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
