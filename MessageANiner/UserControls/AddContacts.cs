using MessageANiner.Entities;
using SocketHandler;
using System;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public partial class AddContacts : UserControl
    {
        private SocketClient myClient = null;
        ProfileInfo userInfo = null;

        public AddContacts()
        {
            InitializeComponent();
        }

        public AddContacts(SocketClient client, ProfileInfo profileInfo)
        {
            myClient = client;
            userInfo = profileInfo;
            InitializeComponent();
        }

        public void receivedLookupMessage(String message)
        {
            messageSpecs.ContactLookupMessage lookUp = new messageSpecs.ContactLookupMessage(message);
            dataGridViewContactList.AllowUserToAddRows = false;
            dataGridViewContactList.Columns.Clear();
            dataGridViewContactList.DataSource = lookUp.ReturnTable;
            if (dataGridViewContactList.Columns.Contains("UID"))
                dataGridViewContactList.Columns["UID"].Visible = false;

            dataGridViewContactList.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Add Contact",
                HeaderText = "Add Contact",
                UseColumnTextForButtonValue = true
            });
            dataGridViewContactList.CellClick +=
             new DataGridViewCellEventHandler(dataGridViewContactList_CellClick);
        }

        public void receivedContactMessage(String message)
        {
            messageSpecs.AddContactMessage returnMessage = new messageSpecs.AddContactMessage(message);
            lblReturnMsg.Text = returnMessage.ReturnMessage;
        }

        private void buttonLookUp_Click(object sender, EventArgs e)
        {
            messageSpecs.ContactLookupMessage lookUp = new messageSpecs.ContactLookupMessage();
            lookUp.LookupName = textBox1.Text;

            if (myClient != null)
            {
                myClient.Send(lookUp.getMessageString());
            }
        }

        private void dataGridViewContactList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.ColumnIndex != 5)
                return;

            int selectedrowindex = dataGridViewContactList.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridViewContactList.Rows[selectedrowindex];
            string contactUserId = Convert.ToString(selectedRow.Cells["UID"].Value);
            messageSpecs.AddContactMessage addContact = new messageSpecs.AddContactMessage();
            addContact.sender = userInfo.userID;
            addContact.receiver = contactUserId;

            if (myClient != null)
            {
                myClient.Send(addContact.getMessageString());
            }
        }
    }

}
