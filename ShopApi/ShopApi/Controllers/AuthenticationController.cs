using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ShopDbContext _context;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]User user)
        {
            IActionResult response = Unauthorized();
            var _user = Authenticate(user);

            if (_user == null)
                return response;
            var tokenString = BuildToken(_user);
            return Ok(new { token = tokenString });
        }

        private string BuildToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.FirstName + user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(User user)
        {
            User _user = null;

            var model = _context.Users.SingleOrDefault(x => x.FirstName == user.FirstName && x.LastName == user.LastName);

            if (model != null)
            {
                _user = new User()
                {
                    Email = $"Long@gmail.com",
                    FirstName = $"Long",
                    LastName = $"Đặng",
                    Active = false,
                    InsertedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserRoles = null,
                    SalesOrders = null
                };
            }

            return _user;
        }
    }
}