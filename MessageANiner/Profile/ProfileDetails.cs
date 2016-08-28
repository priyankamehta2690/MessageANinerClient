using SocketHandler;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MessageANiner.Profile
{
    public partial class ProfileDetails : Form
    {
        private SocketClient myClient = null;

        public ProfileDetails()
        {
            InitializeComponent();
        }

        public ProfileDetails(SocketClient client)
        {
            InitializeComponent();
            myClient = client;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            messageSpecs.UserCreationMessage userCreationMessage = new messageSpecs.UserCreationMessage();
            userCreationMessage.EmailAddress = textBoxEmailID.Text;
            userCreationMessage.FirstName = textBoxFirstName.Text;
            userCreationMessage.LastName = textBoxLastName.Text;
            userCreationMessage.UserName = textBoxUserName.Text;

            if (myClient != null)
                myClient.Send(userCreationMessage.getMessageString());

        }

        public void handleReturnMessage(string message)
        {
            messageSpecs.UserCreationMessage returnMessage = new messageSpecs.UserCreationMessage(message);
            MessageBox.Show(returnMessage.ReturnMessage);
        }

        private bool EmailIDValid(string emailAddress, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty.
            bool returnValue = false;
            if (emailAddress.Length == 0)
            {
                errorMessage = "e-mail address is required.";
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            else
            {
                string pattern = null;
                pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

                if (Regex.IsMatch(emailAddress, pattern))
                {
                    errorMessage = "";
                    returnValue = true;
                }
                else
                {
                    errorMessage = "e-mail address must be valid e-mail address format.\n" +
               "For example 'someone@uncc.edu' ";
                }
            }
            return returnValue;
        }
    }
}
