using MessageANiner.Entities;
using SocketHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MessageANiner.Group
{
    public partial class CreateGroupForm : Form
    {
        private SocketClient _myClient;
        private List<messageSpecs.FriendStatusMessage> friendsList = null;
        Dictionary<long, string> group = null;
        Dictionary<long, string> all = null;
        Dictionary<long, string> friends = null;
        System.Collections.Generic.KeyValuePair<long, string> keyValuePair;
        private long UserID;

        public CreateGroupForm()
        {
            InitializeComponent();
        }

        public CreateGroupForm(List<messageSpecs.FriendStatusMessage> _friendsList, SocketClient myClient, long UserID)
        {
            InitializeComponent();

            var Online = messageSpecs.FriendStatusMessage.LoggedOnStatus.Online;
            var Offline = messageSpecs.FriendStatusMessage.LoggedOnStatus.Offline;

            this.friendsList = _friendsList.Where(item => (item.UserStatus == Online) || (item.UserStatus == Offline)).ToList();
            this._myClient = myClient;
            this.UserID = UserID;
            ListBoxLoad();
        }

        private void buttonMoveAllRight_Click(object sender, EventArgs e)
        {
            #region 'Hashed'
            //if (listBoxFriendsList.Items.Count > 0)
            //{
            //    listBoxGroupList.DisplayMember = "Value";
            //    listBoxGroupList.ValueMember = "Key";

            //    foreach (var item in listBoxFriendsList.Items)
            //    {
            //        listBoxGroupList.Items.Add(item);
            //    }

            //    listBoxFriendsList.DataSource = null;
            //    listBoxFriendsList.Items.Clear();
            //}
            #endregion
            MoveAllItems(listBoxFriendsList, listBoxGroupList);
        }

        private void buttonMoveOneRight_Click(object sender, EventArgs e)
        {
            MoveSelectedItemsRight(listBoxFriendsList, listBoxGroupList);
        }

        private void buttonMoveOneLeft_Click(object sender, EventArgs e)
        {
            #region 'Hashed'
            //if (listBoxGroupList.Items.Count > 0)
            //{
            //    listBoxFriendsList.DisplayMember = "Value";
            //    listBoxFriendsList.ValueMember = "Key";

            //    foreach (var item in listBoxGroupList.SelectedItems)
            //    {
            //        listBoxFriendsList.Items.Add(item);
            //        listBoxGroupList.Items.Remove(item);
            //    }

            //    foreach (var item in listBoxFriendsList.Items)
            //    {
            //        listBoxGroupList.Items.Remove(item);
            //    }

            //    if (listBoxGroupList.Items.Count > 0)
            //    {
            //        listBoxGroupList.SelectedIndex = 0;
            //    }
            //    listBoxFriendsList.SelectedIndex = listBoxFriendsList.Items.Count - 1;

            //}
            #endregion
            MoveSelectedItemsLeft(listBoxGroupList, listBoxFriendsList);
        }

        private void buttonMoveAllLeft_Click(object sender, EventArgs e)
        {
            MoveAllItems(listBoxGroupList, listBoxFriendsList);
        }

        private void MoveAllItems(ListBox listBox1, ListBox listBox2)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox2.DisplayMember = "Value";
                listBox2.ValueMember = "Key";

                foreach (var item in listBox1.Items)
                {
                    listBox2.Items.Add(item);
                }

                listBox1.DataSource = null;
                listBox1.Items.Clear();

                if (listBox1.Items.Count > 0)
                {
                    listBox2.SelectedIndex = 0;
                }
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
        }

        private void MoveSelectedItemsRight(ListBox listBox1, ListBox listBox2)
        {
            if (listBox1.Items.Count > 0 && friends.Count > 0)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    keyValuePair = (KeyValuePair<long, string>)item;
                    friends.Remove(keyValuePair.Key);
                    group.Add(keyValuePair.Key, keyValuePair.Value);
                }

                listBox1.DataSource = null;
                listBox2.DataSource = null;

                listBox2.DisplayMember = "Value";
                listBox2.ValueMember = "Key";

                listBox1.DisplayMember = "Value";
                listBox1.ValueMember = "Key";

                if (friends.Count > 0)
                    listBox1.DataSource = new BindingSource(friends, null);
                else
                    listBox1.DataSource = null;
                listBox2.DataSource = new BindingSource(group, null);

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }

                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
        }

        private void MoveSelectedItemsLeft(ListBox listBox1, ListBox listBox2)
        {
            if (listBox1.Items.Count > 0 && group.Count > 0)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    keyValuePair = (KeyValuePair<long, string>)item;
                    friends.Add(keyValuePair.Key, keyValuePair.Value);
                    group.Remove(keyValuePair.Key);
                }

                listBox1.DataSource = null;
                listBox2.DataSource = null;

                listBox2.DisplayMember = "Value";
                listBox2.ValueMember = "Key";

                listBox1.DisplayMember = "Value";
                listBox1.ValueMember = "Key";

                listBox2.DataSource = new BindingSource(friends, null);
                if (group.Count > 0)
                    listBox1.DataSource = new BindingSource(group, null);
                else
                    listBox1.DataSource = null;

                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }

                listBox2.SelectedIndex = listBox2.Items.Count - 1;
            }
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            labelFriendListStatus.Text = string.Empty;

            if (string.IsNullOrEmpty(Validations.isGroupNameValid(textBoxGroupName.Text)) && listBoxGroupList.Items.Count > 0)
            {
                messageSpecs.CreateGroupMessage createGroupMessage = new messageSpecs.CreateGroupMessage();

                createGroupMessage.GroupName = textBoxGroupName.Text;

                foreach (var item in listBoxGroupList.Items)
                {
                    keyValuePair = (KeyValuePair<long, string>)item;
                    createGroupMessage.memberList.Add(keyValuePair.Key);
                }

                createGroupMessage.memberList.Add(UserID);

                _myClient.Send(createGroupMessage.getMessageString());
                this.Close();

            }
            else
            {
                labelFriendListStatus.Text = string.IsNullOrEmpty(Validations.isGroupNameValid(textBoxGroupName.Text))
                    ? "Select friends to be added to the group" : listBoxGroupList.Items.Count > 0 ? "Enter Group Name" :
                    "Enter Group Name and select friends to be added to the group";

                labelFriendListStatus.Visible = true;
            }
        }

        private void ListBoxLoad()
        {
            if (friendsList.Count > 0)
            {

                friends = new Dictionary<long, string>();
                all = new Dictionary<long, string>();
                group = new Dictionary<long, string>();

                foreach (var frnd in friendsList)
                {
                    friends.Add(long.Parse(frnd.sender), frnd.FirstName.Trim() + " " + frnd.LastName.Trim());
                    all.Add(long.Parse(frnd.sender), frnd.FirstName.Trim() + " " + frnd.LastName.Trim());
                }

                listBoxFriendsList.DisplayMember = "Value";
                listBoxFriendsList.ValueMember = "Key";

                listBoxFriendsList.DataSource = new BindingSource(all, null);

            }
            else
            {
                labelFriendListStatus.Text = "Add friends to create a group";
                labelFriendListStatus.Visible = true;
                buttonCreateGroup.Enabled = false;
            }
        }
    }
}
