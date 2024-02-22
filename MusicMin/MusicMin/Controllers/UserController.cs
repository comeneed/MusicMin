using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MusicMin.Data;
using MusicMin.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicMin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptionsSnapshot<JWTOptions> jwtOptions;
        private readonly MusicMinDbContext ktton;
        public UserController(MusicMinDbContext ktton, IOptionsSnapshot<JWTOptions> jwtOptions)
        {
            this.ktton = ktton;
            this.jwtOptions = jwtOptions;
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

     
        
        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
        {
            var user = await ktton.Users.FirstOrDefaultAsync(u => u.Username == request.UserName && u.Password == request.Password);

            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
                claims.Add(new Claim(ClaimTypes.Name, request.UserName));

                string key = jwtOptions.Value.SigningKey;

                byte[] secBytes = Encoding.UTF8.GetBytes(key);
                var secKey = new SymmetricSecurityKey(secBytes);
                var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new JwtSecurityToken(claims: claims, signingCredentials: credentials);

                string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                return Ok(new { userName = request.UserName, Password = request.Password, token = jwt, message = "登录成功" });
            }
            else
            {
                return BadRequest(new { message = "用户名或密码错误" });
            }
        }
    }
}