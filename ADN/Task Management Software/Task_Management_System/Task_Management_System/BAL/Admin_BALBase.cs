using System.Data;
using Task_Management_System.Areas.Users.Models;
using Task_Management_System.Areas.MST_User_Registration.Models;
using Task_Management_System.DAL;

namespace Task_Management_System.BAL
{
    public class Admin_BALBase
    {
        Admin_DALBase dal = new Admin_DALBase();
        #region User Wise Project 
        public DataTable PR_UserWise_Project(int id)
        {
            try
            {
                DataTable dt = dal.PR_UserWise_Project(id);
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

        #region Add Project
        public bool PR_Add_Project(NewProjectModel prjModel, int UserID, int? ProjectID)
        {
            try
            {

                if (dal.PR_Add_Project(prjModel, UserID, ProjectID))
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

        #region Delete Projecet
        public bool PR_Delete_Project(int ProjectID)
        {
            try
            {

                if (dal.PR_Delete_Project(ProjectID))
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

        #region Project Details
        public DataTable PR_Project_SelectByPK(int ProjectID)
        {
            try
            {
                DataTable dt = dal.PR_Project_SelectByPK(ProjectID);
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

        #region DashbordData
        public DataTable DashbordCount(int id)
        {
            try
            {
                DataTable dt = dal.DashbordCount(id);
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

