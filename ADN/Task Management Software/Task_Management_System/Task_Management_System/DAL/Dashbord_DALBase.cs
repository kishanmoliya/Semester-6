using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Task_Management_System.DAL
{
    public class Dashbord_DALBase : DAL_Helper
    {
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
