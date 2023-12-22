using Microsoft.AspNetCore.Mvc;
using TaskManagementSoftware.Areas.User_Registration.Models;

namespace TaskManagementSoftware.Areas.User_Registration.Controllers
{
    [Area("User_Registration")]
    public class PersonController : Controller
    {
        private readonly Task_Management_SoftwareContext context;

        public PersonController(Task_Management_SoftwareContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
          /*  var data = context.Person.ToList();
            return View("PersonDetails", data);*/
          return View();
        }
    }
}
