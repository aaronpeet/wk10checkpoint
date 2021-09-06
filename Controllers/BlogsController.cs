using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wk10checkpoint.Models;
using wk10checkpoint.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace wk10checkpoint.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _blogsService;
        public BlogsController(BlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        [HttpGet]
        public ActionResult<List<Blog>> Get()
        {
            try
            {
                List<Blog> blogs = _blogsService.Get();
                return Ok(blogs);
    }
            catch (Exception error)
            {
                
               return BadRequest(error.Message);
    }
        }

    }
}