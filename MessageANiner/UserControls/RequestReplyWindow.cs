using SocketHandler;
using System;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public delegate void DelRemoveContact(long UID, string name);

    public partial class RequestReplyWindow : UserControl
    {
        private SocketClient myClient = null;
        public event DelRemoveContact removeClicked;
        long myUID;
        public long friendUID;
        string friendName;

        public RequestReplyWindow()
        {
            InitializeComponent();
        }

        public RequestReplyWindow(SocketClient client, long myUID, long friendsUID, string friendName)
        {
            InitializeComponent();
            this.myUID = myUID;
            friendUID = friendsUID;
            this.friendName = friendName;
            myClient = client;
            label.Text = friendName + " wants to be your friend. You can accept or decline the request by pressing the buttons below";
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            // send the messageSpecs back To server
            messageSpecs.ContactResponseMessage reply = new messageSpecs.ContactResponseMessage();
            reply.Reply = messageSpecs.ContactResponseMessage.ContactResponse.Accept;
            reply.sender = myUID.ToString();
            reply.receiver = friendUID.ToString();
            myClient.Send(reply.getMessageString());
            this.Dispose();
        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {
            // Send the Message to Server.

            messageSpecs.ContactResponseMessage reply = new messageSpecs.ContactResponseMessage();
            reply.sender = myUID.ToString();
            reply.receiver = friendUID.ToString();
            reply.Reply = messageSpecs.ContactResponseMessage.ContactResponse.Decline;
            myClient.Send(reply.getMessageString());

            removeClicked(friendUID, friendName);
            this.Dispose();
        }

    }
}
