﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.Xml;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.BAL;
using Task_Management_System.BAL.IsValidUser;

namespace Task_Management_System.Areas.Dashbord.Controllers
{
    [CheckAccess]
    [Area("Users")]
    public class DashbordController : Controller
    {
        Admin_BALBase bal = new Admin_BALBase();
        Task_BALBase Task_bal = new Task_BALBase();

        #region Dashbord
        public IActionResult Dashbord(string? PrjState)
        {
            ViewModel model = new ViewModel();
            model.DashboordData = getDashbordData();
            model.ProjectDetails = getProjectDetails(PrjState);
            return View(model);
        }

        public DashbordCountModel getDashbordData()
        {
            DataTable dt = bal.DashbordCount(Convert.ToInt32(CommonVariables.UserID()));
            DashbordCountModel dashbordData = new DashbordCountModel
            {
                sumOfMember = Convert.ToInt32(dt.Rows[0]["sumOfMember"]),
                sumOfProject = Convert.ToInt32(dt.Rows[0]["sumOfProject"]),
                sumOfBudget = Convert.ToDouble(dt.Rows[0]["sumOfBudget"]),
                sumOfCustomers = Convert.ToInt32(dt.Rows[0]["sumOfCustomers"])
            };
            return dashbordData;
        }

        public List<NewProjectModel> getProjectDetails(string? PrjState)
        {
            DataTable dt = bal.PR_UserWise_Project(Convert.ToInt32(HttpContext.Session.GetInt32("UserID")), PrjState);
            List<NewProjectModel> newProject = new List<NewProjectModel>();
            foreach (DataRow dr in dt.Rows)
            {
                NewProjectModel model = new NewProjectModel
                {
                    ProjectID = Convert.ToInt32(dr["ProjectID"]),
                    ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
                    ProjectDescription = Convert.ToString(dr["ProjectDescription"]),
                    ProjectOwnerName = Convert.ToString(dr["ProjectOwnerName"]),
                    DeadLine = Convert.ToDateTime(dr["DeadLine"]),
                    TotalMembers = Convert.ToInt32(dr["TotalMembers"]),
                    ProjectCost = Convert.ToDouble(dr["ProjectCost"]),
                    UserID = Convert.ToInt32(dr["UserID"]),
                    ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]),
                    ProjectState = Convert.ToString(dr["ProjectState"]),
                };
                newProject.Add(model);
            }
            return newProject;
        }
        #endregion

        #region Add Project
        public IActionResult AddProjectForm()
        {
            return View("AddProject");
        }

        public IActionResult AddProject(NewProjectModel prjModel, int? ProjectID)
        {
            int UserID = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
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
           
                if (bal.PR_Delete_Project(ProjectID))
                {
                    return RedirectToAction("Dashbord");
                }
                else
                {
                    return RedirectToAction("Dashbord");
                }
          
        }
        #endregion

        #region Get Single Project
        public IActionResult ProjectDetails(string ProjectID)
        {
            string decryptedData = UrlEncryptor.Decrypt(ProjectID);
            DataTable dt = bal.PR_Project_SelectByPK(Convert.ToInt32(decryptedData));
            DataTable dt2 = Task_bal.GetProjectMember(Convert.ToInt32(decryptedData));
            ViewBag.MemberList = dt2;

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
        public IActionResult UpdateProject(string PrjectID)
        {
            string decryptedData = UrlEncryptor.Decrypt(PrjectID);
            ViewBag.Data = Convert.ToInt32(decryptedData);

            DataTable dt = bal.PR_Project_SelectByPK(Convert.ToInt32(decryptedData));
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
                    ProjectState = Convert.ToString(dt.Rows[0]["ProjectState"])
                };
                return View("AddProject", prjModel);
            }
            else
            {
                return View("Dashbord");
            }
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
            return View();
        }
        #endregion
    }
}
