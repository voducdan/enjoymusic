using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enjoymusic_project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace enjoymusic_project.Controllers
{
    [Route("api/the-loai")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryData categoryData;

        public CategoriesController(ICategoryData categoryData)
        {
            this.categoryData = categoryData;
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
                var categories = await this.categoryData.GetAll();
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}