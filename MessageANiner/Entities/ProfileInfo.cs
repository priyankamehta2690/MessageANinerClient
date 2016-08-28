namespace MessageANiner.Entities
{
    public class ProfileInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailID { get; set; }
        public string userID { get; set; }
        public bool verified { get; set; }
        public bool passwordVerified { get; set; }
        public string returnMessage { get; set; }
    }
}
