using System;
using System.Collections.Generic;
using System.Text;

namespace JitBitAPIClient.Models
{
    public class TicketModel
    {
        public string Status { get; set; }
        public string OnBehalfUserName { get; set; }
        public string CategoryName { get; set; }
        public int TicketID { get; set; }
        public int UserID { get; set; }
        public int? AssignedToUserID { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Priority { get; set; }
        public int StatusID { get; set; }
        public int CategoryID { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public long TimeSpentInSeconds { get; set; }
        public bool UpdatedByUser { get; set; }
        public bool UpdatedByPerformer { get; set; }
        public bool UpdatedForTechView { get; set; }
        public bool IsCurrentUserTechInThisCategory { get; set; }
        public bool IsCurrentCategoryForTechsOnly { get; set; }
        public bool SubmittedByCurrentUser { get; set; }
        public bool IsInKb { get; set; }
        public string Stats { get; set; }
        public UserModel SubmitterUserInfo { get; set; }
        public UserModel AssigneeUserInfo { get; set; }
    }
}