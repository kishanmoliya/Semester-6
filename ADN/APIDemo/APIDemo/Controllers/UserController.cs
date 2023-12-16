using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.API_Person_SelectAll();

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            if(users.Count > 0 && users != null) {
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
    }
}
