namespace SikuliLike.Views
{
    partial class SikuliLikeMainView
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
            this._stateListBox = new System.Windows.Forms.ListBox();
            this._addNewStateButton = new System.Windows.Forms.Button();
            this._previewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _stateListBox
            // 
            this._stateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._stateListBox.FormattingEnabled = true;
            this._stateListBox.Location = new System.Drawing.Point(13, 13);
            this._stateListBox.Name = "_stateListBox";
            this._stateListBox.Size = new System.Drawing.Size(188, 485);
            this._stateListBox.TabIndex = 0;
            this._stateListBox.SelectedIndexChanged += new System.EventHandler(this.StateSelectedChanged);
            // 
            // _addNewStateButton
            // 
            this._addNewStateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addNewStateButton.Location = new System.Drawing.Point(12, 515);
            this._addNewStateButton.Name = "_addNewStateButton";
            this._addNewStateButton.Size = new System.Drawing.Size(189, 34);
            this._addNewStateButton.TabIndex = 1;
            this._addNewStateButton.Text = "Add New State";
            this._addNewStateButton.UseVisualStyleBackColor = true;
            this._addNewStateButton.Click += new System.EventHandler(this.ClickedAddNewState);
            // 
            // _previewPictureBox
            // 
            this._previewPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._previewPictureBox.Location = new System.Drawing.Point(207, 13);
            this._previewPictureBox.Name = "_previewPictureBox";
            this._previewPictureBox.Size = new System.Drawing.Size(565, 485);
            this._previewPictureBox.TabIndex = 2;
            this._previewPictureBox.TabStop = false;
            // 
            // SikuliLikeMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this._previewPictureBox);
            this.Controls.Add(this._addNewStateButton);
            this.Controls.Add(this._stateListBox);
            this.Name = "SikuliLikeMainView";
            this.Text = "SikuliLike";
            ((System.ComponentModel.ISupportInitialize)(this._previewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _stateListBox;
        private System.Windows.Forms.Button _addNewStateButton;
        private System.Windows.Forms.PictureBox _previewPictureBox;
    }
}

