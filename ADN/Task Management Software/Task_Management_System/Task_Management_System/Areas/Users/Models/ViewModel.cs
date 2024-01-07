namespace Task_Management_System.Areas.Users.Models
{
    public class ViewModel
    {
        public DashbordCountModel DashboordData { get; set; }
        public IEnumerable<NewProjectModel> ProjectDetails { get; set; }
    }
}
