using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Task_Management_System.Areas.MST_User_Registration.Models;

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

        #region Add User
        public bool PR_User_Insert(UserModel userModel)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_User_Insert");
                db.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, userModel.UserName);
                db.AddInParameter(cmd, "@Email", SqlDbType.VarChar, userModel.Email);
                db.AddInParameter(cmd, "@Password", SqlDbType.VarChar, userModel.Password);
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
