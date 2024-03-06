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
        private List<Bitmap> _bitmapsList;

        public Form1(Model model)
        {
            _bitmapsList = new List<Bitmap>();
            _model = model;
            _showModel = new ShowModel.ShowModel(_model);
            _showModel._modelChanged += HandleModelChanged;
            _showModel._cursorChanged += SetCursor;
            _showModel._undoRedoHistoryChanged += HandleUndoRedoButton;
            //this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitializePage();
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
            _dataGridView1.Columns[Constant.IS_SHAPE_SELECTED].Visible = false;
            _dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetDataGridView1CellContentClick);
            _dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dataGridView1.Columns[Constant.TWO].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //_splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        }

        //handlepage
        public void InitializePage()
        {
            Button button = new Button();
            button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            button.Click += HandleClickPage;
            button.Location = new Point(0, 0);
            button.Name = Constant.BUTTON_NAME;
            button.Size = new Size(Constant.BUTTON_WIDTH, Constant.BUTTON_HEIGHT);
            //button.Paint += HandleCanvasPaintOnButton;
            _pagePanel.Controls.Add(button);
        }

        //initializeForm
        private void InitializePanel()
        {
            _drawPanel.MouseDown += HandleCanvasPressed;
            _drawPanel.MouseUp += HandleCanvasReleased;
            _drawPanel.MouseMove += HandleCanvasMoved;
            _drawPanel.Paint += HandleCanvasPaint;
            _showModel.SetPageIndex(0);
            _bitmapsList.Add(new Bitmap(this._drawPanel.Width, this._drawPanel.Height));
            HandleContainerResize();
            _splitContainerLeft.Panel1.Resize += (sender, e) => HandleContainerResize();
            _splitContainerLeft.Resize += (sender, e) => HandleContainerResize();
            _splitContainerRight.Panel1.Resize += (sender, args) => HandleContainerResize();
            _splitContainerRight.Resize += (sender, args) => HandleContainerResize();
        }

        /// handle resize
        public void HandleContainerResize()
        {
            for (int i = 0; i < _pagePanel.Controls.Count; i++)
            {
                _pagePanel.Controls[i].Width = _splitContainerLeft.Panel1.Width - Constant.EIGHT;
                _pagePanel.Controls[i].Height = (int)(_pagePanel.Controls[i].Width * Constant.RATIO);
                _pagePanel.Controls[i].Location = new Point(0,i * _pagePanel.Controls[i].Height);
            }

            _drawPanel.Width = _splitContainerRight.Panel1.Width - Constant.EIGHT;
            _drawPanel.Height = (int)(_drawPanel.Width * Constant.RATIO);
            _drawPanel.Location = new Point((_splitContainerRight.Panel1.Width - _drawPanel.Width) / Constant.TWO, (_splitContainerRight.Panel1.Height - _drawPanel.Height) / Constant.TWO);

            _showModel.ResizeCanvas(_drawPanel.Width, _drawPanel.Height);
            GenerateBrief();
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
            var dialog = new CoordinateInputDialog();
            _showModel.SetDialogValue(_comboBox1.SelectedIndex, dialog);
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

        //HandleChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
            GenerateBrief();
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
                if (_pagePanel.Controls.Count != 1)
                {
                    _pagePanel.Controls.RemoveAt(_showModel.GetPageIndex());
                    _showModel.DeletePage();
                    HandleContainerResize();
                }
                //_pagePanel.Controls.RemoveAt(0);
            }
        }

        //brief
        private void GenerateBrief()
        {
            Bitmap brief = new Bitmap(this._drawPanel.Width, this._drawPanel.Height);
            this._drawPanel.DrawToBitmap(brief, new System.Drawing.Rectangle(0, 0, this._drawPanel.Width, this._drawPanel.Height));
            _bitmapsList[_showModel.GetPageIndex()] = brief;
            // slide1.Image = new Bitmap(_brief, slide1.Size);
            for (int i = 0; i < _showModel.GetPageCount(); i++)
            {
                _pagePanel.Controls[i].BackgroundImage = new Bitmap(_bitmapsList[i], _pagePanel.Controls[_showModel.GetPageIndex()].Size);
            }
        }

        //addPage
        private void ClickAddPage(object sender, EventArgs e)
        {
            Button button = new Button();
            button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            var width = _pagePanel.Controls[0].Width;
            var height = _pagePanel.Controls[0].Height;
            //button.Name = $"page{_showModel.GetPageCount()+1}";
            button.Size = new Size(width, height);
            button.Click += HandleClickPage;
            button.Name = Constant.BUTTON_NAME;
            button.Location = new Point(0, (height) * _showModel.GetPageCount());
            _pagePanel.Controls.Add(button);
            button.Focus();
            _showModel.AddPage();
            _bitmapsList.Add(new Bitmap(this._drawPanel.Width, this._drawPanel.Height));
            _showModel.SetPageIndex(_pagePanel.Controls.IndexOf(button));
            _dataGridView1.DataSource = _showModel.GetShapes();
            Invalidate(true);
        }

        //Page
        public void HandleClickPage(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var index = _pagePanel.Controls.IndexOf(button);
            _showModel.SetPageIndex(index);
            _dataGridView1.DataSource = _showModel.GetShapes();
            Invalidate(true);

        }
    }
}
