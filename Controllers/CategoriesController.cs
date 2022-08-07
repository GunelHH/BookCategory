using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTaskBookCategory.DAL;
using HomeTaskBookCategory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskBookCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext context;

        public CategoriesController(ApiDbContext context)
        {
            this.context = context;
        }

        //[HttpGet("get/{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id == 0) return NotFound();
        //    Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        //    if (category is null) return BadRequest();

        //}
    }
}