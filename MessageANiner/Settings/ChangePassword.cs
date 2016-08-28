using MessageANiner.Entities;
using SocketHandler;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MessageANiner.Settings
{
    public partial class ChangePassword : Form
    {
        private SocketClient myClient = null;
        private string currentPassword;
        private ProfileInfo userDetails = null;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(ProfileInfo details, SocketClient client)
        {
            InitializeComponent();
            this.currentPassword = details.password;
            myClient = client;
            userDetails = details;
        }

        public void handleChangeMessage(string message)
        {
            messageSpecs.ChangeUserSettingsMessage returnMessage = new messageSpecs.ChangeUserSettingsMessage(message);
            if (returnMessage.Verified)
            {
                MessageBox.Show("Password has been changed successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("There was a problem in changing the password. Please try again.");
            }
        }

        private bool passwordValidating()
        {
            bool isValid = false;

            if (string.IsNullOrEmpty(textBoxCurrentPassword.Text))
            {
                errorProvider1.SetError(textBoxCurrentPassword, "Current Password required!");
            }
            else if (textBoxCurrentPassword.Text != currentPassword.Trim())
            {
                errorProvider1.SetError(textBoxCurrentPassword, "Incorrect Current Password!");
            }
            else
            {
                errorProvider1.SetError(textBoxNewPassword, null);
                isValid = true;
            }
            return isValid;
        }
        private bool newPasswordValidating()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(textBoxNewPassword.Text))
            {
                errorProvider2.SetError(textBoxNewPassword, "New Password required!");
            }
            else if (!Regex.IsMatch(textBoxNewPassword.Text, @"[A-Za-z][A-Za-z0-9]{2,7}"))
            {
                errorProvider2.SetError(textBoxNewPassword, "Password invalid!");
            }
            else
            {
                errorProvider2.SetError(textBoxNewPassword, null);
                isValid = true;
            }
            return isValid;
        }

        private bool confirmNewPaswordValidating()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(textBoxNewPassword.Text))
            {
                errorProvider3.SetError(textBoxNewPassword, "Confirm New Password required!");
            }
            else if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                errorProvider3.SetError(textBoxNewPassword, "New Password and Confirm New Password do not match!");
            }
            else
            {
                errorProvider3.SetError(textBoxNewPassword, null);
                isValid = true;
            }
            return isValid;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (passwordValidating() && newPasswordValidating() && confirmNewPaswordValidating())
            {
                messageSpecs.ChangeUserSettingsMessage messageChangePassword = new messageSpecs.ChangeUserSettingsMessage();
                messageChangePassword.PassWord = textBoxNewPassword.Text;
                messageChangePassword.UserID = userDetails.userID;
                messageChangePassword.FirstName = userDetails.firstName;
                messageChangePassword.LastName = userDetails.lastName;
                messageChangePassword.EmailAddress = userDetails.emailID;
                myClient.Send(messageChangePassword.getMessageString());
            }
        }
    }
}
