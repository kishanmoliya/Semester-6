using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
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
            return View("Login");
        }

        public IActionResult Login(UserModel userModel)
        {
            DataTable dt = bal.PR_GetUser_Log(userModel.Email, userModel.Password);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["IsAdmin"]))
                {
                    HttpContext.Session.SetInt32("AdminSessionID", Convert.ToInt32(dt.Rows[0]["UserID"]));
                    return RedirectToAction("Dashbord", "Dashbord", new { area = "Admin" });
                }
                else
                {
                    HttpContext.Session.SetInt32("EmployeeSessionID", Convert.ToInt32(dt.Rows[0]["UserID"]));
                    return RedirectToAction("Dashbord", "Dashbord", new { area = "Employee" });
                }
            }
            else
            {
                ViewBag.Message = "Invalid Crediantial";
            }

            return View();
        }

        public IActionResult RegisterForm()
        {
            return View("Register");
        }

        public IActionResult Register(UserModel userModel)
        {
            bool IsSuccess = bal.PR_User_Insert(userModel);
            if (IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
