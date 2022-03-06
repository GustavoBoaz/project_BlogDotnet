using BlogAPI.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.src.Data
{
    /// <summary>
    /// <para>Resume: Class responsible for data base Blog context</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class AppBlogContext : DbContext
    {
        public AppBlogContext(DbContextOptions<AppBlogContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ThemeModel> Themes { get; set; }
        public DbSet<PostModel> Posts { get; set; }
    }
}