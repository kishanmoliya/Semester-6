using System.Data;
using Task_Management_System.Areas.MST_User_Registration.Models;
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

                if (dal.PR_User_Insert(userModel))
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
