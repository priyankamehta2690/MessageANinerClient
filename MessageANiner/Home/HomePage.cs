using MessageANiner.Entities;
using MessageANiner.Group;
using MessageANiner.Login;
using MessageANiner.Settings;
using MessageANiner.UserControls;
using messageSpecs;
using SocketHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MessageANiner.Home
{
    public delegate void DelTextMessageReceived(string message);

    public partial class HomePage : Form
    {
        public event DelTextMessageReceived txtmessageReceived;
        private Timer tmrMessages = new Timer() { Interval = 500 };
        private SocketClient myClient = new SocketClient("127.0.0.1", 20000, false, ((char)2).ToString(), ((char)3).ToString());
        private ProfileInfo _userDetails = null;

        public static long myUID;
        public ProfileInfo UserDetails
        {
            get { return _userDetails; }
            set { _userDetails = value; }
        }


        private LoginScreen startupScreen = null;
        private AddContacts addContactScreen = null;
        private ChangeUserSettings changeUserSettingsScreen = null;
        private CreateGroupForm createGroup = null;
        public SortedList<long, ChatWindow> openChatWindows = new SortedList<long, ChatWindow>();
        public List<messageSpecs.FriendStatusMessage> friendList = new List<FriendStatusMessage>();

        public long openedChatWindowUID;

        public HomePage()
        {
            InitializeComponent();
            tmrMessages.Tick += new EventHandler(messageHandler);
            tmrMessages.Start();
            ContactsList.Controls.Clear();
            ContactsList.RowCount = 1;
            ContactsList.RowStyles[0].SizeType = SizeType.Absolute;
            ContactsList.RowStyles[0].Height = 40;
            openLoginScreen();

        }

        private void openLoginScreen()
        {
            myClient.CloseSocket(true);
            myClient = new SocketClient("127.0.0.1", 20000, false, ((char)2).ToString(), ((char)3).ToString());
            startupScreen = new LoginScreen(myClient, this);
            startupScreen.Show();
            startupScreen.FormClosed += new FormClosedEventHandler(userLoggedIn);
        }

        public void userLoggedIn(object sender, EventArgs e)
        {
            if (UserDetails == null)
            {
                this.Close();
                return;
            }

            startupScreen = null;
            this.Visible = true;
            WindowState = FormWindowState.Normal;
            myUID = long.Parse(UserDetails.userID);
        }

        private void messageHandler(object sender, EventArgs e)
        {
            if (startupScreen != null)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }

            try
            {
                while (myClient.messageQueue.Count > 0)
                {
                    string message = myClient.messageQueue.Dequeue();

                    switch (message.Substring(0, 5))
                    {
                        case messageSpecs.LogonMessage.LoginMessageType:
                            startupScreen.handleLogin(message);
                            break;

                        case messageSpecs.UserCreationMessage.CreateUserMessageType:
                            startupScreen.profileDetailPage.handleReturnMessage(message);
                            break;

                        case messageSpecs.FriendStatusMessage.FriendStatusMessageType:
                            updateContacts(message);
                            break;

                        case messageSpecs.ContactLookupMessage.ContactLookupMessageType:
                            if (addContactScreen != null)
                                addContactScreen.receivedLookupMessage(message);
                            break;

                        case messageSpecs.AddContactMessage.AddContactMessageType:
                            if (addContactScreen != null)
                                addContactScreen.receivedContactMessage(message);
                            break;

                        case messageSpecs.ChangeUserSettingsMessage.ChangeUserSettingsMessageType:
                            if (startupScreen != null && startupScreen.passwordChangePage != null)
                                startupScreen.passwordChangePage.handleChangeMessage(message);
                            else if (changeUserSettingsScreen != null)
                                changeUserSettingsScreen.handleChangeMessage(message);
                            break;

                        case messageSpecs.TextMessage.TextMessageType:
                        case messageSpecs.UserTyping.UserTypingMessageType:
                        case messageSpecs.PictureMessage.PictureMessageType:
                        case messageSpecs.FileMessage.FileMessageType:
                            updateMessages(message);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
            }

        }

        public void updateMessages(string message)
        {
            string sender= string.Empty, receiver = string.Empty;

            messageSpecs.BaseMessage msg = new BaseMessage(message);
            
            sender = msg.sender;
            receiver = msg.receiver;
          

            if (sender == UserDetails.userID) //If it is a return message to us then quit
                return;

            string lookup = sender;

            if (receiver != UserDetails.userID)
            {
                lookup = receiver;
            }

            if (openChatWindows.ContainsKey(long.Parse(lookup)))       //If it is open already then add to
            {
                openChatWindows[long.Parse(lookup)].showReceivedMessage(message);
            }
            else                                                              //Otherwise a window for the conversation
            {
                ContactControl friendsContact = null;
                foreach (ContactControl control in ContactsList.Controls)
                {
                    if (control.UID == long.Parse(lookup))
                        friendsContact = control;
                }
                if (friendsContact == null)
                {
                    return;
                }
                createChatWindow(friendsContact.UID, friendsContact.name);
                openChatWindows[friendsContact.UID].showReceivedMessage(message);
            }

            if (openedChatWindowUID != long.Parse(lookup))                       //If it is not the open chat window then beep and show a message count
            {
                if (message.Substring(0, 5) == "FTYPE")
                    return;
                foreach (ContactControl currentContact in ContactsList.Controls.OfType<ContactControl>())
                {
                    if (currentContact.UID == long.Parse(lookup))
                    {
                        currentContact.UpdateMessageCount();
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
            }
        }

        public void updateContacts(string message)
        {
            messageSpecs.FriendStatusMessage friendMsg = new FriendStatusMessage(message);

            friendList.Add(friendMsg);

            ContactControl addingContact = null;

            foreach (ContactControl currentContact in ContactsList.Controls)
            {
                if (currentContact.UID == long.Parse(friendMsg.sender))
                {
                    addingContact = currentContact;
                    currentContact.UpdateStatus(friendMsg.UserStatus);
                    break;
                }
            }

            if (addingContact == null)
            {
                addingContact = new ContactControl(long.Parse(friendMsg.sender), friendMsg.FirstName.Trim() + " " + friendMsg.LastName.Trim(), friendMsg.UserStatus);
                addingContact.contactClicked += new DelContactClick(openchatwindow);

                ContactsList.RowCount += 1;
                ContactsList.Controls.Add(addingContact, 0, ContactsList.RowCount - 2);
                ContactsList.RowStyles[ContactsList.RowCount - 2].SizeType = SizeType.Absolute;
                ContactsList.RowStyles[ContactsList.RowCount - 2].Height = 40;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _userDetails = null;
            this.Close();
        }

        private void contactLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addContactScreen = new AddContacts(myClient, _userDetails);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(addContactScreen);
            addContactScreen.Dock = DockStyle.Fill;
        }

        private void openchatwindow(long friendsUID, string friendName, bool isFriendRequest)
        {
            if (isFriendRequest)
            {
                OpenRequestReplyWindow(friendsUID, friendName);
                return;
            }
            ChatWindow chat = null;
            if (openChatWindows.ContainsKey(friendsUID))
            {
                chat = openChatWindows[friendsUID];
            }
            else
            {
                chat = createChatWindow(friendsUID, friendName);
            }
            openedChatWindowUID = friendsUID;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(chat);
        }

        private void OpenRequestReplyWindow(long friendsUID, string friendName)
        {
            RequestReplyWindow RRwindow = new RequestReplyWindow(myClient, myUID, friendsUID, friendName);
            RRwindow.removeClicked += new DelRemoveContact(RRwindow_removeClicked); ;
            RRwindow.Dock = DockStyle.Fill;
            openedChatWindowUID = friendsUID;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(RRwindow);
        }

        void RRwindow_removeClicked(long UID, string name)
        {

            int row = -1;
            try
            {
                foreach (ContactControl currentContact in ContactsList.Controls)
                {
                    row++;
                    if (currentContact.UID == UID)
                    {
                        ContactsList.Controls.Remove(currentContact);
                        //ContactsList.RowStyles[row].Height = 0;
                        ContactsList.RowCount--;
                        return;
                    }
                }
            }
            catch (Exception)
            { }
        }

        private ChatWindow createChatWindow(long friendsUID, string friendName)
        {
            ChatWindow chat = new ChatWindow(myClient, myUID, friendsUID, friendName);
            chat.Dock = DockStyle.Fill;
            openChatWindows.Add(friendsUID, chat);
            return chat;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _userDetails = null;
            ContactsList.Controls.Clear();
            ContactsList.RowCount = 1;
            ContactsList.RowStyles[0].SizeType = SizeType.Absolute;
            ContactsList.RowStyles[0].Height = 40;
            openLoginScreen();
        }

        private void changeUserSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeUserSettingsScreen = new ChangeUserSettings(_userDetails, myClient);
            changeUserSettingsScreen.ShowDialog();
        }

        // Written for testing Dont Delete
        public void closeLoginScreen()
        {
            startupScreen.Close();
        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createGroup = new CreateGroupForm(friendList.GroupBy(item => item.sender).Select(item => item.First()).ToList(), myClient, myUID);
            createGroup.ShowDialog();
        }


    }
}
