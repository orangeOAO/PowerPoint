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
using PowerPoint.IState;
using PowerPoint.ShowModel;

namespace PowerPoint
{
    public partial class Form1 : Form
    {

        public Form1(Model model)
        {
            _model = model;
            _showModel = new ShowModel.ShowModel(_model);
            _showModel._modelChanged += HandleModelChanged;
            _showModel._cursorChanged += SetCursor;
            _showModel._undoRedoHistoryChanged += HandleUndoRedoButton;

            
            InitializeComponent();
            InitializeDataGridView();
            InitializePanel();
            HandleUndoRedoButton(false, false);
            BindingFunction();
            this.KeyDown += Form1KeyDown;
            this.KeyPreview = true;
        }


        //initializeDatagridview
        private void InitializeDataGridView()
        {
            _dataGridView1.DataSource = _showModel.GetShapes();
            _dataGridView1.Columns["IsShapeSelected"].Visible = false;
            _dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetDataGridView1CellContentClick);
            _dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dataGridView1.Columns[Constant.TWO].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        }

        //initializeForm
        private void InitializePanel()
        {
            _Drawingpanel.MouseDown += HandleCanvasPressed;
            _Drawingpanel.MouseUp += HandleCanvasReleased;
            _Drawingpanel.MouseMove += HandleCanvasMoved;
            _Drawingpanel.Paint += HandleCanvasPaint;
            _buttonTemporary1.Paint += HandleCanvasPaintOnButton;
            splitContainerLeft.Panel1.Resize += (sender, e) => HandleContainerResize();
            splitContainerLeft.Resize += (sender, e) => HandleContainerResize();
            splitContainerRight.Panel1.Resize += (sender, args) => HandleContainerResize();
            splitContainerRight.Resize += (sender, args) => HandleContainerResize();
        }

        /// handle resize
        public void HandleContainerResize()
        {
            _buttonTemporary1.Width = splitContainerLeft.Panel1.Width - Constant.EIGHT;
            _buttonTemporary1.Height = (int)(_buttonTemporary1.Width * Constant.RATIO);
            _Drawingpanel.Width = splitContainerRight.Panel1.Width - Constant.EIGHT;
            _Drawingpanel.Height = (int)(_Drawingpanel.Width * Constant.RATIO);
            _showModel.ResizeCanvas(_Drawingpanel.Width, _Drawingpanel.Height);
        }

        //binding
        public void BindingFunction()
        {
            _lineButton.DataBindings.Add(Constant.CHECKED, _showModel, Constant.IS_LINE_CHECKED);
            _rectangleButton.DataBindings.Add(Constant.CHECKED, _showModel, Constant.IS_RECTANGLE_CHECKED);
            _circleButton.DataBindings.Add(Constant.CHECKED, _showModel, Constant.IS_CIRCLE_CHECKED);
            _selectButton.DataBindings.Add(Constant.CHECKED, _showModel, Constant.IS_MOUSE_CHECKED);
        }

        /// handle
        public void HandleUndoRedoButton(bool isUndo, bool isRedo)
        {
            _undoButton.Enabled = isUndo;
            _redoButton.Enabled = isRedo;
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
        }

        //HandleMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _showModel.MovedPointer(new Point(e.X, e.Y));
        }

        /// set
        public void SetCursor(Cursor cursor)
        {
            Cursor = cursor;
        }

        //Paint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            _showModel.Draw(e.Graphics);
        }

        //button
        public void HandleCanvasPaintOnButton(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            float scaleX = (float)_buttonTemporary1.Width / _Drawingpanel.Width;
            float scaleY = (float)_buttonTemporary1.Height / _Drawingpanel.Height;
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

        /// undo
        public void HandleUndoButtonClick(object sender, EventArgs e)
        {
            _showModel.Undo();
        }

        /// redo
        public void HandleRedoButtonClick(object sender, EventArgs e)
        {
            _showModel.Redo();
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
            _showModel.HandleButtonClick((int)ShapeType.CIRCLE);
        }

        //lineclick
        private void ClickLineButton(object sender, EventArgs e)
        {
            _showModel.HandleButtonClick((int)ShapeType.LINE);
        }

        //rectangleclick
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _showModel.HandleButtonClick((int)ShapeType.RECTANGLE);
        }

        //select
        private void ClickSelectButton(object sender, EventArgs e)
        {
            _showModel.HandleButtonClick((int)ShapeType.ARROW);
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
