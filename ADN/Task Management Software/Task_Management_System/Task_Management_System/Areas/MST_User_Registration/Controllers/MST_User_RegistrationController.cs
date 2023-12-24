using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.BAL;
using Task_Management_System.DAL;

namespace Task_Management_System.Areas.MST_User_Registration.Controllers
{
    [Area("MST_User_Registration")]
    public class MST_User_RegistrationController : Controller
    {
        private readonly IConfiguration Configuration;
        public MST_User_RegistrationController(IConfiguration _configuration)
        {      
            Configuration = _configuration;
        }

        User_BALBase bal = new User_BALBase();  
        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login(UserModel userModel)
        {
            DataTable dt = bal.PR_GetUser_Log(userModel.Email, userModel.Password);

            return View("Dashbord", dt);
        }

        public IActionResult Register()
        {          
            return View();
        }
    }
}
