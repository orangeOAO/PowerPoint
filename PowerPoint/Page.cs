using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPoint.Command;

namespace PowerPoint
{
    public class Page
    {
        private BindingList<Shape> _shapesList = new BindingList<Shape>();

        public Page()
        {
            
        }

        //insertShape
        public void CreateShapeInPage(Shape shape)
        {
            _shapesList.Add(shape);
        }

        //deleteShape
        public void DeleteShapeInPage(int index)
        {
            _shapesList.RemoveAt(index);
        }

        //get
        public BindingList<Shape> GetShapes()
        {
            return _shapesList;
        }


    }
}
