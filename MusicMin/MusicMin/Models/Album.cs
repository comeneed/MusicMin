using System.ComponentModel.DataAnnotations;

namespace MusicMin.Models
{
    public class Album //专辑管理
    {
 
        public long Id { get; set; }
        public string? CoverPath { get; set; } // 封面图路径
        [Key]
        public string Artist { get; set; } // 艺人
        public string Title { get; set; } // 专辑名
        public string Genre { get; set; } // 类型
        public DateTime ReleaseDate { get; set; } // 发行时间
    }
}
