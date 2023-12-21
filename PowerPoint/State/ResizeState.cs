using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint.ShowModel;

namespace PowerPoint.IState
{
    public class ResizeState : State
    {
        private bool _isPress;
        //Draw
        public void Draw(Model model, System.Drawing.Graphics graphics)
        {
            var graphic = new WindowsGraphics(graphics);
            model.DrawShape(graphic);
            model.DrawBox(graphic);
        }

        //Press
        public void PressedPointer(Model model, Point point)
        {
            _isPress = true;
        }

        //Move
        public void MovedPointer(Model model, Point point)
        {
            //if (!model.DecideToChangeCursor(point))
            //{
            //    model.SetState(new SelectState());
            //}
            if (_isPress)
            {
                model.ResizeShape(point);
            }
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            _isPress = false;
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Resize;
        }
    }
}
