using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MusicMin.Data;

namespace MusicMin
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MusicMinDbContext>
    {
        public MusicMinDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MusicMinDbContext> bulider = new DbContextOptionsBuilder<MusicMinDbContext>(); bulider.UseSqlServer("Server=DESKTOP-DGSNR9I\\SQLEXPRESS;Database=MyppleMusic;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new MusicMinDbContext(bulider.Options);
        }
    }
}
