using MessageANiner.Entities;
using MessageANiner.Home;
using messageSpecs;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MessageANinerTestProject
{
    [TestClass]
    public class ScreensUnitTestClass
    {
        ProfileInfo userDetails = new ProfileInfo();

        [TestInitialize]
        public void Setup()
        {
            userDetails.userID = "1";
            userDetails.userName = "Vaibhav";
            userDetails.verified = true;
            userDetails.lastName = "Sapkal";
        }

        [TestMethod]
        public void TestUpdateContacts_NewUserAdded()
        {
            HomePage screen = new HomePage();
            screen.UserDetails = userDetails;
            messageSpecs.FriendStatusMessage x = new FriendStatusMessage();
            x.sender = "1";
            x.UserStatus = FriendStatusMessage.LoggedOnStatus.Online;
            screen.updateContacts(x.getMessageString());
            messageSpecs.FriendStatusMessage y = new FriendStatusMessage();
            y.sender = "2";
            y.UserStatus = FriendStatusMessage.LoggedOnStatus.Online;
            screen.updateContacts(y.getMessageString());

            int check1 = screen.ContactsList.RowCount;
            Assert.AreEqual(3, check1);
            this.releaseResources(screen);

        }

        [TestMethod]
        public void TestUpdateContacts_UserStatusChange()
        {
            HomePage screen = new HomePage();
            screen.UserDetails = userDetails;
            messageSpecs.FriendStatusMessage y = new FriendStatusMessage();
            y.sender = "2";
            y.UserStatus = FriendStatusMessage.LoggedOnStatus.Offline;
            screen.updateContacts(y.getMessageString());

            object c = screen.ContactsList.Controls[0];
            object status = ((MessageANiner.UserControls.ContactControl)(c)).avilability;
            Assert.AreEqual(MessageANiner.UserControls.ContactControl.Status.Offline, status);
            		
            y.UserStatus = FriendStatusMessage.LoggedOnStatus.Online;
            screen.updateContacts(y.getMessageString());

            status = ((MessageANiner.UserControls.ContactControl)(c)).avilability;
            Assert.AreEqual(MessageANiner.UserControls.ContactControl.Status.Online, status);

            this.releaseResources(screen);
        }

        [TestMethod]
        public void TestUpdateMessage()
        {
            HomePage screen = new HomePage();
            screen.UserDetails = userDetails;
            messageSpecs.FriendStatusMessage y = new FriendStatusMessage();
            y.sender = "0000000002";
            y.UserStatus = FriendStatusMessage.LoggedOnStatus.Online;
            screen.updateContacts(y.getMessageString());

            messageSpecs.TextMessage tm = new TextMessage();
            tm.sender = "0000000001";
            tm.receiver = "0000000002";
            tm.TextToSend = "ABCD";
            screen.updateMessages(tm.getMessageString());

            object isChatpresent = screen.openChatWindows.ContainsKey(long.Parse(tm.receiver));
            Assert.AreEqual(true, isChatpresent);

            object chatWindow = screen.openChatWindows[long.Parse(tm.receiver)];
            string messageString = ((MessageANiner.UserControls.MessageHolder)(((((MessageANiner.UserControls.ChatWindow)(chatWindow)).chatMessageArea.Controls[0])))).richTextBoxContent.Text;
            Assert.AreEqual("0000000001 : ABCD", messageString);
            this.releaseResources(screen);
        }

        [TestMethod]
        public void TestUpdateMessageCount()
        {
            HomePage screen = new HomePage();
            screen.UserDetails = userDetails;
            messageSpecs.FriendStatusMessage y = new FriendStatusMessage();
            y.sender = "0000000002";
            y.UserStatus = FriendStatusMessage.LoggedOnStatus.Offline;
            screen.updateContacts(y.getMessageString());

            messageSpecs.TextMessage tm = new TextMessage();
            tm.sender = "0000000001";
            tm.receiver = "0000000002";
            tm.TextToSend = "ABCD";
            screen.openedChatWindowUID = 0000224;

            screen.openedChatWindowUID = 0000224;
            screen.updateMessages(tm.getMessageString());

            object c = screen.ContactsList.Controls[0];
            int msgCount = ((MessageANiner.UserControls.ContactControl)(c)).msgCount;
            Assert.AreEqual(1, msgCount);


            screen.openedChatWindowUID = 0000224;
            tm.TextToSend = "PQRS";
            screen.updateMessages(tm.getMessageString());

            c = screen.ContactsList.Controls[0];
            msgCount = ((MessageANiner.UserControls.ContactControl)(c)).msgCount;
            Assert.AreEqual(2, msgCount);
            this.releaseResources(screen);
        }

        public void releaseResources(HomePage screen)
        {
            screen.closeLoginScreen();
            screen.Close();
            screen.Dispose();
        }
    }
}
