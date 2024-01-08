using System.Data;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.DAL;

namespace Task_Management_System.BAL
{
    public class Task_BALBase
    {
        Task_DALBase dal = new Task_DALBase();
        #region Project Wise Task 
        public DataTable PR_Project_Task(int ProjectID)
        {
            try
            {
                DataTable dt = dal.PR_Project_Task(ProjectID);
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
    }
}
