using MessageANiner.Entities;
using MessageANiner.Home;
using MessageANiner.Profile;
using MessageANiner.Settings;
using messageSpecs;
using SocketHandler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MessageANiner.Login
{
    public partial class LoginScreen : Form
    {
        private SocketClient myClient = null;
        public ProfileDetails profileDetailPage = null;
        public ChangePassword passwordChangePage = null;
        public ProfileInfo userInfo = null;
        private HomePage mainScreen = null;

        private Timer tmrMessages = new Timer()
        {
            Interval = 500
        };

        public LoginScreen()
        {
            InitializeComponent();
        }

        public LoginScreen(SocketClient client, HomePage mainScreen)
        {
            InitializeComponent();
            myClient = client;
            this.mainScreen = mainScreen;
            tmrMessages.Tick += new EventHandler(clientStatusCheck);
            tmrMessages.Start();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                textBoxUserName.Text = Properties.Settings.Default.UserName;
                textBoxPassword.Text = Properties.Settings.Default.Password;
            }
        }

        public void clientStatusCheck(object sender, EventArgs e)
        {
            if (myClient != null)
            {
                if (myClient.Connected)
                {
                    toolStripConnectedLabel.Text = "Server Connected";
                    toolStripConnectedLabel.BackColor = Color.Green;
                }
                else
                {
                    toolStripConnectedLabel.Text = "Server Disconnected";
                    toolStripConnectedLabel.BackColor = Color.Red;
                }
            }
        }

        public void handleLogin(string message)
        {
            messageSpecs.LogonMessage returnMessage = new LogonMessage(message);

            if (returnMessage.Verified)
            {

                userInfo = ProfileMapper(returnMessage);
                if (mainScreen != null)
                    mainScreen.UserDetails = userInfo;

                if (returnMessage.PasswordReset)
                {
                    ChangePassword changePassword = new ChangePassword(userInfo, myClient);
                    passwordChangePage = changePassword;
                    changePassword.ShowDialog(mainScreen);
                    changePassword = null;
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(returnMessage.ReturnMessage);
            }
        }

        private bool UserNameIsValid(string userName, out string errorMessage)
        {
            bool returnValue = false;
            if (userName.Length == 0)
            {
                errorMessage = "User Name is required.";
            }
            else
            {
                errorMessage = String.Empty;
                returnValue = true;
            }
            return returnValue;
        }

        private bool PasswordIsValid(string password, out string errorMessage)
        {
            bool returnValue = false;
            if (password.Length == 0)
            {
                errorMessage = "Password is required.";
            }
            else
            {
                errorMessage = String.Empty;
                returnValue = true;
            }
            return returnValue;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            messageSpecs.LogonMessage logonMessage = new messageSpecs.LogonMessage();
            string errorMessage1, errorMessage2 = null;
            if (UserNameIsValid(textBoxUserName.Text.Trim(), out errorMessage1) && PasswordIsValid(textBoxPassword.Text.Trim(), out errorMessage2))
            {
                logonMessage.UserName = textBoxUserName.Text.Trim();
                logonMessage.PassWord = textBoxPassword.Text.Trim();
                if (checkBoxRememberMe.Checked)
                {
                    Properties.Settings.Default.UserName = textBoxUserName.Text.Trim();
                    Properties.Settings.Default.Password = textBoxPassword.Text.Trim();
                    Properties.Settings.Default.Save();
                }
                myClient.Send(logonMessage.getMessageString());
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
                errorProviderPassword.SetError(this.textBoxPassword, errorMessage2);
            else
                errorProviderEmailID.SetError(this.textBoxUserName, errorMessage1);
        }

        private void linkLabelSignUp_LinkClicked(object sender, EventArgs e)
        {
            profileDetailPage = new ProfileDetails(myClient);
            profileDetailPage.ShowDialog();
            profileDetailPage = null;
        }

        private ProfileInfo ProfileMapper(messageSpecs.LogonMessage mapProfile)
        {
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.emailID = mapProfile.EmailAddress.Trim();
            profileInfo.firstName = mapProfile.FirstName.Trim();
            profileInfo.lastName = mapProfile.LastName.Trim();
            profileInfo.password = mapProfile.PassWord.Trim();
            profileInfo.userName = mapProfile.UserName.Trim();
            profileInfo.userID = mapProfile.UserID.Trim();
            profileInfo.verified = mapProfile.Verified;
            profileInfo.returnMessage = mapProfile.ReturnMessage.Trim();
            profileInfo.passwordVerified = mapProfile.PasswordReset;

            return profileInfo;
        }

    }
}
