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

        [HttpGet("{id}")]

        public ActionResult<Blog> Get(int id)
        {
            try
            {
                Blog blog = _blogsService.Get(id);
                return Ok(blog);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newBlog.CreatorId = userInfo.Id;
                Blog blog = _blogsService.Create(newBlog);
                return Ok(blog);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Blog> Edit([FromBody] Blog updatedBlog, int id)
        {
            try
            {
                updatedBlog.Id = id;
                Blog blog = _blogsService.Edit(updatedBlog);
                return Ok(blog);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _blogsService.Delete(id, userInfo.Id);
                return Ok("Successfully Delorted");
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

    }
}