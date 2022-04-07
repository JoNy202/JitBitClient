using System;
using System.Collections.Generic;
using System.Text;

namespace JitBitAPIClient.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string IPAddress { get; set; }
        public string HostName { get; set; }
        public string Lang { get; set; }
        public string UserAgent { get; set; }
        public string AvatarURL { get; set; }
        public string Signature { get; set; }
        public string Greeting { get; set; }
        public int? CompanyId { get; set; }
        public int? DepartamentId { get; set; }
        public int? CompanyNotes { get; set; }
        public bool IsAdmin { get; set; }
        public bool Disabled { get; set; }
        public bool SendEmail { get; set; }
        public bool IsTech { get; set; }
        public DateTime? LastSeen { get; set; }
        public bool IsManager { get; set; }
        public string FullNameAndLogin { get; set; }
        public string FullName { get; set; }
    }
}