using System.Collections.Generic;
using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    public interface IPostRepository
    {
        PostModel GetPost(int id);
        List<PostModel> GetPost(string title);
        void AddPost(PostModel post);
        void UpdatePost(PostModel post);
        void DeletePost(int id);
    }
}