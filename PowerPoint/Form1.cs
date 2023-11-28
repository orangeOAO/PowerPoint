using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPoint.ShowModel;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _dataGridView1.DataSource = _showModel.GetShapes();
            _showModel._modelChanged += HandleModelChanged;
            _panel1.MouseDown += HandleCanvasPressed;
            _panel1.MouseUp += HandleCanvasReleased;
            _panel1.MouseMove += HandleCanvasMoved;
            _panel1.Paint += HandleCanvasPaint;
            this.KeyDown += Form1KeyDown;
            this.KeyPreview = true;
            //for (int i = 0; i < _showModel.ToolClick.Length; i++)
            //{
            //    ToolStripButton button = (ToolStripButton)_toolStrip1.Items[i];
            //    button.DataBindings.Add("Checked", _toolbarModel, $"ButtonChecked[{i}]", true, DataSourceUpdateMode.OnPropertyChanged);
            //}
        }
        
        //按下新增
        private void Button1Click(object sender, EventArgs e)
        {
            _showModel.InsertShape((ShapeType)(_comboBox1.SelectedIndex));
        }
        
        //HandlePress
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _showModel.PressedPointer(new Point(e.X, e.Y));
        }

        //HandleRelease
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _showModel.ReleasedPointer(new Point(e.X, e.Y));
            Cursor = Cursors.Arrow;
            ToolStripButton[] buttonArray = { _lineButton, _rectangleButton, _circleButton };
            _showModel.ReleaseButtonClick(buttonArray);
            this.HandleSelectButtonClick();
            // Debug.Print("release");
        }

        //HandleMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _showModel.MovedPointer(new Point(e.X, e.Y));
            if (_showModel.ChangeCursor(new Point(e.X, e.Y)))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }

        //Paint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _showModel.Draw(e.Graphics);
        }

        //button
        public void HandleCanvasPaintOnButton(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            float scaleX = (float)_buttonTemporary1.Width / _panel1.Width;
            float scaleY = (float)_buttonTemporary1.Height / _panel1.Height;
            float scale = Math.Min(scaleX, scaleY);
            Matrix array = new Matrix();
            array.Scale(scale, scale);
            e.Graphics.Transform = array;
            _showModel.Draw(e.Graphics);
        }

        //HandleChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //HandleShapeButton
        public void HandleShapeButton(ShapeType type)
        {
            State state;
            state = new DrawingState(type);
            _showModel.SetState(state);
            _showModel.ClearSelectBox();
            ToolStripButton[] buttonArray = { _lineButton, _rectangleButton, _circleButton, _selectButton };
            _showModel.HandleButtonClick(buttonArray, (int)type);
            Cursor = Cursors.Cross;
        }

        //HandleSelectButton
        public void HandleSelectButtonClick()
        {
            State state = new PointState();
            _showModel.SetState(state);
            ToolStripButton[] buttonArray = { _lineButton, _rectangleButton, _circleButton, _selectButton };
            _showModel.HandleButtonClick(buttonArray, Constant.SELECT_BUTTON);
        }

        //CreateCell
        private void SetDataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView1.Columns[e.ColumnIndex].Name == Constant.DELETE_BUTTON)
            {
                _showModel.DeleteShape(e.RowIndex);
            }
        }

        //circleclick
        private void ClickCircleButton(object sender, EventArgs e)
        {
            HandleShapeButton(ShapeType.CIRCLE);
        }

        //lineclick
        private void ClickLineButton(object sender, EventArgs e)
        {
            HandleShapeButton(ShapeType.LINE);
        }

        //rectangleclick
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            HandleShapeButton(ShapeType.RECTANGLE);
        }

        //select
        private void ClickSelectButton(object sender, EventArgs e)
        {
            HandleSelectButtonClick();
        }

        //DetectDelete
        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _showModel.DeleteSelectShape();
            }
        }
    }
}
