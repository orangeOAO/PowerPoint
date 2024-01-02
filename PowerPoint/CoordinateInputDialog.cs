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
            _leftTopX.TextChanged += DetectEnableOK;
            _leftTopY.TextChanged += DetectEnableOK;
            _rightDownX.TextChanged += DetectEnableOK;
            _rightDownY.TextChanged += DetectEnableOK;
            _okButton.Enabled = false;

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
        private void _okButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(int.TryParse(_leftTopX.Text,out int leftX));
            Debug.Assert(int.TryParse(_leftTopY.Text, out int leftY));
            Debug.Assert(int.TryParse(_rightDownX.Text, out int rightX));
            Debug.Assert(int.TryParse(_rightDownY.Text, out int rightY));
            _topLeft = new Point(leftX, leftY);
            _downRight = new Point(rightX, rightY);
        }

        //district
        private void DetectEnableOK(object sender, EventArgs e)
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
