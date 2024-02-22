using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicMin.Data;
using MusicMin.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicMin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly MusicMinDbContext ktton;

        public AlbumController(MusicMinDbContext ktton)
        {
            this.ktton = ktton;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAll()
        {
            var list = ktton.Album.ToList();
            if(list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{Artist}")]
        public async Task<ActionResult<IEnumerable<Album>>> SeletArtist(string Artist)
        {
            var list = ktton.Album.Where(a => a.Artist == Artist);
            if(list!= null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{Title}")]
        public async Task<ActionResult<IEnumerable<Album>>> SeletTitle(string Title)
        {
            var list = ktton.Album.Where(a=>a.Title == Title);
            if( list!= null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{Genre}")]
        public async Task<ActionResult<IEnumerable<Album>>> SeletGenre(string Genre)
        {
            var list = ktton.Album.Where(a => a.Genre == Genre);
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Title}")]
        public async Task<ActionResult<IEnumerable<Album>>> Delete(string Title)
        {
            var ming = ktton.Album.FirstOrDefault(a => a.Title == Title);
            if (ming != null)
            {
                ktton.Album.Remove(ming);
                await  ktton.SaveChangesAsync();
                return Ok("删除成功");
            }
            else
            {
                return BadRequest("删除失败");
            }
        }

        [HttpPost]
        //插入
        public async Task<ActionResult<IEnumerable<Album>>> InstaInfo( Album model)
        {
            await ktton.Album.AddAsync(model);
            var list = await ktton.SaveChangesAsync();
            return Ok(list);        
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Album>>> UpdateInfo(Album model)
        {
            var list = await ktton.Album.FindAsync(model.Id);
            if(list == null)
            {
                return BadRequest();
            }
            list.CoverPath = model.CoverPath;
            list.Title = model.Title;
            list.Artist = model.Artist;
            list.Genre = model.Genre;
            list.ReleaseDate = model.ReleaseDate;

            await ktton.SaveChangesAsync();
            return Ok(list);
        }
       
        
    }
}
