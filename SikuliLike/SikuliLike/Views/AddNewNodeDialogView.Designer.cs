﻿namespace SikuliLike.Views
{
    partial class AddNewNodeDialogView
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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._titleLabel = new System.Windows.Forms.Label();
            this._actionLabel = new System.Windows.Forms.Label();
            this._titleTextBox = new System.Windows.Forms.TextBox();
            this._actionsComboBox = new System.Windows.Forms.ComboBox();
            this._captureAreaButton = new System.Windows.Forms.Button();
            this._imageLocationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._okButton.Location = new System.Drawing.Point(326, 215);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(120, 40);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OnOkayClicked);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(452, 215);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(120, 40);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.OnCancelClicked);
            // 
            // _titleLabel
            // 
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._titleLabel.Location = new System.Drawing.Point(12, 33);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(39, 17);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "Title:";
            // 
            // _actionLabel
            // 
            this._actionLabel.AutoSize = true;
            this._actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._actionLabel.Location = new System.Drawing.Point(12, 67);
            this._actionLabel.Name = "_actionLabel";
            this._actionLabel.Size = new System.Drawing.Size(51, 17);
            this._actionLabel.TabIndex = 0;
            this._actionLabel.Text = "Action:";
            // 
            // _titleTextBox
            // 
            this._titleTextBox.Location = new System.Drawing.Point(77, 32);
            this._titleTextBox.Name = "_titleTextBox";
            this._titleTextBox.Size = new System.Drawing.Size(226, 20);
            this._titleTextBox.TabIndex = 1;
            this._titleTextBox.WordWrap = false;
            // 
            // _actionsComboBox
            // 
            this._actionsComboBox.FormattingEnabled = true;
            this._actionsComboBox.Location = new System.Drawing.Point(77, 66);
            this._actionsComboBox.Name = "_actionsComboBox";
            this._actionsComboBox.Size = new System.Drawing.Size(226, 21);
            this._actionsComboBox.TabIndex = 2;
            // 
            // _captureAreaButton
            // 
            this._captureAreaButton.Location = new System.Drawing.Point(126, 95);
            this._captureAreaButton.Name = "_captureAreaButton";
            this._captureAreaButton.Size = new System.Drawing.Size(115, 21);
            this._captureAreaButton.TabIndex = 3;
            this._captureAreaButton.Text = "Capture Area";
            this._captureAreaButton.UseVisualStyleBackColor = true;
            this._captureAreaButton.Click += new System.EventHandler(this.OnCaptureLocationClicked);
            // 
            // _imageLocationLabel
            // 
            this._imageLocationLabel.AutoSize = true;
            this._imageLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._imageLocationLabel.Location = new System.Drawing.Point(12, 97);
            this._imageLocationLabel.Name = "_imageLocationLabel";
            this._imageLocationLabel.Size = new System.Drawing.Size(108, 17);
            this._imageLocationLabel.TabIndex = 0;
            this._imageLocationLabel.Text = "Image Location:";
            // 
            // AddNewNodeDialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this._imageLocationLabel);
            this.Controls.Add(this._captureAreaButton);
            this.Controls.Add(this._actionsComboBox);
            this.Controls.Add(this._titleTextBox);
            this.Controls.Add(this._actionLabel);
            this.Controls.Add(this._titleLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewNodeDialogView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New State";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.Label _actionLabel;
        private System.Windows.Forms.TextBox _titleTextBox;
        private System.Windows.Forms.ComboBox _actionsComboBox;
        private System.Windows.Forms.Button _captureAreaButton;
        private System.Windows.Forms.Label _imageLocationLabel;
    }
}