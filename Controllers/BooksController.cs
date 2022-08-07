using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeTaskBookCategory.DAL;
using HomeTaskBookCategory.DTOs.Book;
using HomeTaskBookCategory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskBookCategory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApiDbContext context;
        private readonly IMapper mapper;

        public BooksController(ApiDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return NotFound();
            Book book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book is null) return BadRequest();
            BookGetDto dto = mapper.Map<BookGetDto>(book);
            return Ok(dto);
        }

        //public async Task<IActionResult>GetAll(int page = 1,string search=null)
        //{
        //    var query = context.Books.AsQueryable();

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        query = query.Where(b => b.Name == search);
        //    }

        //}
    }
}