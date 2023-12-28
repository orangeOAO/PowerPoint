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
        private List<KeyValuePair<Button, Panel>> _pageList;
        public Form1(Model model)
        {
            _model = model;
            _showModel = new ShowModel.ShowModel(_model);
            _showModel._modelChanged += HandleModelChanged;
            _showModel._cursorChanged += SetCursor;
            _showModel._undoRedoHistoryChanged += HandleUndoRedoButton;
            _pageList = new List<KeyValuePair<Button, Panel>>();
            
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
            _page1.Paint += HandleCanvasPaintOnButton;
            _page1.Click += HandleClickPage;
            _dataGridView2.Controls.Add(_page1);
            splitContainerLeft.Panel1.Resize += (sender, e) => HandleContainerResize();
            splitContainerLeft.Resize += (sender, e) => HandleContainerResize();
            splitContainerRight.Panel1.Resize += (sender, args) => HandleContainerResize();
            splitContainerRight.Resize += (sender, args) => HandleContainerResize();
        }

        /// handle resize
        public void HandleContainerResize()
        {
            for (int i = 2; i < _dataGridView2.Controls.Count; i++)
            {
                _dataGridView2.Controls[i].Width = splitContainerLeft.Panel1.Width - Constant.EIGHT;
                _dataGridView2.Controls[i].Height = (int)(_page1.Width * Constant.RATIO);
                _dataGridView2.Controls[i].Location = new Point(_page1.Location.X, (i - 2) * _page1.Height);
            }

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
            _showModel.SetDialogValue(_comboBox1.SelectedIndex);
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
            float scaleX = 0;
            float scaleY = 0;
            var button = (Button)sender;
            var index = _dataGridView2.Controls.IndexOf(button);
            for (int i = 1; i < _dataGridView2.Controls.Count; i++)
            {
                scaleX = (float)_dataGridView2.Controls[i].Width / _Drawingpanel.Width;
                scaleY = (float)_dataGridView2.Controls[i].Height / _Drawingpanel.Height;
            }
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
                //_dataGridView2.Controls.RemoveAt(0);
            }
        }

        //addPage
        private void _addPage_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            var width = _page1.Width;
            var height = _page1.Height;
            button.Name = $"page{_showModel.GetPageCount()+1}";
            button.Size = new Size(width, height);
            Debug.WriteLine(button.Name);
            button.Click += HandleClickPage;
            button.Location = new Point(_page1.Location.X, (4+_page1.Height)*_showModel.GetPageCount());
            _dataGridView2.Controls.Add(button);
            _showModel.AddPage();
        }

        //Page
        public void HandleClickPage(object sender, EventArgs e)
        {
            Invalidate();
            var button = (Button)sender;
            var index = _dataGridView2.Controls.IndexOf(button);
            index -= 2;
            button.Paint += HandleCanvasPaintOnButton;
            _showModel.SetPageIndex(index);
            _dataGridView1.DataSource = _showModel.GetShapes();
        }
    }
}
