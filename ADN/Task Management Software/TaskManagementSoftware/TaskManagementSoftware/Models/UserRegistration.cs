using System;
using System.Collections.Generic;

namespace TaskManagementSoftware.Models
{
    public partial class UserRegistration
    {
        public UserRegistration()
        {
            ProjectLists = new HashSet<ProjectList>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ProjectList> ProjectLists { get; set; }
    }
}
