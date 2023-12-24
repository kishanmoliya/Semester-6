using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Task_Management_System.DAL
{
    public class User_DALBase : DAL_Helper
    {
        #region Get User...
        public DataTable PR_GetUser_Log(string Email, string Pass)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_GetUser_Log");
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, Email);
                db.AddInParameter(cmd, "@Password", SqlDbType.VarChar, Pass);
                DataTable dt = new DataTable();
                using(IDataReader reader = db.ExecuteReader(cmd))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (Exception ex) {
                return null;
            }
        }
        #endregion

        #region Get User Wise Project...
        public DataTable PR_UserWise_Project(int id)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_UserWise_Project");
                db.AddInParameter(cmd, "@UserID", SqlDbType.VarChar, id);             
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
