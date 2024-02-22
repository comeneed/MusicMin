using MusicMin.Models;

namespace MusicMin.ViewModels
{
    public class AuthenticateResponse 
        //这个是返回到用户登录成功之后的信息，授权响应对象
    {
      public AuthenticateResponse(User user,string token )
        {
            Id=user.Id;
            Token = token;
            Username = user.Username;
        }

        public int Id { get; set; }
        public string Token { get; set; }

        public string Username { get; set; }    
    }
}
