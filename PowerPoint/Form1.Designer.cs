using System.Windows.Forms;
using WindowPowerPoint;

namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._help = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._addPage = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this._page1 = new System.Windows.Forms.Button();
            this._dataGridView2 = new System.Windows.Forms.DataGridView();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._deleteShape = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._button1 = new System.Windows.Forms.Button();
            this._Drawingpanel = new PowerPoint.Panel2();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this._circleButton = new WindowPowerPoint.BindingToolStripButton();
            this._lineButton = new WindowPowerPoint.BindingToolStripButton();
            this._rectangleButton = new WindowPowerPoint.BindingToolStripButton();
            this._selectButton = new WindowPowerPoint.BindingToolStripButton();
            this._menuStrip1.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this._Drawingpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip1
            // 
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._help});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menuStrip1.Size = new System.Drawing.Size(1259, 30);
            this._menuStrip1.TabIndex = 5;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _help
            // 
            this._help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._help.Name = "_help";
            this._help.Size = new System.Drawing.Size(53, 26);
            this._help.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._circleButton,
            this._lineButton,
            this._rectangleButton,
            this._selectButton,
            this._addPage,
            this._undoButton,
            this._redoButton});
            this._toolStrip1.Location = new System.Drawing.Point(0, 30);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1259, 31);
            this._toolStrip1.TabIndex = 6;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _addPage
            // 
            this._addPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._addPage.Image = ((System.Drawing.Image)(resources.GetObject("_addPage.Image")));
            this._addPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addPage.Name = "_addPage";
            this._addPage.Size = new System.Drawing.Size(29, 28);
            this._addPage.Text = "+";
            this._addPage.Click += new System.EventHandler(this._addPage_Click);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(29, 28);
            this._undoButton.Text = "↶";
            this._undoButton.Click += new System.EventHandler(this.HandleUndoButtonClick);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(29, 28);
            this._redoButton.Text = "↷";
            this._redoButton.Click += new System.EventHandler(this.HandleRedoButtonClick);
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 61);
            this.splitContainerLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerLeft.Name = "splitContainerLeft";
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this._page1);
            this.splitContainerLeft.Panel1.Controls.Add(this._dataGridView2);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainerLeft.Size = new System.Drawing.Size(1259, 636);
            this.splitContainerLeft.SplitterDistance = 172;
            this.splitContainerLeft.TabIndex = 8;
            // 
            // _page1
            // 
            this._page1.Location = new System.Drawing.Point(0, 0);
            this._page1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._page1.Name = "_page1";
            this._page1.Size = new System.Drawing.Size(168, 70);
            this._page1.TabIndex = 5;
            this._page1.UseVisualStyleBackColor = true;
            // 
            // _dataGridView2
            // 
            this._dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView2.Location = new System.Drawing.Point(3, 2);
            this._dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dataGridView2.Name = "_dataGridView2";
            this._dataGridView2.RowHeadersWidth = 51;
            this._dataGridView2.RowTemplate.Height = 27;
            this._dataGridView2.Size = new System.Drawing.Size(171, 637);
            this._dataGridView2.TabIndex = 2;
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerRight.Name = "splitContainerRight";
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this._Drawingpanel);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this._comboBox1);
            this.splitContainerRight.Panel2.Controls.Add(this._dataGridView1);
            this.splitContainerRight.Panel2.Controls.Add(this._button1);
            this.splitContainerRight.Size = new System.Drawing.Size(1083, 636);
            this.splitContainerRight.SplitterDistance = 735;
            this.splitContainerRight.TabIndex = 0;
            // 
            // _comboBox1
            // 
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Items.AddRange(new object[] {
            "圓形",
            "線",
            "矩形"});
            this._comboBox1.Location = new System.Drawing.Point(131, 34);
            this._comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(133, 23);
            this._comboBox1.TabIndex = 5;
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToDeleteRows = false;
            this._dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteShape,
            this._shape,
            this._information});
            this._dataGridView1.Location = new System.Drawing.Point(18, 84);
            this._dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.ReadOnly = true;
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(287, 545);
            this._dataGridView1.TabIndex = 0;
            // 
            // _deleteShape
            // 
            this._deleteShape.FillWeight = 69.39502F;
            this._deleteShape.HeaderText = "刪除";
            this._deleteShape.MinimumWidth = 6;
            this._deleteShape.Name = "_deleteShape";
            this._deleteShape.ReadOnly = true;
            this._deleteShape.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteShape.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteShape.Text = "刪除";
            this._deleteShape.UseColumnTextForButtonValue = true;
            // 
            // _shape
            // 
            this._shape.DataPropertyName = "_shape";
            this._shape.FillWeight = 75.70177F;
            this._shape.HeaderText = "形狀";
            this._shape.MinimumWidth = 6;
            this._shape.Name = "_shape";
            this._shape.ReadOnly = true;
            // 
            // _information
            // 
            this._information.DataPropertyName = "_information";
            this._information.FillWeight = 154.9032F;
            this._information.HeaderText = "資訊";
            this._information.MinimumWidth = 6;
            this._information.Name = "_information";
            this._information.ReadOnly = true;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(18, 20);
            this._button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(89, 48);
            this._button1.TabIndex = 4;
            this._button1.Text = "新增";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // _Drawingpanel
            // 
            this._Drawingpanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._Drawingpanel.Controls.Add(this.splitter1);
            this._Drawingpanel.Location = new System.Drawing.Point(8, 20);
            this._Drawingpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._Drawingpanel.Name = "_Drawingpanel";
            this._Drawingpanel.Size = new System.Drawing.Size(685, 298);
            this._Drawingpanel.TabIndex = 11;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 298);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(29, 28);
            this._circleButton.Text = "◯";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(29, 28);
            this._lineButton.Text = "╱";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(29, 28);
            this._rectangleButton.Text = "⬜";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _selectButton
            // 
            this._selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._selectButton.Image = ((System.Drawing.Image)(resources.GetObject("_selectButton.Image")));
            this._selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._selectButton.Name = "_selectButton";
            this._selectButton.Size = new System.Drawing.Size(29, 28);
            this._selectButton.Text = "↗";
            this._selectButton.ToolTipText = "↗";
            this._selectButton.Click += new System.EventHandler(this.ClickSelectButton);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 697);
            this.Controls.Add(this.splitContainerLeft);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this._menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView2)).EndInit();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this._Drawingpanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingToolStripButton _circleButton;
        private BindingToolStripButton _lineButton;
        private BindingToolStripButton _rectangleButton;
        private BindingToolStripButton _selectButton;

        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _help;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private ShowModel.ShowModel _showModel;
        private Model _model;
        
        private System.Windows.Forms.ToolStripButton _undoButton;
        private System.Windows.Forms.ToolStripButton _redoButton;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.Button _page1;
        private System.Windows.Forms.DataGridView _dataGridView2;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private Panel2 _Drawingpanel;
        private System.Windows.Forms.Splitter splitter1;
        private ToolStripButton _addPage;
    }
}

