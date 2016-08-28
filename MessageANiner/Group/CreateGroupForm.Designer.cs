namespace MessageANiner.Group
{
    partial class CreateGroupForm
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
            this.labelGroupName = new System.Windows.Forms.Label();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.labelFriendsList = new System.Windows.Forms.Label();
            this.listBoxFriendsList = new System.Windows.Forms.ListBox();
            this.labelGroupList = new System.Windows.Forms.Label();
            this.listBoxGroupList = new System.Windows.Forms.ListBox();
            this.buttonMoveAllRight = new System.Windows.Forms.Button();
            this.buttonMoveOneRight = new System.Windows.Forms.Button();
            this.buttonMoveOneLeft = new System.Windows.Forms.Button();
            this.buttonMoveAllLeft = new System.Windows.Forms.Button();
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.labelFriendListStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelGroupName
            // 
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Location = new System.Drawing.Point(97, 77);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(67, 13);
            this.labelGroupName.TabIndex = 0;
            this.labelGroupName.Text = "Group Name";
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Location = new System.Drawing.Point(287, 70);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(126, 20);
            this.textBoxGroupName.TabIndex = 1;
            // 
            // labelFriendsList
            // 
            this.labelFriendsList.AutoSize = true;
            this.labelFriendsList.Location = new System.Drawing.Point(102, 133);
            this.labelFriendsList.Name = "labelFriendsList";
            this.labelFriendsList.Size = new System.Drawing.Size(62, 13);
            this.labelFriendsList.TabIndex = 2;
            this.labelFriendsList.Text = "Friend\'s List";
            // 
            // listBoxFriendsList
            // 
            this.listBoxFriendsList.FormattingEnabled = true;
            this.listBoxFriendsList.Location = new System.Drawing.Point(40, 149);
            this.listBoxFriendsList.Name = "listBoxFriendsList";
            this.listBoxFriendsList.Size = new System.Drawing.Size(124, 147);
            this.listBoxFriendsList.TabIndex = 3;
            // 
            // labelGroupList
            // 
            this.labelGroupList.AutoSize = true;
            this.labelGroupList.Location = new System.Drawing.Point(284, 133);
            this.labelGroupList.Name = "labelGroupList";
            this.labelGroupList.Size = new System.Drawing.Size(55, 13);
            this.labelGroupList.TabIndex = 4;
            this.labelGroupList.Text = "Group List";
            // 
            // listBoxGroupList
            // 
            this.listBoxGroupList.FormattingEnabled = true;
            this.listBoxGroupList.Location = new System.Drawing.Point(287, 150);
            this.listBoxGroupList.Name = "listBoxGroupList";
            this.listBoxGroupList.Size = new System.Drawing.Size(126, 147);
            this.listBoxGroupList.TabIndex = 5;
            // 
            // buttonMoveAllRight
            // 
            this.buttonMoveAllRight.Location = new System.Drawing.Point(211, 150);
            this.buttonMoveAllRight.Name = "buttonMoveAllRight";
            this.buttonMoveAllRight.Size = new System.Drawing.Size(29, 23);
            this.buttonMoveAllRight.TabIndex = 6;
            this.buttonMoveAllRight.Text = ">>";
            this.buttonMoveAllRight.UseVisualStyleBackColor = true;
            this.buttonMoveAllRight.Click += new System.EventHandler(this.buttonMoveAllRight_Click);
            // 
            // buttonMoveOneRight
            // 
            this.buttonMoveOneRight.Location = new System.Drawing.Point(211, 191);
            this.buttonMoveOneRight.Name = "buttonMoveOneRight";
            this.buttonMoveOneRight.Size = new System.Drawing.Size(29, 23);
            this.buttonMoveOneRight.TabIndex = 7;
            this.buttonMoveOneRight.Text = ">";
            this.buttonMoveOneRight.UseVisualStyleBackColor = true;
            this.buttonMoveOneRight.Click += new System.EventHandler(this.buttonMoveOneRight_Click);
            // 
            // buttonMoveOneLeft
            // 
            this.buttonMoveOneLeft.Location = new System.Drawing.Point(211, 232);
            this.buttonMoveOneLeft.Name = "buttonMoveOneLeft";
            this.buttonMoveOneLeft.Size = new System.Drawing.Size(29, 23);
            this.buttonMoveOneLeft.TabIndex = 8;
            this.buttonMoveOneLeft.Text = "<";
            this.buttonMoveOneLeft.UseVisualStyleBackColor = true;
            this.buttonMoveOneLeft.Click += new System.EventHandler(this.buttonMoveOneLeft_Click);
            // 
            // buttonMoveAllLeft
            // 
            this.buttonMoveAllLeft.Location = new System.Drawing.Point(211, 272);
            this.buttonMoveAllLeft.Name = "buttonMoveAllLeft";
            this.buttonMoveAllLeft.Size = new System.Drawing.Size(29, 23);
            this.buttonMoveAllLeft.TabIndex = 9;
            this.buttonMoveAllLeft.Text = "<<";
            this.buttonMoveAllLeft.UseVisualStyleBackColor = true;
            this.buttonMoveAllLeft.Click += new System.EventHandler(this.buttonMoveAllLeft_Click);
            // 
            // buttonCreateGroup
            // 
            this.buttonCreateGroup.Location = new System.Drawing.Point(338, 338);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateGroup.TabIndex = 10;
            this.buttonCreateGroup.Text = "Create Group";
            this.buttonCreateGroup.UseVisualStyleBackColor = true;
            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);
            // 
            // labelFriendListStatus
            // 
            this.labelFriendListStatus.AutoSize = true;
            this.labelFriendListStatus.ForeColor = System.Drawing.Color.Red;
            this.labelFriendListStatus.Location = new System.Drawing.Point(102, 109);
            this.labelFriendListStatus.Name = "labelFriendListStatus";
            this.labelFriendListStatus.Size = new System.Drawing.Size(0, 13);
            this.labelFriendListStatus.TabIndex = 11;
            // 
            // CreateGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 397);
            this.Controls.Add(this.labelFriendListStatus);
            this.Controls.Add(this.buttonCreateGroup);
            this.Controls.Add(this.buttonMoveAllLeft);
            this.Controls.Add(this.buttonMoveOneLeft);
            this.Controls.Add(this.buttonMoveOneRight);
            this.Controls.Add(this.buttonMoveAllRight);
            this.Controls.Add(this.listBoxGroupList);
            this.Controls.Add(this.labelGroupList);
            this.Controls.Add(this.listBoxFriendsList);
            this.Controls.Add(this.labelFriendsList);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.labelGroupName);
            this.Name = "CreateGroupForm";
            this.Text = "Group Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label labelFriendsList;
        private System.Windows.Forms.ListBox listBoxFriendsList;
        private System.Windows.Forms.Label labelGroupList;
        private System.Windows.Forms.ListBox listBoxGroupList;
        private System.Windows.Forms.Button buttonMoveAllRight;
        private System.Windows.Forms.Button buttonMoveOneRight;
        private System.Windows.Forms.Button buttonMoveOneLeft;
        private System.Windows.Forms.Button buttonMoveAllLeft;
        private System.Windows.Forms.Button buttonCreateGroup;

        private System.Windows.Forms.Label labelFriendListStatus;
    }
}