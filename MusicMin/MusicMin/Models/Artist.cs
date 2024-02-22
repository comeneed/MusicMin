using System.ComponentModel.DataAnnotations;

namespace MusicMin.Models
{
    public class Artist
    {
       
        public long Id { get; set; }
        public string? ImagePath { get; set; } // 艺人图片路径
        [Key]
        public string Name { get; set; } // 艺人姓名

    }
}
