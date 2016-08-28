using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public delegate void DelContactClick(long UID, string name, bool isContactRequest);

    public partial class ContactControl : UserControl
    {
        public long UID { get; set; }
        public event DelContactClick contactClicked;
        public string name;
        public Status avilability;
        public enum Status
        {
            Offline = 0,
            Online = 1,
            Friend = 2,
            Group = 3
        }
        public int msgCount = 0;
        public messageSpecs.FriendStatusMessage.LoggedOnStatus userStatus = messageSpecs.FriendStatusMessage.LoggedOnStatus.Online;

        public ContactControl(long UID, string name, messageSpecs.FriendStatusMessage.LoggedOnStatus userStatus)
        {
            InitializeComponent();
            this.UID = UID;
            label.Text = name;
            this.name = name;
            UpdateStatus(userStatus);
        }

        public void UpdateStatus(messageSpecs.FriendStatusMessage.LoggedOnStatus status)
        {
            userStatus = status;
            switch (status)
            {
                case messageSpecs.FriendStatusMessage.LoggedOnStatus.Online:
                    pictureBox.Image = Properties.Resources.greendot;
                    avilability = Status.Online;
                    break;

                case messageSpecs.FriendStatusMessage.LoggedOnStatus.Offline:
                    pictureBox.Image = Properties.Resources.redDot;
                    avilability = Status.Offline;
                    break;

                case messageSpecs.FriendStatusMessage.LoggedOnStatus.Friend:
                    pictureBox.Image = Properties.Resources.caution;
                    avilability = Status.Friend;
                    break;

                case messageSpecs.FriendStatusMessage.LoggedOnStatus.Group:
                    pictureBox.Image = Properties.Resources.group;
                    avilability = Status.Group;
                    break;
            }
        }

        public void UpdateMessageCount()
        {
            msgCount = msgCount + 1;
            MessageCount.Text = msgCount.ToString();
        }

        private void label_Click(object sender, EventArgs e)
        {
            MessageCount.Text = "";
            msgCount = 0;
            if (userStatus == messageSpecs.FriendStatusMessage.LoggedOnStatus.Friend)
            {
                contactClicked(UID, name, true);
            }
            else
            {
                contactClicked(UID, name, false);
            }
        }

    }
}
