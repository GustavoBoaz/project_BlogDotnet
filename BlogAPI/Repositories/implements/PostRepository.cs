
using System.Collections.Generic;
using System.Linq;
using BlogAPI.Data;
using BlogAPI.Models;

namespace BlogAPI.Repositories.Implements
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
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// <para>Resume: method for get posts by title.</para>
        /// </summary>
        /// <param name="title">Title of post</param>
        /// <returns>List of PostModel</returns>
        public List<PostModel> GetPostByTitle(string title)
        {
            return _context.Posts.Where(p => p.Title.Contains(title)).ToList();
        }

        /// <summary>
        /// <para>Resume: method for add new post.</para>
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        public void AddPost(PostRegisterDTO post)
        {
            _context.Posts.Add(new PostModel
            {
                Title = post.Title,
                Description = post.Description
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// <para>Resume: method for update existent post.</para>
        /// </summary>
        /// <param name="post">PostUpdateDTO</param>
        /// <param name="id">Id of post</param>
        public void UpdatePost(int id, PostUpdateDTO post)
        {
            var postToUpdate = GetPostById(id);
            postToUpdate.Title = post.Title;
            postToUpdate.Description = post.Description;
            _context.Posts.Update(postToUpdate);
        }

        /// <summary>
        /// <para>Resume: method for delete existent post.</para>
        /// </summary>
        /// <param name="id">Id of post</param>
        public void DeletePost(int id)
        {
            _context.Posts.Remove(GetPostById(id));
        }
        
        #endregion IPostRepository implementation
    }
}