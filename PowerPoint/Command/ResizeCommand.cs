using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Command
{
    public class ResizeCommand : Command
    {
        public ResizeCommand(Model model, int index, Point point, Point startPoint)
        {
            _model = model;
            _index = index;
            _resizePoint = point;
            _originPoint = startPoint;
        }

        //exe
        public void Execute()
        {
            _model.SetResizePoint(_index, _resizePoint);
        }

        //unexe
        public void Undo()
        {
            _model.SetResizePoint(_index, _originPoint);
        }

        private Model _model;
        private int _index;
        private Point _resizePoint;
        private Point _originPoint;
    }
}
