﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.Areas.Admin.Models;

namespace Task_Management_System.DAL
{
    public class Admin_DALBase : DAL_Helper
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

        #region Add Project
        public bool PR_Add_Project(NewProjectModel prjModel)
        {
            try
            {
                SqlDatabase db = new SqlDatabase(ConnString);
                DbCommand cmd = db.GetStoredProcCommand("PR_Add_Project");
                db.AddInParameter(cmd, "@ProjectTitle", SqlDbType.VarChar, prjModel.ProjectTitle);
                db.AddInParameter(cmd, "@ProjectDescription", SqlDbType.VarChar, prjModel.ProjectDescription);
                db.AddInParameter(cmd, "@ProjectOwnerName", SqlDbType.VarChar, prjModel.ProjectOwnerName);
                db.AddInParameter(cmd, "@DeadLine", SqlDbType.DateTime, prjModel.DeadLine);
                db.AddInParameter(cmd, "@TotalMembers", SqlDbType.Int, prjModel.TotalMembers);
                db.AddInParameter(cmd, "@ProjectCost", SqlDbType.Decimal, prjModel.ProjectCost);
                db.AddInParameter(cmd, "@UserID", SqlDbType.Int, prjModel.UserID);
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