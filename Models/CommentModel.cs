using System;
using System.Collections.Generic;
using System.Text;

namespace JitBitAPIClient.Models
{
    public class CommentModel
    {
        public int CommentID { get; set; }
        public int IssueID { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSystem { get; set; }
        public DateTime CommentDate { get; set; }
        public bool ForTechsOnly { get; set; }
        public string Body { get; set; }
        public string TicketSubject { get; set; }
        public string Recipients { get; set; }
    }
}