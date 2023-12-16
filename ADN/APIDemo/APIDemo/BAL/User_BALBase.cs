using APIDemo.Models;

namespace APIDemo.BAL
{
    public class User_BALBase
    {
        public List<UserModel> API_Person_SelectAll()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels = user_DALBase.API_Person_SelectAll();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
