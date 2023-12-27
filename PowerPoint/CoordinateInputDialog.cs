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
        public event TextChangedEventHandler _textChange;
        public CoordinateInputDialog()
        {
            
            InitializeComponent();
            _leftTopX.TextChanged += DetectEnableOK;
            _leftTopY.TextChanged += DetectEnableOK;
            _rightDownX.TextChanged += DetectEnableOK;
            _rightDownY.TextChanged += DetectEnableOK;
            _okButton.Enabled = false;

        }

        //public Point TopLeft => new Point(
        //    int.Parse(_leftTopX.Text),
        //    int.Parse(_leftTopY.Text)
        //);

        //public Point BottomRight => new Point(
        //    int.Parse(_rightDownX.Text),
        //    int.Parse(_rightDownY.Text)
        //);
        public Point TopLeft;
        public Point DownRight;

        //ok
        private void _okButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(int.TryParse(_leftTopX.Text,out int leftX));
            Debug.Assert(int.TryParse(_leftTopY.Text, out int leftY));
            Debug.Assert(int.TryParse(_rightDownX.Text, out int rightX));
            Debug.Assert(int.TryParse(_rightDownY.Text, out int rightY));
            TopLeft.X = leftX;
            TopLeft.Y = leftY;
            DownRight.X = rightX;
            DownRight.Y = rightY;


        }

        //district
        private void DetectEnableOK(object sender, EventArgs e)
        {
            if (int.TryParse(_leftTopX.Text, out int leftX) &&
                int.TryParse(_leftTopY.Text, out int leftY) &&
                int.TryParse(_rightDownX.Text, out int rightX) &&
                int.TryParse(_rightDownY.Text, out int rightY))
            {
                TopLeft = new Point(leftX, leftY);
                DownRight = new Point(rightX, rightY);
                _okButton.Enabled = true;
            }
            else
            {
                _okButton.Enabled = false;
            }
            Debug.WriteLine("OAO");
        }
    }
}
