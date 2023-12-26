using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Dashbord.Controllers
{
    [Area("Dashbord")]
    public class DashbordController : Controller
    {
        Dashbord_BALBase bal = new Dashbord_BALBase();
        public IActionResult Dashbord()
        {
            int id = Convert.ToInt32(TempData["ID"]);
            DataTable dt2 = bal.PR_UserWise_Project(id);
            if (dt2.Rows.Count > 0 && dt2 != null)
            {
                HttpContext.Session.SetInt32("UserSessionID", id);
                return View(dt2);
            }
          return View(null);
        }
    }
}
