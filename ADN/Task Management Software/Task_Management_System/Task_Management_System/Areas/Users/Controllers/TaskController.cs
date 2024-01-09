using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
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
            DataTable dt = bal.PR_Project_Task(ProjectID);
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
            int ProjectID = Convert.ToInt32(TempData["ProjectID"]);
            bool IsSuccess = bal.PR_Task_Insert(taskModel, ProjectID, TaskID);
            if (IsSuccess)
            {
                return RedirectToAction("Task", new { ProjectID });
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Change State
        public IActionResult MoveToProgress(int TaskID, string TaskState)
        {
            bal.PR_State_Change(TaskID, TaskState);
            int ProjectID = Convert.ToInt32(TempData["ProjectID"]);
            return RedirectToAction("Task", new { ProjectID });
        }
        #endregion

        #region Update Project
        public IActionResult UpdateTask(int TaskID)
        {
            ViewBag.TaskID = TaskID;
            DataTable dt = bal.PR_Task_SelectByPK(TaskID);
            if (dt.Rows.Count > 0)
            {
                AddTaskModel taskModel = new AddTaskModel
                {
                    TaskID = Convert.ToInt32(dt.Rows[0]["TaskID"]),
                    TaskName = Convert.ToString(dt.Rows[0]["TaskName"]),
                    TaskDescription = Convert.ToString(dt.Rows[0]["TaskDescription"]),
                    DeadLine = Convert.ToDateTime(dt.Rows[0]["DeadLine"]),
                };
                return View("AddTask", taskModel);
            }
            else
            {
                return View("Dashbord");
            }
        }
        #endregion
    }
}