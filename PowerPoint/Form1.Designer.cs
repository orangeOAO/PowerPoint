
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
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this._button1 = new System.Windows.Forms.Button();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._dataGridView2 = new System.Windows.Forms.DataGridView();
            this._buttonTemporary1 = new System.Windows.Forms.Button();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._help = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._selectButton = new System.Windows.Forms.ToolStripButton();
            this._deleteShape = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panel1 = new PowerPoint.Panel2();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView2)).BeginInit();
            this._menuStrip1.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            this._panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._comboBox1);
            this._groupBox1.Controls.Add(this._button1);
            this._groupBox1.Controls.Add(this._dataGridView1);
            this._groupBox1.Location = new System.Drawing.Point(844, 70);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(388, 512);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "資料顯示";
            // 
            // _comboBox1
            // 
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓形"});
            this._comboBox1.Location = new System.Drawing.Point(231, 38);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(133, 23);
            this._comboBox1.TabIndex = 2;
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(89, 25);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(65, 48);
            this._button1.TabIndex = 1;
            this._button1.Text = "新增";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AllowUserToAddRows = false;
            this._dataGridView1.AllowUserToDeleteRows = false;
            this._dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteShape,
            this._shape,
            this._information});
            this._dataGridView1.Location = new System.Drawing.Point(23, 78);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.ReadOnly = true;
            this._dataGridView1.RowHeadersVisible = false;
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(409, 455);
            this._dataGridView1.TabIndex = 0;
            this._dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetDataGridView1CellContentClick);
            // 
            // _dataGridView2
            // 
            this._dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView2.Location = new System.Drawing.Point(12, 76);
            this._dataGridView2.Name = "_dataGridView2";
            this._dataGridView2.RowHeadersWidth = 51;
            this._dataGridView2.RowTemplate.Height = 27;
            this._dataGridView2.Size = new System.Drawing.Size(195, 505);
            this._dataGridView2.TabIndex = 1;
            // 
            // _buttonTemporary1
            // 
            this._buttonTemporary1.Location = new System.Drawing.Point(30, 88);
            this._buttonTemporary1.Name = "_buttonTemporary1";
            this._buttonTemporary1.Size = new System.Drawing.Size(163, 107);
            this._buttonTemporary1.TabIndex = 4;
            this._buttonTemporary1.UseVisualStyleBackColor = true;
            this._buttonTemporary1.Paint += new System.Windows.Forms.PaintEventHandler(this.HandleCanvasPaintOnButton);
            // 
            // _menuStrip1
            // 
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._help});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1232, 27);
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
            this._selectButton});
            this._toolStrip1.Location = new System.Drawing.Point(0, 27);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1232, 26);
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
            // _deleteShape
            // 
            this._deleteShape.HeaderText = "刪除";
            this._deleteShape.MinimumWidth = 6;
            this._deleteShape.Name = "_deleteShape";
            this._deleteShape.ReadOnly = true;
            this._deleteShape.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._deleteShape.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteShape.Text = "刪除";
            this._deleteShape.UseColumnTextForButtonValue = true;
            this._deleteShape.Width = 80;
            // 
            // _shape
            // 
            this._shape.DataPropertyName = "_shape";
            this._shape.HeaderText = "形狀";
            this._shape.MinimumWidth = 6;
            this._shape.Name = "_shape";
            this._shape.ReadOnly = true;
            this._shape.Width = 80;
            // 
            // _information
            // 
            this._information.DataPropertyName = "_information";
            this._information.HeaderText = "資訊";
            this._information.MinimumWidth = 6;
            this._information.Name = "_information";
            this._information.ReadOnly = true;
            this._information.Width = 200;
            // 
            // _panel1
            // 
            this._panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this._panel1.Location = new System.Drawing.Point(213, 76);
            this._panel1.Name = "_panel1";
            this._panel1.Size = new System.Drawing.Size(631, 506);
            this._panel1.TabIndex = 7;
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 589);
            this.Controls.Add(this._panel1);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._buttonTemporary1);
            this.Controls.Add(this._groupBox1);
            this.Controls.Add(this._dataGridView2);
            this.Controls.Add(this._menuStrip1);
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this._groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView2)).EndInit();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._panel1.ResumeLayout(false);
            this._panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel2 _panel1;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.DataGridView _dataGridView2;
        private System.Windows.Forms.Button _buttonTemporary1;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _help;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private ShowModel.ShowModel _showModel = new ShowModel.ShowModel();
        private System.Windows.Forms.ToolStripButton _circleButton;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _selectButton;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteShape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
    }
}

