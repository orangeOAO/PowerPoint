using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.ShowModel
{
    public class ResizeState : State
    {
        //Draw
        public void Draw(Model model, System.Drawing.Graphics graphics)
        {
            var graphic = new WindowsGraphics(graphics);
            model.Draw(graphic);
        }

        //Press
        public void PressedPointer(Model model, Point point)
        {
            model.DetectInShape(point);
            model._resizeShape = true;
        }

        //Move
        public void MovedPointer(Model model, Point point)
        {
            if (model.DecideToChangeCursor(point))
            {
                model.ResizeShape(point);
            }
            else
            {
                model.MoveShape(point);
            }
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            model._moveShape = false;
            model._resizeShape = false;
            model._record = false;
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Resize;
        }
    }
}
