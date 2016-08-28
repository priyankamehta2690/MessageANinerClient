namespace MessageANiner.UserControls
{
    partial class AddContacts
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
            this.dataGridViewContactList = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblReturnMsg = new System.Windows.Forms.Label();
            this.buttonLookUp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactList)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewContactList
            // 
            this.dataGridViewContactList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContactList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewContactList.Location = new System.Drawing.Point(0, 80);
            this.dataGridViewContactList.Name = "dataGridViewContactList";
            this.dataGridViewContactList.Size = new System.Drawing.Size(582, 242);
            this.dataGridViewContactList.TabIndex = 5;
            this.dataGridViewContactList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContactList_CellClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblReturnMsg);
            this.pnlTop.Controls.Add(this.buttonLookUp);
            this.pnlTop.Controls.Add(this.textBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(582, 80);
            this.pnlTop.TabIndex = 6;
            // 
            // lblReturnMsg
            // 
            this.lblReturnMsg.AutoSize = true;
            this.lblReturnMsg.Location = new System.Drawing.Point(356, 40);
            this.lblReturnMsg.Name = "lblReturnMsg";
            this.lblReturnMsg.Size = new System.Drawing.Size(0, 13);
            this.lblReturnMsg.TabIndex = 7;
            // 
            // buttonLookUp
            // 
            this.buttonLookUp.Location = new System.Drawing.Point(258, 31);
            this.buttonLookUp.Name = "buttonLookUp";
            this.buttonLookUp.Size = new System.Drawing.Size(75, 23);
            this.buttonLookUp.TabIndex = 6;
            this.buttonLookUp.Text = "Look Up";
            this.buttonLookUp.UseVisualStyleBackColor = true;
            this.buttonLookUp.Click += new System.EventHandler(this.buttonLookUp_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 5;
            // 
            // AddContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewContactList);
            this.Controls.Add(this.pnlTop);
            this.Name = "AddContacts";
            this.Size = new System.Drawing.Size(582, 322);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContactList;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button buttonLookUp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblReturnMsg;

    }
}
