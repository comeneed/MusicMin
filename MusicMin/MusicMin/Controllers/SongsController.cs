using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMin.Data;
using MusicMin.Models;

namespace MusicMin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SongsController : ControllerBase
    {
        private readonly MusicMinDbContext context;

        public SongsController(MusicMinDbContext son)
        {
            context = son;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetAll()
        {
            var list = context.Songs.ToList();
            if (list == null)
            {
                return NotFound("数据为空");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpPost("{Title}")]
        //查询歌名
        public async Task<ActionResult<IEnumerable<Songs>>> GetSongName(string Title)
        {
            var list =  context.Songs.Where(x => x.Title == Title).ToList();
            if (list == null)
            {
                return NotFound("查询失败");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpPost("{Genre}")]
        //查询Genre类型
        public async Task<ActionResult<IEnumerable<Songs>>> GetGenre(string Genre)
        {
            var list = context.Songs.Where(x => x.Genre == Genre).ToList();
            if (list == null)
            {
                return NotFound("查询失败");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpPost("{Artist}")]
        //查询Artist 歌手
        public async Task<ActionResult<IEnumerable<Songs>>> GetArtist(string Artist)
        {
            var list = context.Songs.Where(x => x.Artist == Artist).ToList();
            if (list == null)
            {
                return NotFound("查询失败");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpPost("{Album}")]
        //查询专辑Album
        public async Task<ActionResult<IEnumerable<Songs>>> GetAlbum(string Album)
        {
            var list = context.Songs.Where(x => x.Album == Album).ToList();
            if (list == null)
            {
                return NotFound("查询失败");
            }
            else
            {
                return Ok(list);
            }
        }

        [HttpDelete("{Title}")]
        public async Task<ActionResult<IEnumerable<Songs>>> DeleteOne(string Title)
        {
            var list = context.Songs.FirstOrDefault(x => x.Title == Title);
            if (list != null)
            {
                context.Songs.Remove(list);
                await context.SaveChangesAsync();
                return Ok("删除成功");
            }
            else
            {
                return BadRequest("删除失败");
            }
        }



        [HttpPost]
        public async Task<ActionResult<Songs>> InsertSong(Songs model)
        {
            await context.Songs.AddAsync(model);
            var title = await context.SaveChangesAsync();
            return Ok(title);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSong(Songs model)
        {
            var ruset =  await context.FindAsync<Songs>(model.Id);
            if(ruset == null)
            {
                return NotFound();
            }
            ruset.Title = model.Title;
            ruset.Artist = model.Artist;
            ruset.Album = model.Album;
            ruset.Genre = model.Genre;
            ruset.Duration = model.Duration;
            ruset.CoverPath = model.CoverPath;
            ruset.FilePath = model.FilePath;

            await context.SaveChangesAsync();
            return NoContent();
            
        }
        

    } 
}
