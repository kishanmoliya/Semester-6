using System.ComponentModel.DataAnnotations;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Users.Models
{
    public class AddTaskModel
    {
        public int TaskID { get; set; }

        [Required]
        public string TaskName { get; set; }
        public string TaskState { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }
        public int ProjectID { get; set; }
        public int? MemberID { get; set; }

        [Required]
        public string TaskDescription { get; set; }
    }
}
