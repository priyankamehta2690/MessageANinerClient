namespace MessageANiner.Login
{
    partial class LoginScreen
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripConnectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.labelEmailID = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.linkLabelSignUp = new System.Windows.Forms.LinkLabel();
            this.errorProviderEmailID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmailID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConnectedLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(420, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripConnectedLabel
            // 
            this.toolStripConnectedLabel.Name = "toolStripConnectedLabel";
            this.toolStripConnectedLabel.Size = new System.Drawing.Size(100, 17);
            this.toolStripConnectedLabel.Text = "Server Connected";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(175, 112);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(175, 186);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignIn.Location = new System.Drawing.Point(140, 273);
            this.buttonSignIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(102, 43);
            this.buttonSignIn.TabIndex = 3;
            this.buttonSignIn.Text = "Sign In";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // labelEmailID
            // 
            this.labelEmailID.AutoSize = true;
            this.labelEmailID.BackColor = System.Drawing.Color.Transparent;
            this.labelEmailID.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailID.Location = new System.Drawing.Point(102, 112);
            this.labelEmailID.Name = "labelEmailID";
            this.labelEmailID.Size = new System.Drawing.Size(61, 16);
            this.labelEmailID.TabIndex = 4;
            this.labelEmailID.Text = "User Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(102, 190);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(55, 16);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password";
            // 
            // linkLabelSignUp
            // 
            this.linkLabelSignUp.AutoSize = true;
            this.linkLabelSignUp.Location = new System.Drawing.Point(282, 321);
            this.linkLabelSignUp.Name = "linkLabelSignUp";
            this.linkLabelSignUp.Size = new System.Drawing.Size(98, 16);
            this.linkLabelSignUp.TabIndex = 7;
            this.linkLabelSignUp.TabStop = true;
            this.linkLabelSignUp.Text = "New here? Sign Up";
            this.linkLabelSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSignUp_LinkClicked);
            // 
            // errorProviderEmailID
            // 
            this.errorProviderEmailID.ContainerControl = this;
            // 
            // errorProviderPassword
            // 
            this.errorProviderPassword.ContainerControl = this;
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.Location = new System.Drawing.Point(140, 231);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(95, 20);
            this.checkBoxRememberMe.TabIndex = 8;
            this.checkBoxRememberMe.Text = "Remember Me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // LoginScreen
            // 
            this.AcceptButton = this.buttonSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 395);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.linkLabelSignUp);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelEmailID);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginScreen";
            this.Text = "Message A Niner ";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmailID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripConnectedLabel;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label labelEmailID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel linkLabelSignUp;
        private System.Windows.Forms.ErrorProvider errorProviderEmailID;
        private System.Windows.Forms.ErrorProvider errorProviderPassword;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
    }
}