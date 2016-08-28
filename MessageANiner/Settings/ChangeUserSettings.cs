using MessageANiner.Entities;
using SocketHandler;
using System;
using System.Windows.Forms;

namespace MessageANiner.Settings
{
    public partial class ChangeUserSettings : Form
    {
        private SocketClient myClient = null;
        private ProfileInfo userDetails = null;

        public ChangeUserSettings()
        {
            InitializeComponent();
        }
        public ChangeUserSettings(ProfileInfo details, SocketClient client)
        {
            InitializeComponent();
            myClient = client;
            userDetails = details;
        }

        private void ChangeUserSettings_Load(object sender, EventArgs e)
        {
            textBoxFirstName.Text = userDetails.firstName;
            textBoxLastName.Text = userDetails.lastName;
            textBoxEmailId.Text = userDetails.emailID;
            textBoxPassword.Text = userDetails.password;
        }
        public void handleChangeMessage(string message)
        {
            messageSpecs.ChangeUserSettingsMessage returnMessage = new messageSpecs.ChangeUserSettingsMessage(message);
            if (returnMessage.Verified)
            {
                MessageBox.Show("Your settings has been changed successfully");

                this.Close();
            }
            else
            {
                MessageBox.Show("There was a problem in updating your settings. Please try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string emailId = textBoxEmailId.Text;
            string password = textBoxPassword.Text;

            if (!String.IsNullOrEmpty(firstName) &&
                !String.IsNullOrEmpty(lastName) &&
                (String.IsNullOrEmpty(Validations.isEmailIDValid(emailId)) &&
                 (String.IsNullOrEmpty(Validations.isPasswordValid(password)))))
            {
                messageSpecs.ChangeUserSettingsMessage messageChangePassword = new messageSpecs.ChangeUserSettingsMessage();
                messageChangePassword.PassWord = password;
                messageChangePassword.UserID = userDetails.userID;
                messageChangePassword.FirstName = firstName;
                messageChangePassword.LastName = lastName;
                messageChangePassword.EmailAddress = emailId;
                myClient.Send(messageChangePassword.getMessageString());
            }
        }
    }
}
