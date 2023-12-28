using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class DashbordController : Controller
    {
        Admin_BALBase bal = new Admin_BALBase();
        public IActionResult Dashbord()
        {
            if (HttpContext.Session.GetInt32("EmployeeSessionID") != null)
            {
                DataTable dt = bal.PR_UserWise_Project(Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeSessionID")));
                return View(dt);
            }
            else
            {
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("EmployeeSessionID") != null)
            {
                HttpContext.Session.Remove("EmployeeSessionID");
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
            return View();
        }

    }
}
