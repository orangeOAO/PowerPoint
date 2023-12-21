using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.IState
{
    public interface State
    {
        //Draw
        void Draw(Model model, System.Drawing.Graphics graphics);

        //Rress
        void PressedPointer(Model model, Point point);

        //Move
        void MovedPointer(Model model, Point point);

        //Release
        void ReleasedPointer(Model model, Point point);

        //GetState
        Model.ModelState GetState();
    }
}
