using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Areas.Users.Models
{
    public class NewProjectModel
    {
        public int ProjectID { get; set; }

        [Required]
        public string ProjectTitle { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [Required]
        public string ProjectOwnerName { get; set; }
        public DateTime DeadLine { get; set;}

        [Required]
        public int TotalMembers { get; set;}

        [Required]
        public double ProjectCost { get; set;}
        public int UserID { get; set;}
        public DateTime ModifiedDate { get; set; }

        [Required]
        public string ProjectState { get; set; }
    }
}
