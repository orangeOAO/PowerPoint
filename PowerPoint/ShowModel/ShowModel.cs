using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace PowerPoint.ShowModel
{

    public class ShowModel
    {
        public event Model.ModelChangedEventHandler _modelChanged;
        private State _currentState;
        readonly Model _model;

        public ShowModel(Model model)
        {
            _model = model;
            _model._modelChanged += HandleModelChanged;
            _currentState = new PointState();

        }

        //SetState
        public void SetState(State state)
        {
            _currentState = state;
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
            _currentState.Draw(_model, graphics);
        }

        //Press
        public void PressedPointer(Point point)
        {
            _currentState.PressedPointer(_model, point);
        }

        //ClearSelectBox
        public void ClearSelectBox()
        {
            _model.ClearSelectBox();
        }

        //Move
        public void MovedPointer(Point point)
        {
            _currentState.MovedPointer(_model, point);
        }

        //Release
        public void ReleasedPointer(Point point)
        {
            _currentState.ReleasedPointer(_model, point);
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
        public void HandleButtonClick(ToolStripButton[] buttons, int index)
        {
            foreach (var aButton in buttons)
            {
                aButton.Checked = false;
            }
            buttons[index].Checked = true;
        }

        //ReleaseButton
        public void ReleaseButtonClick(ToolStripButton[] buttons)
        {
            foreach (var aButton in buttons)
            {
                aButton.Checked = false;
            }
        }

        //DeleteSeleteShape
        public void DeleteSelectShape()
        {  
            _model.DeleteSelectShape();
        }

        //ChangeCursor
        public bool ChangeCursor(Point mousePoint)
        {
            var change = _model.DecideToChangeCursor(mousePoint);
            if (change)
            {
                _currentState = new ResizeState();
            }
            else
            {
                var selectedShape = _model.GetShapes().FirstOrDefault(shape => shape.IsShapeSelected);
                if (selectedShape != null)
                {
                    _currentState = new SelectState();
                }
            }
            return change;
        }

        //GetCurrnentState
        public Model.ModelState GetCurrentState()
        {
            return _currentState.GetState();
        }
    }
}
