using Microsoft.EntityFrameworkCore;
using MusicMin.Models;

namespace MusicMin.Data
{
    public class MusicMinDbContext:DbContext
    {
        public MusicMinDbContext(DbContextOptions<MusicMinDbContext> options) : base(options) { }   

        public DbSet<Songs> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
    }
}
