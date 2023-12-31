﻿namespace Task_Management_System.Areas.Users.Models
{
    public class NewProjectModel
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectOwnerName { get; set; }
        public DateTime DeadLine { get; set;}
        public int TotalMembers { get; set;}
        public double ProjectCost { get; set;}
        public int UserID { get; set;}
        public DateTime ModifiedDate { get; set; }
    }
}
