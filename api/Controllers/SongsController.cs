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
        public async Task<IActionResult> Get(string theloai)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (string.IsNullOrEmpty(theloai))
                {
                    var songs = await this.songData.GetAll();
                    return Ok(songs);
                }
                else
                {
                    var songs = await this.songData.GetByCategory(theloai);
                    return Ok(songs);
                }
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

        [HttpGet("tai-nhieu-nhat")]
        public async Task<IActionResult> GetTopDownload()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var songs = await this.songData.GetTopDownLoad();
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("de-cu")]
        public async Task<IActionResult> GetTopRate()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var songs = await this.songData.GetTopRate();
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("binh-luan-moi")]
        public async Task<IActionResult> GetNewComment()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var songs = await this.songData.GetNewComment();
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("tim-kiem")]
        public async Task<IActionResult> Search(string casi, string nhacsi, string ten)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Dictionary<string,IEnumerable<Song>> result = new Dictionary<string, IEnumerable<Song>>();
                if (!String.IsNullOrEmpty(casi))
                {
                    var songs = await this.songData.GetBySinger(casi);
                    result.Add("singer",songs);
                }
                if (!String.IsNullOrEmpty(nhacsi))
                {
                    var songs = await this.songData.GetByComposer(nhacsi);
                    result.Add("composer",songs);
                }
                if (!String.IsNullOrEmpty(ten))
                {
                    var songs = await this.songData.GetByName(ten);
                    result.Add("name",songs);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}