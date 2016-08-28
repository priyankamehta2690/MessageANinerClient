namespace MessageANiner.UserControls
{
    partial class ContactControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.MessageCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 0);
            this.label.MaximumSize = new System.Drawing.Size(100, 0);
            this.label.MinimumSize = new System.Drawing.Size(100, 30);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(100, 30);
            this.label.TabIndex = 0;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::MessageANiner.Properties.Resources.caution;
            this.pictureBox.Location = new System.Drawing.Point(102, 8);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(15, 14);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // MessageCount
            // 
            this.MessageCount.AutoSize = true;
            this.MessageCount.BackColor = System.Drawing.Color.Green;
            this.MessageCount.Location = new System.Drawing.Point(122, 8);
            this.MessageCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MessageCount.Name = "MessageCount";
            this.MessageCount.Size = new System.Drawing.Size(0, 13);
            this.MessageCount.TabIndex = 4;
            // 
            // ContactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessageCount);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label);
            this.Name = "ContactControl";
            this.Size = new System.Drawing.Size(140, 31);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label MessageCount;
    }
}
