using System.ComponentModel.DataAnnotations;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Users.Models
{
    public class AddTaskModel
    {
        public int TaskID { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "TASKNAME_TOO_SHORT")]
        [MaxLength(50, ErrorMessage = "TASKNAME_TOO_LONG")]
        public string TaskName { get; set; }

        public string TaskState { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Modified { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }
        public int ProjectID { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        public bool IsRejected { get; set; }
    }
}
