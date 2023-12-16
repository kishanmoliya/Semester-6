using APIDemo.Models;
using APIDemo.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

public class User_DALBase : DAL_Helpers
{
    public List<UserModel> API_Person_SelectAll()
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Person_SelectAll");
            List<UserModel> userModels = new List<UserModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    UserModel userModel = new UserModel();
                    userModel.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                    userModel.Name = dr["Name"].ToString();
                    userModel.Contact = dr["Contact"].ToString();
                    userModel.Email = dr["Email"].ToString();
                    userModels.Add(userModel);
                }
            }
            return userModels;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

