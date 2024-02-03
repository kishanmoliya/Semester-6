using Microsoft.CodeAnalysis;
using System.Data;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.DAL;

namespace Task_Management_System.BAL
{
    public class Task_BALBase
    {
        Task_DALBase dal = new Task_DALBase();
        #region Project Wise Task 
        public DataTable PR_ProjectWise_Task(int ProjectID)
        {
            try
            {
                DataTable dt = dal.PR_ProjectWise_Task(ProjectID);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Add Task
        public bool PR_Task_Insert(AddTaskModel taskModel,int ProjectID, int? TaskID)
        {
            try
            {

                if (dal.PR_Task_Insert(taskModel,ProjectID, TaskID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Change Task State
        public bool PR_State_Change(int TaskID, string TaskState)
        {
            try
            {
                if (dal.PR_State_Change(TaskID, TaskState))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Task Details
        public DataTable PR_Task_SelectByPK(int TaskID)
        {
            try
            {
                DataTable dt = dal.PR_Task_SelectByPK(TaskID);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Add Member
        public bool PR_Member_Insert(AddMemberModel memberModel, int TaskID, int? MemberID)
        {
            try
            {

                if (dal.PR_Member_Insert(memberModel, TaskID, MemberID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Task Wise Member 
        public DataTable PR_TaskWise_Member(int TaskID)
        {
            try
            {
                DataTable dt = dal.PR_TaskWise_Member(TaskID);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Delete Member
        public bool PR_Delete_Member(int MemberID)
        {
            try
            {

                if (dal.PR_Delete_Member(MemberID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Member SelectByID
        public DataTable PR_Member_SelectByPK(int MemberID)
        {
            try
            {
                DataTable dt = dal.PR_Member_SelectByPK(MemberID);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
