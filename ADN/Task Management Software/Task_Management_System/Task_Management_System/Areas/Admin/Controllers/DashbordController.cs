﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.Areas.Admin.Models;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Dashbord.Controllers
{
    [Area("Admin")]
    public class DashbordController : Controller
    {
        Admin_BALBase bal = new Admin_BALBase();
        public IActionResult Dashbord()
        {
            if (HttpContext.Session.GetInt32("AdminSessionID") != null)
            {
                DataTable dt = bal.PR_UserWise_Project(Convert.ToInt32(HttpContext.Session.GetInt32("AdminSessionID")));
                return View(dt);
            }
            else
            {
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("AdminSessionID") != null)
            {
                HttpContext.Session.Remove("AdminSessionID");
                return RedirectToAction("Index", "MST_User_Registration", new { area = "MST_User_Registration" });
            }
            return View();
        }

        public IActionResult AddProjectForm()
        {
            return View("AddProject");
        }

        public IActionResult AddProject(NewProjectModel prjModel)
        {
            bool IsSuccess = bal.PR_Add_Project(prjModel);
            if (IsSuccess)
            {
                return RedirectToAction("Dashbord");
            }
            else
            {
                return View();
            }
        }
    }
}
