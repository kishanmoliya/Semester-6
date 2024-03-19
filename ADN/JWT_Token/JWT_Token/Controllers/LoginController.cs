using JWT_Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT_Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;

        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        private Users AuthenticateUser(Users user)
        {
            Users _user = null;
            if (user.UserName == "kkk" && user.Password == "kkk")
            {
                _user = new Users { UserName = "kishan" };
            }
            return _user;
        }


        private string GenerateToken(Users user)
        {
            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credantial = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:IAudience"], null,
                expires: DateTime.Now.AddMinutes(10), signingCredentials: credantial
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);

            if (user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new {token = token});

            }

            return response;
        }
    }
}
