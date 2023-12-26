using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.BAL;

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
            if (HttpContext.Session.GetInt32("UserSessionID") != null)
            {
                return RedirectToAction("Dashbord", "Dashbord", new { area = "Dashbord" });
            }
            return View("Login");
        }

        public IActionResult Login(UserModel userModel)
        {
            DataTable dt = bal.PR_GetUser_Log(userModel.Email, userModel.Password);

            if (dt.Rows.Count > 0)
            {
                TempData["ID"] = Convert.ToInt32(dt.Rows[0]["UserID"]);

                /*ViewBag.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);*/
                return RedirectToAction("Dashbord", "Dashbord", new { area = "Dashbord" });
            }
            else
            {
                ViewBag.Message = "Invalid Crediantial";
            }

            return View();
        }

        public IActionResult Dashbord(DataTable dt)
        {
            if (HttpContext.Session.GetInt32("UserSessionID") != null)
            {
                return View(dt);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        /* public IActionResult Index()
         {
             if (HttpContext.Session.GetInt32("UserSessionID") != null)
             {
                 return RedirectToAction("Dashbord","Dashbord", new { area = "Dashbord" });
             }
             return View("Login");
         }

         public IActionResult Login(UserModel userModel)
         {
             DataTable dt = bal.PR_GetUser_Log(userModel.Email, userModel.Password);

             if (dt.Rows.Count > 0)
             {
                 if (dt.Rows.Count > 0)
                 {
                     int id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                     DataTable dt2 = bal.PR_UserWise_Project(id);
                     if (dt2 != null) {
                         HttpContext.Session.SetInt32("UserSessionID", Convert.ToInt32(dt.Rows[0]["UserID"]));
                         return RedirectToAction("Dashbord", "Dashbord", new { area = "Dashbord" });
                     }
                     else
                     {
                         return null;
                     }
                 }
                 else
                 {
                     return null;
                 }              
             }
             else
             {
                 ViewBag.Message = "Invalid Crediantial";
             }

             return View();
         }

         public IActionResult Dashbord(DataTable dt)
         {
             if(HttpContext.Session.GetInt32("UserSessionID") != null)
             {
                 return View(dt);
             }
             else
             {
                 return RedirectToAction("Login");
             }
         }

         public IActionResult Register()
         {
             return View();
         }*/
    }
}
