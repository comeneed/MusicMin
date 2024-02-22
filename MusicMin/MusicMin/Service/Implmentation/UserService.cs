using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MusicMin.Data;
using MusicMin.JwtToken;
using MusicMin.Models;
using MusicMin.Service.Interfaces;
using MusicMin.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MusicMin.Service.Implmentation
{
    public class UserService : IUserService
    {

        private readonly MusicMinDbContext _context;
        private readonly JwtSetting _setting;
        public UserService(IOptions<JwtSetting> setting, MusicMinDbContext context)
        {
            _setting = setting.Value;
            _context = context;

        }



        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //通过账号来去验证用户是否是系统中的用户
            var user = _context.Users.SingleOrDefault(a => a.Username == model.Username && a.Password == model.Password);

            if (user == null)
            {
                return null;
            }
            //创建令牌
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.UTF8.GetBytes(_setting.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //获取用户身份信息
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("sub", user.Id.ToString()),
                        new Claim("username", user.Username),
                    }),
                //过期时间
                Expires = DateTime.UtcNow.AddDays(1),
                //证书签名
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public User GetById(int Id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == Id);
        }
    }
}
