using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using TaskManagementSoftware.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskManagementSoftware.Controllers
{
    public class HomeController : Controller
    {
        private readonly Task_Management_SoftwareContext context;

        public HomeController(Task_Management_SoftwareContext context, IConfiguration configuration)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserRegistration user)
        {
            var myUser = context.UserRegistrations.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                HttpContext.Session.SetInt32("UserSessionID", myUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Invalid Crediantial";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                ViewBag.UserID = HttpContext.Session.GetInt32("UserSessionID");
                var data = context.ProjectList.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                HttpContext.Session.Remove("UserSessionID");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                await context.UserRegistrations.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}