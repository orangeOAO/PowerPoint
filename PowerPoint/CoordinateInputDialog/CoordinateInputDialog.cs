using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class CoordinateInputDialog : Form
    {
        public delegate void TextChangedEventHandler();
        public CoordinateInputDialog()
        {
            InitializeComponent();
            _leftTopX.TextChanged += DetectEnableOk;
            _leftTopY.TextChanged += DetectEnableOk;
            _rightDownX.TextChanged += DetectEnableOk;
            _rightDownY.TextChanged += DetectEnableOk;
            _okButton.Enabled = false;
            _leftTopX.AccessibleName = Constant.TOP_LEFT_X;
            _leftTopY.AccessibleName = Constant.TOP_LEFT_Y;
            _rightDownX.AccessibleName = Constant.BOTTOM_RIGHT_X;
            _rightDownY.AccessibleName = Constant.BOTTOM_RIGHT_Y;
        }

        //public Point _topLeft => new Point(
        //    int.Parse(_leftTopX.Text),
        //    int.Parse(_leftTopY.Text)
        //);

        //public Point BottomRight => new Point(
        //    int.Parse(_rightDownX.Text),
        //    int.Parse(_rightDownY.Text)
        //);
        public Point _topLeft
        {
            get;
            set;
        }
        public Point _downRight
        {
            get;
            set;
        }

        //ok
        private void ClickEnableOk(object sender, EventArgs e)
        {
            Debug.Assert(int.TryParse(_leftTopX.Text,out int leftX));
            Debug.Assert(int.TryParse(_leftTopY.Text, out int leftY));
            Debug.Assert(int.TryParse(_rightDownX.Text, out int rightX));
            Debug.Assert(int.TryParse(_rightDownY.Text, out int rightY));
            _topLeft = new Point(leftX, leftY);
            _downRight = new Point(rightX, rightY);
        }

        //district
        private void DetectEnableOk(object sender, EventArgs e)
        {
            if (int.TryParse(_leftTopX.Text, out int leftX) &&
                int.TryParse(_leftTopY.Text, out int leftY) &&
                int.TryParse(_rightDownX.Text, out int rightX) &&
                int.TryParse(_rightDownY.Text, out int rightY))
            {
                _topLeft = new Point(leftX, leftY);
                _downRight = new Point(rightX, rightY);
                _okButton.Enabled = true;
            }
            else
            {
                _okButton.Enabled = false;
            }
        }
    }
}
