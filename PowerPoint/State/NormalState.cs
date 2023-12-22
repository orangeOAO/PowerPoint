using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint.ShowModel;

namespace PowerPoint.IState
{
    public class PointState : State
    {
        //Draw
        public void Draw(Model model, System.Drawing.Graphics graphics)
        {
            var graphic = new WindowsGraphics(graphics);
            model.DrawShape(graphic);
        }

        //Press
        public void PressedPointer(Model model, Point point)
        {
            model.DetectInShape(point);
            if (model._selectShapeIndex != - 1)
            {
                model.SetState(new SelectState());
            }
        }

        //Move
        public void MovedPointer(Model model, Point point, bool press)
        {
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Normal;
        }
    }
}
