using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Repositories
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a post to register</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class PostRegisterDTO
    {
        [Required][StringLength(30)]
        public string Title { get; set; }
        
        [Required][StringLength(100)]
        public string Description { get; set; }
    }
}