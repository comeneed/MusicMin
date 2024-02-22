using System.ComponentModel.DataAnnotations;

namespace MusicMin.Models
{
    public class Songs
    {
        
        public int Id { get; set; }
        public string Title { get; set; } // 歌名
        public string Artist { get; set; } // 歌手
        public string Album { get; set; } // 专辑
        public string Genre { get; set; } // 类型
        public int Duration { get; set; } // 时长（假设以秒为单位）
        public string? FilePath { get; set; } // 歌曲的路径
        public string? CoverPath { get; set; } // 歌曲的封面路径
    }
}

