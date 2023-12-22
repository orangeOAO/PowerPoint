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
        }

        //Move
        public void MovedPointer(Model model, Point point, bool press)
        {
            if (press)
            {
                model.ResizeShape(point);
            }
            else
            {
                model.SetState(new SelectState());
            }
            
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Resize;
        }
    }
}
