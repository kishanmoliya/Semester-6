using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Users.Models
{
    public class AddTaskModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskState { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectID { get; set; }
        public int? MemberID { get; set; }
        public string TaskDescription { get; set; }
    }
}
