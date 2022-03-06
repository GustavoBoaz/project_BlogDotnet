
using System.Collections.Generic;
using BlogAPI.src.Models;
using BlogAPI.src.DTOs;

namespace BlogAPI.src.Repositories
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
        List<PostModel> GetAllPosts();
        List<PostModel> GetPostByTitle(string title);
        PostModel AddPost(PostRegisterDTO post);
        PostModel UpdatePost(int id, PostRegisterDTO post);
        void DeletePost(int id);
    }
}