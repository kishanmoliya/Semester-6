using APIDemo.Models;
using APIDemo.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

public class User_DALBase : DAL_Helpers
{
    #region Person Select All
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
    #endregion

    #region Person SelectByID
    public UserModel API_Person_SelectByID(int PersonID)
    {
        try
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand command = sqlDatabase.GetStoredProcCommand("API_Person_SelectByID");
            sqlDatabase.AddInParameter(command, "@PersonID", SqlDbType.Int, PersonID);
            UserModel model = new UserModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(command))
            {
                while (dr.Read())
                {

                    model.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                    model.Name = dr["Name"].ToString();
                    model.Contact = dr["Contact"].ToString();
                    model.Email = dr["Email"].ToString();
                }
                return model;
            }
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
            SqlDatabase db = new SqlDatabase(ConnString);
            DbCommand command = db.GetStoredProcCommand("API_Person_Delete");
            db.AddInParameter(command, "@PersonID", SqlDbType.Int, PersonID);
            if (Convert.ToBoolean(db.ExecuteNonQuery(command)))
            {
                return true;
            }
            else { 
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
            SqlDatabase db = new SqlDatabase(ConnString);
            DbCommand command = db.GetStoredProcCommand("API_Person_Insert");
            db.AddInParameter(command, "@Name", SqlDbType.VarChar, userModel.Name);
            db.AddInParameter(command, "@Email", SqlDbType.VarChar, userModel.Email);
            db.AddInParameter(command, "@Contact", SqlDbType.VarChar, userModel.Contact);
            if (Convert.ToBoolean(db.ExecuteNonQuery(command)))
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
            SqlDatabase db = new SqlDatabase(ConnString);
            DbCommand command = db.GetStoredProcCommand("API_Person_Update");
            db.AddInParameter(command, "@PersonID", SqlDbType.Int, PersonID);
            db.AddInParameter(command, "@Name", SqlDbType.VarChar, userModel.Name);
            db.AddInParameter(command, "@Email", SqlDbType.VarChar, userModel.Email);
            db.AddInParameter(command, "@Contact", SqlDbType.VarChar, userModel.Contact);
            if (Convert.ToBoolean(db.ExecuteNonQuery(command)))
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

