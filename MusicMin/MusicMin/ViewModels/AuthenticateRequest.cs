using System.ComponentModel.DataAnnotations;

namespace MusicMin.ViewModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; } // 用户名
        public string Password { get; set; } //密码
    }
}
