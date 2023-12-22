using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        User_BALBase bal = new User_BALBase();
        #region Select All Person
        [HttpGet]
        public IActionResult Get()
        {

            List<UserModel> users = bal.API_Person_SelectAll();
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                data.Add("status", true);
                data.Add("message", "Data Found.");
                data.Add("Data", users);
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Data Not Found.");
                data.Add("Data", null);
                return NotFound(data);
            }
        }
        #endregion

        #region Person GetBy ID
        [HttpGet]
        public IActionResult GetByID(int PersonID)
        {
            UserModel person = bal.API_Person_SelectByID(PersonID);

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (person.PersonID != 0)
            {
                data.Add("status", true);
                data.Add("message", "Data Found.");
                data.Add("Data", person);
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Data Not Found.");
                data.Add("Data", null);
                return NotFound(data);
            }

        }
        #endregion

        #region Person Delete
        [HttpDelete]
        public IActionResult Delete(int PersonID)
        {
            bool IsSuccess = bal.API_Person_Delete(PersonID);

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if(IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Deleted Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some Error has been Occured");
                return Ok(data);
            }
        }
        #endregion

        #region Person Insert
        [HttpPost]
        public IActionResult Insert([FromForm] UserModel userModel)
        {
            bool IsSuccess = bal.API_Person_Insert(userModel);

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Deleted Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some Error has been Occured");
                return Ok(data);
            }
        }
        #endregion

        #region Person Update
        [HttpPut]
        public IActionResult Update(int PersonID, [FromForm] UserModel userModel)
        {
            bool IsSuccess = bal.API_Person_Update(PersonID, userModel);
            userModel.PersonID = PersonID;

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "Data Deleted Successfully");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "Some Error has been Occured");
                return Ok(data);
            }
        }
        #endregion
    }
}
