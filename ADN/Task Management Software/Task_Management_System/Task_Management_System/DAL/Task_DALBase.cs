using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Task_Management_System.Areas.Users.Models;

namespace Task_Management_System.DAL
{
    public class Task_DALBase : DAL_Helper
    {
        #region Get Task...
        public DataTable PR_Project_Task(int ProjectID)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_Task_SelectByPK");
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
              /*  try
                {
                    SqlDatabase db = new SqlDatabase(ConnString);
                    DbCommand cmd = db.GetStoredProcCommand("PR_Update_Project");
                    db.AddInParameter(cmd, "@ProjectID", SqlDbType.Int, prjModel.ProjectID);
                    db.AddInParameter(cmd, "@ProjectTitle", SqlDbType.VarChar, prjModel.ProjectTitle);
                    db.AddInParameter(cmd, "@ProjectDescription", SqlDbType.VarChar, prjModel.ProjectDescription);
                    db.AddInParameter(cmd, "@ProjectOwnerName", SqlDbType.VarChar, prjModel.ProjectOwnerName);
                    db.AddInParameter(cmd, "@DeadLine", SqlDbType.DateTime, prjModel.DeadLine);
                    db.AddInParameter(cmd, "@TotalMembers", SqlDbType.Int, prjModel.TotalMembers);
                    db.AddInParameter(cmd, "@ProjectCost", SqlDbType.Decimal, prjModel.ProjectCost);
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
                }*/
            }
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_Task_Insert");
                db.AddInParameter(cmd, "@TaskName", SqlDbType.VarChar, taskModel.TaskName);
                db.AddInParameter(cmd, "@ProjectID", SqlDbType.Int, ProjectID);
                db.AddInParameter(cmd, "@TaskDescription", SqlDbType.VarChar, taskModel.TaskDescription);
                db.AddInParameter(cmd, "@MemberID", SqlDbType.VarChar, taskModel.MemberID);
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


    }
}
