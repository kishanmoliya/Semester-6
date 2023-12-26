using System.Data;
using Task_Management_System.DAL;

namespace Task_Management_System.BAL
{
    public class Dashbord_BALBase
    {
        Dashbord_DALBase dal = new Dashbord_DALBase();
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
    }
}

