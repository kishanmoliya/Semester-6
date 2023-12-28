using System.Data;
using Task_Management_System.Areas.Admin.Models;
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
        public bool PR_Add_Project(NewProjectModel prjModel)
        {
            try
            {

                if (dal.PR_Add_Project(prjModel))
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

