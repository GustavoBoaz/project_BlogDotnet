using System.Collections.Generic;
using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions posts.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public interface IPostRepository
    {
        PostModel GetPostById(int id);
        List<PostModel> GetPostByTitle(string title);
        void AddPost(PostRegisterDTO post);
        void UpdatePost(int id, PostUpdateDTO post);
        void DeletePost(int id);
    }
}