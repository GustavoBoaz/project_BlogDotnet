
using System.Collections.Generic;
using System.Linq;
using BlogAPI.src.Data;
using BlogAPI.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.src.Repositories.Implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Post.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class PostRepository : IPostRepository
    {
        #region Attributes

        private readonly AppBlogContext _context;

        #endregion Attributes

        #region Constructors

        public PostRepository(AppBlogContext context)
        {
            _context = context;
        }

        #endregion Constructors

        #region IPostRepository implementation

        /// <summary>
        /// <para>Resume: method for get post by id.</para>
        /// </summary>
        /// <param name="id">Id of post</param>
        /// <returns>PostModel</returns>
        public PostModel GetPostById(int id)
        {
            return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.User)
                        .FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// <para>Resume: method for get all posts.</para>
        /// </summary>
        /// <returns>List of PostModel</returns>
        public List<PostModel> GetAllPosts()
        {
            return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.User)
                        .ToList();
        }

        /// <summary>
        /// <para>Resume: method for get posts by title.</para>
        /// </summary>
        /// <param name="title">Title of post</param>
        /// <returns>List of PostModel</returns>
        public List<PostModel> GetPostByTitle(string title)
        {
            return _context.Posts
                        .Include(p => p.Theme)
                        .Include(p => p.User)
                        .Where(p => p.Title.Contains(title))
                        .ToList();
        }

        /// <summary>
        /// <para>Resume: method for add new post.</para>
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>PostModel</returns>
        public PostModel AddPost(PostRegisterDTO post)
        {
            var existentTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescritionTheme);
            var existentUser = _context.Users.FirstOrDefault(u => u.Email == post.EmailUser);

            if (existentTheme == null || existentUser == null) return null;

            var newPost = _context.Posts.Add(new PostModel
            {
                Title = post.Title,
                Description = post.Description,
                Theme = existentTheme,
                User = existentUser
            }).Entity;
            _context.SaveChanges();
            return newPost;
        }

        /// <summary>
        /// <para>Resume: method for delete existent post.</para>
        /// </summary>
        /// <param name="id">Id of post</param>
        public void DeletePost(int id)
        {
            _context.Posts.Remove(GetPostById(id));
            _context.SaveChanges();
        }

        /// <summary>
        /// <para>Resume: method for update existent post.</para>
        /// </summary>
        /// <param name="post">PostUpdateDTO</param>
        /// <param name="id">Id of post</param>
        /// <returns>PostModel</returns>
        public PostModel UpdatePost(int id, PostRegisterDTO post)
        {
            var existentTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescritionTheme);
            var existentUser = _context.Users.FirstOrDefault(u => u.Email == post.EmailUser);
            var postToUpdate = GetPostById(id);

            if (existentTheme == null || existentUser == null || postToUpdate == null) return null;

            postToUpdate.Title = post.Title;
            postToUpdate.Description = post.Description;
            postToUpdate.Theme = existentTheme;
            postToUpdate.User = existentUser;
            
            _context.Posts.Update(postToUpdate);
            _context.SaveChanges();
            return postToUpdate;
        }

        #endregion IPostRepository implementation
    }
}