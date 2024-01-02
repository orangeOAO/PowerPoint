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
            this._circleButton = new WindowPowerPoint.BindingToolStripButton();
            this._lineButton = new WindowPowerPoint.BindingToolStripButton();
            this._rectangleButton = new WindowPowerPoint.BindingToolStripButton();
            this._selectButton = new WindowPowerPoint.BindingToolStripButton();
            this._addPage = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this._pagePanel = new System.Windows.Forms.Panel();
            this._splitContainerRight = new System.Windows.Forms.SplitContainer();
            this._drawPanel = new PowerPoint.Panel2();
            this._split = new System.Windows.Forms.Splitter();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._deleteShape = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._button1 = new System.Windows.Forms.Button();
            this._menuStrip1.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerLeft)).BeginInit();
            this._splitContainerLeft.Panel1.SuspendLayout();
            this._splitContainerLeft.Panel2.SuspendLayout();
            this._splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerRight)).BeginInit();
            this._splitContainerRight.Panel1.SuspendLayout();
            this._splitContainerRight.Panel2.SuspendLayout();
            this._splitContainerRight.SuspendLayout();
            this._drawPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
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
            this._menuStrip1.Size = new System.Drawing.Size(1257, 27);
            this._menuStrip1.TabIndex = 5;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _help
            // 
            this._help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._help.Name = "_help";
            this._help.Size = new System.Drawing.Size(53, 23);
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
            this._toolStrip1.Location = new System.Drawing.Point(0, 27);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1257, 26);
            this._toolStrip1.TabIndex = 6;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(29, 23);
            this._circleButton.Text = "◯";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._lineButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineButton.Image")));
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(29, 23);
            this._lineButton.Text = "╱";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleButton.Image")));
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(29, 23);
            this._rectangleButton.Text = "⬜";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _selectButton
            // 
            this._selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._selectButton.Image = ((System.Drawing.Image)(resources.GetObject("_selectButton.Image")));
            this._selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._selectButton.Name = "_selectButton";
            this._selectButton.Size = new System.Drawing.Size(29, 23);
            this._selectButton.Text = "↗";
            this._selectButton.ToolTipText = "↗";
            this._selectButton.Click += new System.EventHandler(this.ClickSelectButton);
            // 
            // _addPage
            // 
            this._addPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._addPage.Image = ((System.Drawing.Image)(resources.GetObject("_addPage.Image")));
            this._addPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addPage.Name = "_addPage";
            this._addPage.Size = new System.Drawing.Size(29, 23);
            this._addPage.Text = "+";
            this._addPage.Click += new System.EventHandler(this._addPageClick);
            // 
            // _undoButton
            // 
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(29, 23);
            this._undoButton.Text = "↶";
            this._undoButton.Click += new System.EventHandler(this.HandleUndoButtonClick);
            // 
            // _redoButton
            // 
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(29, 23);
            this._redoButton.Text = "↷";
            this._redoButton.Click += new System.EventHandler(this.HandleRedoButtonClick);
            // 
            // _splitContainerLeft
            // 
            this._splitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerLeft.Location = new System.Drawing.Point(0, 53);
            this._splitContainerLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainerLeft.Name = "_splitContainerLeft";
            // 
            // _splitContainerLeft.Panel1
            // 
            this._splitContainerLeft.Panel1.Controls.Add(this._pagePanel);
            // 
            // _splitContainerLeft.Panel2
            // 
            this._splitContainerLeft.Panel2.Controls.Add(this._splitContainerRight);
            this._splitContainerLeft.Size = new System.Drawing.Size(1257, 644);
            this._splitContainerLeft.SplitterDistance = 171;
            this._splitContainerLeft.TabIndex = 8;
            // 
            // _pagePanel
            // 
            this._pagePanel.AutoSize = true;
            this._pagePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pagePanel.Location = new System.Drawing.Point(0, 0);
            this._pagePanel.Name = "_pagePanel";
            this._pagePanel.Size = new System.Drawing.Size(167, 640);
            this._pagePanel.TabIndex = 0;
            // 
            // _splitContainerRight
            // 
            this._splitContainerRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this._splitContainerRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._splitContainerRight.Name = "_splitContainerRight";
            // 
            // _splitContainerRight.Panel1
            // 
            this._splitContainerRight.Panel1.Controls.Add(this._drawPanel);
            // 
            // _splitContainerRight.Panel2
            // 
            this._splitContainerRight.Panel2.Controls.Add(this._comboBox1);
            this._splitContainerRight.Panel2.Controls.Add(this._dataGridView1);
            this._splitContainerRight.Panel2.Controls.Add(this._button1);
            this._splitContainerRight.Size = new System.Drawing.Size(1082, 644);
            this._splitContainerRight.SplitterDistance = 705;
            this._splitContainerRight.TabIndex = 0;
            // 
            // _drawPanel
            // 
            this._drawPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._drawPanel.Controls.Add(this._split);
            this._drawPanel.Location = new System.Drawing.Point(8, 20);
            this._drawPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._drawPanel.Name = "_drawPanel";
            this._drawPanel.Size = new System.Drawing.Size(685, 298);
            this._drawPanel.TabIndex = 11;
            // 
            // _split
            // 
            this._split.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._split.Location = new System.Drawing.Point(0, 0);
            this._split.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._split.Name = "_split";
            this._split.Size = new System.Drawing.Size(3, 298);
            this._split.TabIndex = 0;
            this._split.TabStop = false;
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
            this._comboBox1.Size = new System.Drawing.Size(167, 23);
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
            this._dataGridView1.Size = new System.Drawing.Size(316, 553);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 697);
            this.Controls.Add(this._splitContainerLeft);
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
            this._splitContainerLeft.Panel1.ResumeLayout(false);
            this._splitContainerLeft.Panel1.PerformLayout();
            this._splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerLeft)).EndInit();
            this._splitContainerLeft.ResumeLayout(false);
            this._splitContainerRight.Panel1.ResumeLayout(false);
            this._splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerRight)).EndInit();
            this._splitContainerRight.ResumeLayout(false);
            this._drawPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
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
        private System.Windows.Forms.SplitContainer _splitContainerLeft;
        private System.Windows.Forms.SplitContainer _splitContainerRight;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private Panel2 _drawPanel;
        private System.Windows.Forms.Splitter _split;
        private ToolStripButton _addPage;
        private Panel _pagePanel;
    }
}

