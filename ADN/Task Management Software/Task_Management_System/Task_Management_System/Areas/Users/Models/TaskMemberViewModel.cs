using Microsoft.AspNetCore.Mvc;

namespace Task_Management_System.Areas.Users.Models
{
    public class TaskMemberViewModel : Controller
    {
        public AddTaskModel TaskData { get; set; }
        public IEnumerable<AddMemberModel> MemberData { get; set; }
    }
}
