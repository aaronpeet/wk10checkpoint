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

    }
}