﻿using System.Data;
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
