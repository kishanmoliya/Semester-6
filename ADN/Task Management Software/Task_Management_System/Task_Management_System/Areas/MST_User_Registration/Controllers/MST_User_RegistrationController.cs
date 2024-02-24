using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        User_DALBase bal = new User_DALBase();

        #region User Login
        #region Login Form
        public IActionResult Index()
        {
            return View("Login");
        }
        #endregion

        public IActionResult Login(UserModel userModel)
        {
            DataTable dt = bal.PR_GetUser_Log(userModel.Email, userModel.Password);
            if (dt.Rows.Count > 0)
            {
                HttpContext.Session.SetInt32("UserID", Convert.ToInt32(dt.Rows[0]["UserID"]));
                HttpContext.Session.SetString("UserName", Convert.ToString(dt.Rows[0]["UserName"]));
                HttpContext.Session.SetString("IsAdmin", dt.Rows[0]["IsAdmin"].ToString());
                HttpContext.Session.SetString("Email", dt.Rows[0]["Email"].ToString());
                return RedirectToAction("Dashbord", "Dashbord", new { area = "Users" });
            }
            else
            {
                ViewBag.Message = "Invalid Crediantial";
            }
            return View();
        }
        #endregion

        #region Register User
        #region Registration Form
        public IActionResult RegisterForm()
        {
            return View("Register");
        }
        #endregion

        public IActionResult Register(UserModel userModel)
        {
            bool IsSuccess = bal.PR_User_Insert(userModel);
            if (IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = CommonVariables.Error;
                return View();
            }
        }
        #endregion
    }
}
