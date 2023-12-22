using APIDemo.Models;

namespace APIDemo.BAL
{
    public class User_BALBase
    {
        User_DALBase user_DALBase = new User_DALBase();
        #region Person SelectALl
        public List<UserModel> API_Person_SelectAll()
        {
            try
            {
                List<UserModel> userModels = user_DALBase.API_Person_SelectAll();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Person SelectByID
        public UserModel API_Person_SelectByID(int PersonID)
        {
            try
            {
                UserModel model = user_DALBase.API_Person_SelectByID(PersonID);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Person Delete
        public bool API_Person_Delete(int PersonID)
        {
            try
            {

                if (user_DALBase.API_Person_Delete(PersonID))
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

        #region Person Insert
        public bool API_Person_Insert(UserModel userModel)
        {
            try
            {

                if (user_DALBase.API_Person_Insert(userModel))
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

        #region Person Update
        public bool API_Person_Update(int PersonID, UserModel userModel)
        {
            try
            {

                if (user_DALBase.API_Person_Update(PersonID, userModel))
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
