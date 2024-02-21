using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.BAL;
using Task_Management_System.BAL.IsValidUser;

namespace Task_Management_System.Areas.Users.Controllers
{
    [CheckAccess]
    [Area("Users")]
    public class TaskController : Controller
    {
        Task_BALBase bal = new Task_BALBase();

        #region Get Task
        [IsAdmin]
        public IActionResult Task(string ProjectID)
        {
            string decryptedData = UrlEncryptor.Decrypt(ProjectID);
            DataTable dt = bal.PR_ProjectWise_Task(Convert.ToInt32(decryptedData));
            CommonVariables.ProjectID = Convert.ToInt32(decryptedData);
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
            int PrjectID = CommonVariables.ProjectID;
            bool IsSuccess = bal.PR_Task_Insert(taskModel, PrjectID, TaskID);
            if (IsSuccess)
            {
                string ProjectID = UrlEncryptor.Encrypt(PrjectID.ToString());
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
            int PrjectID = CommonVariables.ProjectID;
            string ProjectID = UrlEncryptor.Encrypt(PrjectID.ToString());
            return RedirectToAction("Task", new { ProjectID });
        }
        #endregion

        #region Update Task
        public IActionResult UpdateTask(String TskID)
        {
            string decryptedData = UrlEncryptor.Decrypt(TskID);
            ViewBag.TaskID = Convert.ToInt32(decryptedData);
            DataTable dt = bal.PR_Task_SelectByPK(Convert.ToInt32(decryptedData));
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

        #region Reject or Restore
        public IActionResult TaskReject(int TskID, string IsRejected)
        {
            bal.PR_Task_Reject(TskID, IsRejected);
            int PrjectID = CommonVariables.ProjectID;
            string ProjectID = UrlEncryptor.Encrypt(PrjectID.ToString());
            return RedirectToAction("Task", new { ProjectID });
        }
        #endregion

        #region Task Details
        public IActionResult TaskDetails(String TaskID)
        {
            string decryptedData = UrlEncryptor.Decrypt(TaskID);
            CommonVariables.TaskID = Convert.ToInt32(decryptedData);
            TaskMemberViewModel model = new TaskMemberViewModel();
            model.TaskData = getTaskData(Convert.ToInt32(decryptedData));
            model.MemberData = getMemberData(Convert.ToInt32(decryptedData));
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
                Modified = Convert.ToDateTime(dt.Rows[0]["Modified"]),
                IsRejected = Convert.ToBoolean(dt.Rows[0]["IsRejected"])
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

        #region Task Delete 
        public IActionResult DeleteTask(int TskID)
        {
            bal.PR_Delete_Task(TskID);
            string ProjectID = UrlEncryptor.Encrypt(CommonVariables.ProjectID.ToString());
            return RedirectToAction("Task", new { ProjectID });
        }
        #endregion

        #region Add Member
        public IActionResult AddMemberForm()
        {
            return View("AddMember");
        }

        public IActionResult AddMember(AddMemberModel memberModel, int? MemberID)
        {
            int TskID = CommonVariables.TaskID;
            bool IsSuccess = bal.PR_Member_Insert(memberModel, TskID, MemberID);
            if (IsSuccess)
            {
                string TaskID = UrlEncryptor.Encrypt(TskID.ToString());
                return RedirectToAction("TaskDetails", new { TaskID });
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Delete Member
        public IActionResult DeleteMember(int MemberID, int TskID)
        {
            bal.PR_Delete_Member(MemberID);
            string TaskID = UrlEncryptor.Encrypt(TskID.ToString());
            return RedirectToAction("TaskDetails", new { TaskID });
        }
        #endregion

        #region Update Member
        public IActionResult UpdateMember(String MberID)
        {
            string decryptedData = UrlEncryptor.Decrypt(MberID);
            ViewBag.MemberID = Convert.ToInt32(decryptedData);
            DataTable dt = bal.PR_Member_SelectByPK(Convert.ToInt32(decryptedData));
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
        public IActionResult MemberDetails(String MemberID)
        {
            DataTable dt = bal.PR_Member_SelectByPK(Convert.ToInt32(UrlEncryptor.Decrypt(MemberID)));
            return View(dt);
        }
        #endregion
    }
}