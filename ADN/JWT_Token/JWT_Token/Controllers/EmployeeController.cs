using JWT_Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [Route("GetData")]
        public string GetData()
        {
            return "Authenticate with GetData KKK";
        }

        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticate with Detail KKK";
        }

        [Authorize]
        [HttpPost]
        public string AddUser(Users user)
        {
            return "User Add with User Name" + user.UserName;
        }
    }
}
