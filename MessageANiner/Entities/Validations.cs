using System.Text.RegularExpressions;

namespace MessageANiner.Entities
{
    public static class Validations
    {
        public static string isEmailIDValid(string emailAddress)
        {
            // Confirm that the e-mail address string is not empty.
            string errorMessage = null;
            if (emailAddress.Length == 0)
            {
                errorMessage = "e-mail address is required.";
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order and the domain is uncc.edu
            else
            {
                string pattern = null;
                pattern = @"(\W|^)[\w.+\-]*@uncc\.edu(\W|$)";

                if (Regex.IsMatch(emailAddress, pattern))
                {
                    errorMessage = null;
                }
                else
                {
                    errorMessage = "e-mail address must be valid e-mail address format.\n" +
                                    "For example 'someone@uncc.edu' ";
                }
            }
            return errorMessage;
        }

        public static string isPasswordValid(string password)
        {
            string errorMessage = null;
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "New Password required!";
            }
            else if (!Regex.IsMatch(password, @"[A-Za-z][A-Za-z0-9]{2,7}"))
            {
                errorMessage = "Password invalid!";
            }
            else
            {
                errorMessage = null;
            }
            return errorMessage;
        }

        public static string isUserNameValid(string userName)
        {
            string errorMessage = null;
            if (string.IsNullOrEmpty(userName))
            {
                errorMessage = "User name is Mandatory";
            }
            else
            {
                errorMessage = null;
            }
            return errorMessage;
        }

        public static string isGroupNameValid(string groupName)
        {
            string errorMessage = null;
            if (string.IsNullOrEmpty(groupName))
            {
                errorMessage = "Group name is Mandatory";
            }
            return errorMessage;
        }
    }
}
