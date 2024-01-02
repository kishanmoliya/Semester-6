using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.Areas.Admin.Models;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Dashbord.Controllers
{
    [CheckAccess]
    [Area("Admin")]
    public class DashbordController : Controller
    {
        Admin_BALBase bal = new Admin_BALBase();

        #region Dashbord
        public IActionResult Dashbord()
        {
            DataTable dt = bal.PR_UserWise_Project(Convert.ToInt32(HttpContext.Session.GetInt32("AdminSessionID")));
            return View(dt);
        }
        #endregion

        #region Add Project
        public IActionResult AddProjectForm()
        {
            return View("AddProject");
        }

        public IActionResult AddProject(NewProjectModel prjModel, int? ProjectID)
        {
            int UserID = Convert.ToInt32(HttpContext.Session.GetInt32("AdminSessionID"));
            bool IsSuccess = bal.PR_Add_Project(prjModel, UserID, ProjectID);
            if (IsSuccess)
            {
                return RedirectToAction("Dashbord");
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Delete 
        public IActionResult DeleteProject(int ProjectID)
        {
            bal.PR_Delete_Project(ProjectID);
            return RedirectToAction("Dashbord");
        }
        #endregion

        #region Get Single Project
        public IActionResult ProjectDetails(int ProjectID)
        {
            DataTable dt = bal.PR_Project_SelectByPK(ProjectID);
            if (dt.Rows.Count > 0)
            {
                return View(dt);
            }
            else
            {
                return View("Dashbord");
            }
        }
        #endregion

        #region Update Project
        public IActionResult UpdateProject(int ProjectID)
        {
            ViewBag.Data = ProjectID;
            DataTable dt = bal.PR_Project_SelectByPK(ProjectID);
            if (dt.Rows.Count > 0)
            {
                NewProjectModel prjModel = new NewProjectModel
                {
                    ProjectID = Convert.ToInt32(dt.Rows[0]["ProjectID"]),
                    ProjectTitle = Convert.ToString(dt.Rows[0]["ProjectTitle"]),
                    ProjectDescription = Convert.ToString(dt.Rows[0]["ProjectDescription"]),
                    ProjectOwnerName = Convert.ToString(dt.Rows[0]["ProjectOwnerName"]),
                    TotalMembers = Convert.ToInt32(dt.Rows[0]["TotalMembers"]),
                    ProjectCost = Convert.ToDouble(dt.Rows[0]["ProjectCost"]),
                    DeadLine = Convert.ToDateTime(dt.Rows[0]["DeadLine"]),
                };
                return View("AddProject", prjModel);
            }
            else
            {
                return View("Dashbord");
            }
            /*     bool IsSuccess = bal.PR_Update_Project(prjModel, ProjectID);

                 Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
                 if (IsSuccess)
                 {
                     return RedirectToAction("Dashbord");
                 }
                 else
                 {
                     return View();
                 }*/
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("AdminSessionID") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
            return View();
        }
        #endregion
    }
}
