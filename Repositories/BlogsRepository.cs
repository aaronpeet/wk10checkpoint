using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using wk10checkpoint.Models;
using Dapper;

namespace wk10checkpoint.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;
        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Blog> Get()
        {
            string sql = @"
            SELECT
            a.*,
            b.*
            FROM blogs b
            JOIN accounts a ON b.creatorId = a.id
            ";
            return _db.Query<Profile, Blog, Blog>(sql, (profile, blog) =>
            {
                blog.CreatorId = profile;
                return blog;
            }, splitOn: "id").ToList();
        }
        
    }
}