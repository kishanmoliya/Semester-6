using System;
using System.Collections.Generic;

namespace TaskManagementSoftware.Models
{
    public partial class ProjectList
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; } = null!;
        public string? ProjectDescription { get; set; }
        public string? ProjectOwnerName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public int UserId { get; set; }

        public virtual UserRegistration User { get; set; } = null!;
    }
}
