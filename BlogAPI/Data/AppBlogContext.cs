using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class AppBlogContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ThemeModel> Themes { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-Q1T59DRA;Initial Catalog=db_blog;Trusted_Connection=True;");
        }
    }
}