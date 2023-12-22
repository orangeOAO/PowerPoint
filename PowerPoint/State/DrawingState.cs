using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint.ShowModel;

namespace PowerPoint.IState
{
    public class DrawingState : State
    {
        private bool _isPressed;
        
        internal ShapeType Type 
        {
            get;
        }

        public DrawingState(ShapeType type)
        {
            Type = type;
        }

        //Draw
        public void Draw(Model model, System.Drawing.Graphics graphics)
        {
            var graphic = new WindowsGraphics(graphics);
            model.DrawShape(graphic);
            if (_isPressed)
            {
                model.DrawHint(graphic);
            }
        }

        //Press
        public void PressedPointer(Model model, Point point)
        {
            model.PressedPointer(point, Type);
            _isPressed = true;
        }

        //Move
        public void MovedPointer(Model model, Point point, bool press)
        {
            if (press)
            {
                model.MovedPointer(point);
            }
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            if (_isPressed)
            {
                _isPressed = false;
                model.ReleasedPointer(point, Type);
            }
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Drawing;
        }
    }
}
