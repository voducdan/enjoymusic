using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enjoymusic_project.Data;
using enjoymusic_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace enjoymusic_project.Controllers
{
    [Route("api/bai-hat")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongData songData;

        public SongsController(ISongData songData)
        {
            this.songData = songData;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var songs = await this.songData.GetAll();
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByName(string id)
        {
            try
            {
                var song = this.songData.GetById(id);
                if (song == null)
                {
                    return NotFound();
                }
                return Ok(song);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("nghe-nhieu-nhat")]
        public async Task<IActionResult> GetTopListen()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var songs = await this.songData.GetTopListen();
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}