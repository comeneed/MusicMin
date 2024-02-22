using System.ComponentModel.DataAnnotations;

namespace MusicMin.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Username { get; set; } // 用户名
        public string Password { get; set; } //密码
     
    }
}
