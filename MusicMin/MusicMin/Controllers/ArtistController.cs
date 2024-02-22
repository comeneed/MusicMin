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
    public class ArtistController : ControllerBase
    {
        private readonly MusicMinDbContext lisa;

        public ArtistController(MusicMinDbContext lisa)
        {
            this.lisa = lisa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAll()
        {
            var list = lisa.Artist.ToList();
            if(list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{ Name}")]
        public async Task<ActionResult<IEnumerable<Artist>>> SelectName(string Name)
        {
            var list = lisa.Artist.Where(a=>a.Name == Name).ToList();
            if(list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Artist>>> UpdateInfo(Artist model)
        {
            var info = await lisa.Artist.FindAsync(model.Id);
            if(info == null)
            {
                return BadRequest();
            }
            info.ImagePath = model.ImagePath;
            info.Name = model.Name;
            await lisa.SaveChangesAsync();
            return Ok(info);
        }
    }

    
}
