using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Task_Management_System.Areas.Users.Models;

namespace Task_Management_System.DAL
{
    public class Task_DALBase : DAL_Helper
    {
        SqlDatabase db = new SqlDatabase(ConnString);
        #region Get Task...
        public DataTable PR_ProjectWise_Task(int ProjectID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_ProjectWise_Task");
                db.AddInParameter(cmd, "@ProjectID", SqlDbType.Int, ProjectID);
                DataTable dt = new DataTable();
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    dt.Load(reader);
                }
                return dt;
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
            if (TaskID != null)
            {
                try
                {
                    DbCommand cmd = db.GetStoredProcCommand("PR_Update_Task");
                    db.AddInParameter(cmd, "@TaskID", SqlDbType.Int, TaskID);
                    db.AddInParameter(cmd, "@TaskName", SqlDbType.VarChar, taskModel.TaskName);
                    db.AddInParameter(cmd, "@TaskDescription", SqlDbType.VarChar, taskModel.TaskDescription);
                    db.AddInParameter(cmd, "@DeadLine", SqlDbType.DateTime, taskModel.DeadLine);
                    if (Convert.ToBoolean(db.ExecuteNonQuery(cmd)))
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
            try
            {                
                DbCommand cmd = db.GetStoredProcCommand("PR_Task_Insert");
                db.AddInParameter(cmd, "@TaskName", SqlDbType.VarChar, taskModel.TaskName);
                db.AddInParameter(cmd, "@ProjectID", SqlDbType.Int, ProjectID);
                db.AddInParameter(cmd, "@TaskDescription", SqlDbType.VarChar, taskModel.TaskDescription);
                db.AddInParameter(cmd, "@MemberID", SqlDbType.VarChar, taskModel.MemberID == null ? null: taskModel.MemberID);
                db.AddInParameter(cmd, "@DeadLine", SqlDbType.DateTime, taskModel.DeadLine);
                if (Convert.ToBoolean(db.ExecuteNonQuery(cmd)))
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

        #region Task State Change
        public bool PR_State_Change(int TaskID, string TaskState)
        {
            DbCommand cmd = db.GetStoredProcCommand("PR_State_Change");
            db.AddInParameter(cmd, "@TaskID", SqlDbType.Int, TaskID);
            db.AddInParameter(cmd, "@TaskState", SqlDbType.VarChar, TaskState);
            if(Convert.ToBoolean(db.ExecuteNonQuery(cmd)))
            {
                return true;
            }
            else
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
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_Task_SelectByPK");
                db.AddInParameter(cmd, "@TaskID", SqlDbType.VarChar, TaskID);
                DataTable dt = new DataTable();
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
