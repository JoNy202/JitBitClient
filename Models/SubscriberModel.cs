namespace JitBitAPIClient.Models
{
    public class SubscriberModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool Disabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool SendEmail { get; set; }
        public bool IsTech { get; set; }
        public bool IsManager { get; set; }
        public bool TwoFactorAuthEnabled { get; set; }
        public bool OutOfOffice { get; set; }
        public string FullNameAndLogin { get; set; }
        public string FullName { get; set; }        
    }
}