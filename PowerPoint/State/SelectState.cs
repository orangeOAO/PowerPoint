using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.ShowModel
{
    public class SelectState : State
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
            model.DetectInShape(point);
        }

        //Move
        public void MovedPointer(Model model, Point point)
        {

            model.MoveShape(point);
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            model._moveShape = false;
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Select;
        }
    }
}
