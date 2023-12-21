using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using PowerPoint.Command;
using PowerPoint.IState;

namespace PowerPoint.ShowModel
{

    public class ShowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Model.ModelChangedEventHandler _modelChanged;
        public event CommandStart.HandleUndoRedoHistoryEventHandler _undoRedoHistoryChanged;
        public delegate void CursorChangedEventHandler(Cursor cursor);
        public event CursorChangedEventHandler _cursorChanged;
        readonly bool[] _isButtonChecked = { false, false, false, false };


        readonly Model _model;

        public ShowModel(Model model)
        {
            _model = model;
            _model._modelChanged += HandleModelChanged;
            _model._undoRedoHistoryChanged += HandleUndoRedoHistoryChanged;
            _model._stateChanged += HandleStateChange;
            _isButtonChecked[(int)ShapeType.ARROW] = true;
        }

        //SetState
        public void SetState(State state)
        {
            _model.SetState(state);
            Debug.WriteLine(state);
        }

        /// cursor
        public void HandleStateChange(State state)
        {
            if (state is SelectState)
            {
                _cursorChanged(Cursors.Arrow);
            }
            else if (state is PointState)
            {
                _cursorChanged(Cursors.Arrow);
            }
            else if (state is DrawingState)
            {
                _cursorChanged(Cursors.Cross);
            }
            else if (state is ResizeState)
            {
                _cursorChanged(Cursors.SizeNWSE);
            }

        }

        /// handle prperty changed
        public void HandlePropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Constant.IS_LINE_CHECKED));
                PropertyChanged(this, new PropertyChangedEventArgs(Constant.IS_RECTANGLE_CHECKED));
                PropertyChanged(this, new PropertyChangedEventArgs(Constant.IS_CIRCLE_CHECKED));
                PropertyChanged(this, new PropertyChangedEventArgs(Constant.IS_MOUSE_CHECKED));
            }
        }

        //Handle
        public void HandleModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        //Draw
        public void Draw(System.Drawing.Graphics graphics)
        {
            _model.Draw(graphics);
        }

        //Press
        public void PressedPointer(Point point)
        {
            _model.MouseDown(point);
        }

        //ClearSelectBox
        public void ClearSelectBox()
        {
            _model.ClearSelectBox();
        }

        //Move
        public void MovedPointer(Point point)
        {
            _model.MouseMove(point);
        }

        //Release
        public void ReleasedPointer(Point point)
        {
            _model.MouseUp( point);
            for (int i = 0; i < _isButtonChecked.Length; i++)
            {
                _isButtonChecked[i] = false;
            }
            _isButtonChecked[(int)ShapeType.ARROW] = true;
            HandlePropertyChanged();
        }

        //Clear
        public void Clear()
        {
            _model.Clear();
        }

        //Get
        public BindingList<Shape> GetShapes()
        {
            return _model.GetShapes();
        }

        //Delete
        public void DeleteShape(int index)
        {
            _model.DeleteShape(index);
        }

        //Insert
        public void InsertShape(ShapeType type)
        {
            _model.CreateShape(type);
        }

        //handle
        public void HandleButtonClick(int index)
        {
            SetState(new DrawingState((ShapeType)index));
            if (index == (int)ShapeType.ARROW)
            {
                SetState(new PointState());
            }
            for (int i = 0; i < _isButtonChecked.Length; i++)
            {
                _isButtonChecked[i] = false;
            }
            Debug.WriteLine(index);
            _isButtonChecked[index] = true;
            HandlePropertyChanged();
        }

        //DeleteSeleteShape
        public void DeleteSelectShape()
        {  
            _model.DeleteSelectShape();
        }

        //RezizeCanvasSize
        public void ResizeCanvas(int width, int height)
        {
            _model.ResizeCanvas(width, height);
        }

        //GetCurrnentState
        //public Model.ModelState GetCurrentState()
        //{
        //    return _model.
        //}

        /// undo
        /// </summary>
        public void Undo()
        {
            _model.Undo();
        }


        /// redo
        /// </summary>
        public void Redo()
        {
            _model.Redo();
        }

        /// handle
        public void HandleUndoRedoHistoryChanged(bool isundo, bool isredo)
        {
            //if (_undoRedoHistoryChanged != null)
            //{
            //    _undoRedoHistoryChanged(isundo, isredo);
            //}
        }

        public bool IsLineButtonChecked {
            get {
                return _isButtonChecked[(int)ShapeType.LINE];
            }
        }

        public bool IsRectangleButtonChecked {
            get {
                return _isButtonChecked[(int)ShapeType.RECTANGLE];
            }
        }

        public bool IsCircleButtonChecked {
            get {
                return _isButtonChecked[(int)ShapeType.CIRCLE];
            }
        }

        public bool IsMouseButtonChecked {
            get {
                return _isButtonChecked[(int)ShapeType.ARROW];
            }
        }
    }
}
