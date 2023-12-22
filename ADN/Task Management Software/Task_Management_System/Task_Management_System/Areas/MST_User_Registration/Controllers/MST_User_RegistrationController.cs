using Microsoft.AspNetCore.Mvc;

namespace Task_Management_System.Areas.MST_User_Registration.Controllers
{
    [Area("MST_User_Registration")]
    public class MST_User_RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
