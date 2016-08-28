namespace MessageANiner.Settings
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.textBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelCurrentPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelConfirmNewPassword = new System.Windows.Forms.Label();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCurrentPassword
            // 
            this.textBoxCurrentPassword.Location = new System.Drawing.Point(159, 50);
            this.textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            this.textBoxCurrentPassword.PasswordChar = '*';
            this.textBoxCurrentPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentPassword.TabIndex = 0;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(159, 79);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPassword.TabIndex = 1;
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(159, 107);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.PasswordChar = '*';
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxConfirmPassword.TabIndex = 2;
            // 
            // labelCurrentPassword
            // 
            this.labelCurrentPassword.AutoSize = true;
            this.labelCurrentPassword.Location = new System.Drawing.Point(12, 57);
            this.labelCurrentPassword.Name = "labelCurrentPassword";
            this.labelCurrentPassword.Size = new System.Drawing.Size(90, 13);
            this.labelCurrentPassword.TabIndex = 3;
            this.labelCurrentPassword.Text = "Current Password";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(12, 86);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(78, 13);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "New Password";
            // 
            // labelConfirmNewPassword
            // 
            this.labelConfirmNewPassword.AutoSize = true;
            this.labelConfirmNewPassword.Location = new System.Drawing.Point(12, 114);
            this.labelConfirmNewPassword.Name = "labelConfirmNewPassword";
            this.labelConfirmNewPassword.Size = new System.Drawing.Size(116, 13);
            this.labelConfirmNewPassword.TabIndex = 5;
            this.labelConfirmNewPassword.Text = "Confirm New Password";
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(70, 153);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(118, 23);
            this.buttonChangePassword.TabIndex = 6;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.labelConfirmNewPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelCurrentPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.textBoxCurrentPassword);
            this.Name = "ChangePassword";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCurrentPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelCurrentPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelConfirmNewPassword;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}