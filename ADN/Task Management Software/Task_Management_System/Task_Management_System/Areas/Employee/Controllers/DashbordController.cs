using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.BAL;
using Task_Management_System.BAL.IsValidUser;

namespace Task_Management_System.Areas.Employee.Controllers
{
    [CheckAccess]
    [Area("Employee")]
    public class DashbordController : Controller
    {
        Admin_BALBase bal = new Admin_BALBase();
        public IActionResult Dashbord()
        {
            DataTable dt = bal.PR_UserWise_Project(Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeSessionID")));
            return View(dt);
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("EmployeeSessionID") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
            return View();
        }

    }
}
