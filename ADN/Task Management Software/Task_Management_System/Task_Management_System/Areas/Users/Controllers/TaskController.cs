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
        #region Get Task
        public IActionResult Task(int ProjectID)
        {
            DataTable dt = bal.PR_ProjectWise_Task(ProjectID);
            CommonVariables.ProjectID = ProjectID;
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
            int ProjectID = CommonVariables.ProjectID;
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
            int ProjectID = CommonVariables.ProjectID;
            return RedirectToAction("Task", new { ProjectID });
        }
        #endregion

        #region Update Task
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

        #region Task Details
        public IActionResult TaskDetails(int TaskID)
        {
            CommonVariables.TaskID = TaskID;
            TaskMemberViewModel model = new TaskMemberViewModel();
            model.TaskData = getTaskData(TaskID);
            model.MemberData = getMemberData(TaskID);
            return View(model);
        }

        public AddTaskModel getTaskData(int TaskID)
        {
            DataTable dt = bal.PR_Task_SelectByPK(TaskID);
            AddTaskModel TskData = new AddTaskModel
            {
                TaskID = Convert.ToInt32(dt.Rows[0]["TaskID"]),
                TaskName = Convert.ToString(dt.Rows[0]["TaskName"]),
                TaskDescription = Convert.ToString(dt.Rows[0]["TaskDescription"]),
                TaskState = Convert.ToString(dt.Rows[0]["TaskState"]),
                CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]),
                DeadLine = Convert.ToDateTime(dt.Rows[0]["DeadLine"]),
                Modified = Convert.ToDateTime(dt.Rows[0]["Modified"])
            };
            return TskData;
        }

        public List<AddMemberModel> getMemberData(int TaskID)
        {
            DataTable dt = bal.PR_TaskWise_Member(TaskID);
            List<AddMemberModel> newMember = new List<AddMemberModel>();
            foreach (DataRow dr in dt.Rows)
            {
                AddMemberModel member = new AddMemberModel
                {
                    MemberID = Convert.ToInt32(dr["MemberID"]),
                    MemberName = Convert.ToString(dr["MemberName"]),
                    MemberContact = Convert.ToString(dr["MemberContact"]),
                    MemberEmail = Convert.ToString(dr["MemberEmail"]),
                    MemberRole = Convert.ToString(dr["MemberRole"]),
                    MemberTechnology = Convert.ToString(dr["MemberTechnology"]),
                    MemberAge = Convert.ToInt32(dr["MemberAge"]),
                    MemberSalary = Convert.ToDouble(dr["MemberSalary"]),
                };
                newMember.Add(member);
            }
            return newMember;
        }
        #endregion

        #region Add Member
        public IActionResult AddMemberForm()
        {
            return View("AddMember");
        }

        public IActionResult AddMember(AddMemberModel memberModel, int? MemberID)
        {
            int TaskID = CommonVariables.TaskID;
            bool IsSuccess = bal.PR_Member_Insert(memberModel, TaskID, MemberID);
            if (IsSuccess)
            {
                return RedirectToAction("TaskDetails", new { TaskID });
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Delete Member
        public IActionResult DeleteMember(int MemberID, int TaskID)
        {
            bal.PR_Delete_Member(MemberID);
            return RedirectToAction("TaskDetails", new { TaskID });
        }
        #endregion

        #region Update Member
        public IActionResult UpdateMember(int MemberID)
        {
            ViewBag.MemberID = MemberID;
            DataTable dt = bal.PR_Member_SelectByPK(MemberID);
            if (dt.Rows.Count > 0)
            {
                AddMemberModel memberModel = new AddMemberModel
                {
                    MemberID = Convert.ToInt32(dt.Rows[0]["MemberID"]),
                    MemberName = Convert.ToString(dt.Rows[0]["MemberName"]),
                    MemberContact = Convert.ToString(dt.Rows[0]["MemberContact"]),
                    MemberEmail = Convert.ToString(dt.Rows[0]["MemberEmail"]),
                    MemberRole = Convert.ToString(dt.Rows[0]["MemberRole"]),
                    MemberTechnology = Convert.ToString(dt.Rows[0]["MemberTechnology"]),
                    MemberAge = Convert.ToInt32(dt.Rows[0]["MemberAge"]),
                    MemberSalary = Convert.ToDouble(dt.Rows[0]["MemberSalary"]),
                };
                return View("AddMember", memberModel);
            }
            else
            {
                return View("Dashbord");
            }
        }
        #endregion

        #region Member Details
        public IActionResult MemberDetails(int MemberID)
        {
            DataTable dt = bal.PR_Member_SelectByPK(MemberID);
            return View(dt);
        }
        #endregion
    }
}