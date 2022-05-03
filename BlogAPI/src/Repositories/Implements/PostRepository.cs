
using System.Collections.Generic;
using System.Linq;
using BlogAPI.src.Data;
using BlogAPI.src.DTOs;
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
        /// <para>Resume: method for get all posts.</para>
        /// </summary>
        /// <returns>List of PostModel</returns>
        public List<PostModel> GetAllPosts()
        {
            return _context.Posts
                        .Include(p => p.RelatedTheme)
                        .Include(p => p.Creator)
                        .ToList();
        }

        /// <summary>
        /// <para>Resume: method for get post by id.</para>
        /// </summary>
        /// <param name="id">Id of post</param>
        /// <returns>PostModel</returns>
        public PostModel GetPostById(int id)
        {
            return _context.Posts
                        .Include(p => p.RelatedTheme)
                        .Include(p => p.Creator)
                        .FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// <para>Resume: Query method for get posts by title or description theme and name creator</para>
        /// </summary>
        /// <param name="title">Title of post</param>
        /// <param name="descriptionTheme">Theme of post</param>
        /// <param name="nameCreator">Creator of post</param>
        /// <returns>List of PostModel</returns>
        public List<PostModel> GetPostsBySearch(string title, string descriptionTheme, string nameCreator)
        {
            switch (title, descriptionTheme, nameCreator)
            {
                case (null, null, null):
                    return GetAllPosts();

                case (null, null, _):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Creator.Name.Contains(nameCreator))
                            .ToList();

                case (null, _, null):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Description.Contains(descriptionTheme))
                            .ToList();

                case (_, null, null):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Title.Contains(title))
                            .ToList();

                case (_, _, null):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Title.Contains(title) & p.Description.Contains(descriptionTheme))
                            .ToList();

                case (null, _, _):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Description.Contains(descriptionTheme) & p.Creator.Name.Contains(nameCreator))
                            .ToList();

                case (_, null, _):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Title.Contains(title) & p.Creator.Name.Contains(nameCreator))
                            .ToList();

                case (_, _, _):
                    return _context.Posts
                            .Include(p => p.RelatedTheme)
                            .Include(p => p.Creator)
                            .Where(p => p.Title.Contains(title) | p.Description.Contains(descriptionTheme) | p.Creator.Name.Contains(nameCreator))
                            .ToList();
            }
        }

        /// <summary>
        /// <para>Resume: method for add new post.</para>
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>PostModel</returns>
        public PostModel AddPost(PostRegisterDTO post)
        {
            var existentTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescriptionTheme);
            var existentUser = _context.Users.FirstOrDefault(u => u.Email == post.EmailCreator);

            if (existentTheme == null)
            {
                _context.Themes.Add(new ThemeModel
                {
                    Description = post.DescriptionTheme
                });
                _context.SaveChanges();
            }

            if (existentUser == null) return null;

            var newPost = _context.Posts.Add(new PostModel
            {
                Title = post.Title,
                Description = post.Description,
                Photo = post.Photo,
                RelatedTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescriptionTheme),
                Creator = existentUser
            }).Entity;
            _context.SaveChanges();
            return newPost;
        }

        /// <summary>
        /// <para>Resume: method for update existent post.</para>
        /// </summary>
        /// <param name="post">PostUpdateDTO</param>
        /// <returns>PostModel</returns>
        public PostModel UpdatePost(PostUpdateDTO post)
        {
            var existentTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescritionTheme);
            var postToUpdate = GetPostById(post.Id);

            if (existentTheme == null)
            {
                _context.Themes.Add(new ThemeModel
                {
                    Description = post.DescritionTheme
                });
                _context.SaveChanges();
            }

            if (postToUpdate == null) return null;

            postToUpdate.Title = post.Title;
            postToUpdate.Description = post.Description;
            postToUpdate.Photo = post.Photo;
            postToUpdate.RelatedTheme = _context.Themes.FirstOrDefault(t => t.Description == post.DescritionTheme);

            _context.Posts.Update(postToUpdate);
            _context.SaveChanges();
            return postToUpdate;
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

        #endregion IPostRepository implementation
    }
}