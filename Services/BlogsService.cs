using System;
using System.Collections.Generic;
using wk10checkpoint.Models;
using wk10checkpoint.Repositories;

namespace wk10checkpoint.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;
        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        internal List<Blog> Get()
        {
            return _repo.Get();
        }

        internal Blog Get(int id)
        {
            Blog blog = _repo.Get(id);
            if(blog ==null)
            {
                throw new Exception("Invalid ID");
            }
            return blog;
        }

        internal Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }

        internal Blog Edit(Blog updatedBlog)
        {
            Blog original = Get(updatedBlog.Id);
            updatedBlog.Title = updatedBlog.Title != null ? updatedBlog.Title : original.Title;
            updatedBlog.Body = updatedBlog.Body != null ? updatedBlog.Body : original.Body;
            updatedBlog.ImgUrl = updatedBlog.ImgUrl != null ? updatedBlog.ImgUrl : original.ImgUrl;
            updatedBlog.Published = updatedBlog.Published ? updatedBlog.Published : original.Published;
            return _repo.Update(updatedBlog);
        }

        internal void Delete(int blogId, string userId)
        {
            Blog blogDelete = Get(blogId);
            if(blogDelete.CreatorId != userId)
            {
                throw new Exception("You don't have permission to delete");
            }
            _repo.Delete(blogId);
        }

    }
}