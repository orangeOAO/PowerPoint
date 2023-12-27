
namespace PowerPoint
{
    partial class CoordinateInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._leftTopX = new System.Windows.Forms.TextBox();
            this._leftTopLabel = new System.Windows.Forms.Label();
            this._leftTopY = new System.Windows.Forms.TextBox();
            this._leftTopLabel2 = new System.Windows.Forms.Label();
            this._rightDownY = new System.Windows.Forms.TextBox();
            this._rightDownLabel2 = new System.Windows.Forms.Label();
            this._rightDownX = new System.Windows.Forms.TextBox();
            this._rightDownLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _leftTopX
            // 
            this._leftTopX.Location = new System.Drawing.Point(43, 123);
            this._leftTopX.Name = "_leftTopX";
            this._leftTopX.Size = new System.Drawing.Size(100, 25);
            this._leftTopX.TabIndex = 0;
            // 
            // _leftTopLabel
            // 
            this._leftTopLabel.AutoSize = true;
            this._leftTopLabel.Location = new System.Drawing.Point(51, 105);
            this._leftTopLabel.Name = "_leftTopLabel";
            this._leftTopLabel.Size = new System.Drawing.Size(92, 15);
            this._leftTopLabel.TabIndex = 1;
            this._leftTopLabel.Text = "左上角座標X";
            // 
            // _leftTopY
            // 
            this._leftTopY.Location = new System.Drawing.Point(239, 123);
            this._leftTopY.Name = "_leftTopY";
            this._leftTopY.Size = new System.Drawing.Size(100, 25);
            this._leftTopY.TabIndex = 0;
            // 
            // _leftTopLabel2
            // 
            this._leftTopLabel2.AutoSize = true;
            this._leftTopLabel2.Location = new System.Drawing.Point(247, 105);
            this._leftTopLabel2.Name = "_leftTopLabel2";
            this._leftTopLabel2.Size = new System.Drawing.Size(92, 15);
            this._leftTopLabel2.TabIndex = 1;
            this._leftTopLabel2.Text = "左上角座標Y";
            // 
            // _rightDownY
            // 
            this._rightDownY.Location = new System.Drawing.Point(250, 226);
            this._rightDownY.Name = "_rightDownY";
            this._rightDownY.Size = new System.Drawing.Size(100, 25);
            this._rightDownY.TabIndex = 0;
            // 
            // _rightDownLabel2
            // 
            this._rightDownLabel2.AutoSize = true;
            this._rightDownLabel2.Location = new System.Drawing.Point(258, 208);
            this._rightDownLabel2.Name = "_rightDownLabel2";
            this._rightDownLabel2.Size = new System.Drawing.Size(92, 15);
            this._rightDownLabel2.TabIndex = 1;
            this._rightDownLabel2.Text = "右下角座標Y";
            // 
            // _rightDownX
            // 
            this._rightDownX.Location = new System.Drawing.Point(43, 226);
            this._rightDownX.Name = "_rightDownX";
            this._rightDownX.Size = new System.Drawing.Size(100, 25);
            this._rightDownX.TabIndex = 0;
            // 
            // _rightDownLabel
            // 
            this._rightDownLabel.AutoSize = true;
            this._rightDownLabel.Location = new System.Drawing.Point(51, 208);
            this._rightDownLabel.Name = "_rightDownLabel";
            this._rightDownLabel.Size = new System.Drawing.Size(92, 15);
            this._rightDownLabel.TabIndex = 1;
            this._rightDownLabel.Text = "右下角座標X";
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(54, 285);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(89, 37);
            this._okButton.TabIndex = 2;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(261, 285);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(78, 37);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // CoordinateInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._rightDownLabel);
            this.Controls.Add(this._rightDownLabel2);
            this.Controls.Add(this._leftTopLabel2);
            this.Controls.Add(this._leftTopLabel);
            this.Controls.Add(this._rightDownX);
            this.Controls.Add(this._rightDownY);
            this.Controls.Add(this._leftTopY);
            this.Controls.Add(this._leftTopX);
            this.Name = "CoordinateInputDialog";
            this.Text = "CoordinateInputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _leftTopX;
        private System.Windows.Forms.Label _leftTopLabel;
        private System.Windows.Forms.TextBox _leftTopY;
        private System.Windows.Forms.Label _leftTopLabel2;
        private System.Windows.Forms.TextBox _rightDownY;
        private System.Windows.Forms.Label _rightDownLabel2;
        private System.Windows.Forms.TextBox _rightDownX;
        private System.Windows.Forms.Label _rightDownLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}