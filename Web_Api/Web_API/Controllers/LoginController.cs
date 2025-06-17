using Common.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepository<User> repository;
        private readonly IConfiguration config;
        public LoginController(IRepository<User> repository, IConfiguration config)
        {
            this.repository = repository;
            this.config = config;
        }


        // POST api/<LoginController>
        [HttpPost("login")]
        public IActionResult Login([FromQuery] LoginUser userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user); 
                return Ok(token);
            }
            return BadRequest("user does not exist");
        }

        private string Generate(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var carditional = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.FirstName+user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"], config["Jwt:Audience"]
                , claims,
          expires: DateTime.Now.AddDays(10),
              signingCredentials: carditional);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        private User Authenticate(LoginUser loginUser)
        {
            var user = repository.GetAll().FirstOrDefault(x => x.Email ==loginUser.email && x.Password == loginUser.password);
            if (user != null)
                return user;
            return null;
        }
    }
}
