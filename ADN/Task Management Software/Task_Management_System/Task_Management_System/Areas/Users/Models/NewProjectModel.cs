using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Areas.Users.Models
{
    public class NewProjectModel
    {
        public int ProjectID { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "ProjectTitle_TOO_SHORT")]
        [MaxLength(50, ErrorMessage = "ProjectTitle_TOO_LONG")]
        public string ProjectTitle { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [Required]
        public string ProjectOwnerName { get; set; }
        public DateTime DeadLine { get; set;}

        [Required]
        [Range(2, 100, ErrorMessage = "Member must be between 2 and 100.")]
        public int TotalMembers { get; set;}

        [Required]
        [Range(5000, 8000000, ErrorMessage = "Project Cost must be between 5000 and 8000000.")]
        public double ProjectCost { get; set;}
        public int UserID { get; set;}
        public DateTime ModifiedDate { get; set; }

        [Required]
        public string ProjectState { get; set; }
    }
}
