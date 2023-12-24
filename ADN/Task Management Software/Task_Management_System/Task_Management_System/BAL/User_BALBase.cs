using System.Data;
using Task_Management_System.DAL;

namespace Task_Management_System.BAL
{
    public class User_BALBase
    {
        User_DALBase dal = new User_DALBase();

        #region Get User...
        public DataTable PR_GetUser_Log(string Email, string Pass)
        {
            try
            {
                DataTable dt = dal.PR_GetUser_Log(Email, Pass);

                if(dt != null)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                    DataTable dt2 = dal.PR_UserWise_Project(id);
                    return dt2;
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
