using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.BAL;

namespace Task_Management_System.Areas.Users.Controllers
{
    [CheckAccess]
    [Area("Users")]
    public class TaskController : Controller
    {
        Task_BALBase bal = new Task_BALBase();
        #region All Task
        public IActionResult Task(int ProjectID)
        {
            DataTable dt = bal.PR_Project_Task(Convert.ToInt32(TempData["ProjectID"]));
            TempData["ProjectID"] = ProjectID;
            return View(dt);
        }
        #endregion

        #region Add Task
        public IActionResult AddTaskForm()
        {
            return View("AddTask");
        }

        public IActionResult AddTask(AddTaskModel taskModel, int? TaskID)
        {
            bool IsSuccess = bal.PR_Task_Insert(taskModel, Convert.ToInt32(TempData["ProjectID"]), TaskID);
            if (IsSuccess)
            {
                return RedirectToAction("Task");
            }
            else
            {
                return View();
            }
        }
        #endregion

        public IActionResult MoveToProgress(int TaskID)
        {
            /*Change State Procedure*/
            return RedirectToAction("Task");
        }
    }
}