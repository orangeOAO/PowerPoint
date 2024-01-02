using System.Diagnostics;
using System.Drawing;
using PowerPoint.ShowModel;

namespace PowerPoint.IState
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
            //if(model._selectShapeIndex == -1)
            //{
            //    model.SetState(new PointState());
            //}
        }

        //Move
        public void MovedPointer(Model model, Point point, bool press)
        {
            //model.SetState(new ResizeState());
            //Debug.WriteLine("OAO");
            if (model.ChangeToResizeMode(point))
            {
                model.SetState(new ResizeState());
            }
            else
            {
                if (press)
                {
                    model.MoveShape(point);
                }
            }
        }

        //Release
        public void ReleasedPointer(Model model, Point point)
        {
            //_lastPoint = point;
            //model.HandleMoveShape(model._selectShapeIndex, new Size(_lastPoint.X-_startPoint.X, _lastPoint.Y-_lastPoint.Y));
        }

        //GetState
        public Model.ModelState GetState()
        {
            return Model.ModelState.Select;
        }
    }
}
