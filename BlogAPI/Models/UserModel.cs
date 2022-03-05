using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.Models
{
    /// <summary>
    /// <para>Resume: Class responsible for representing a users in the database.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    [Table("tb_users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(30)]
        public string Name { get; set; }

        [Required][StringLength(30)]
        public string Email { get; set; }

        [Required][StringLength(100)]
        public string Password { get; set; }
        
        [JsonIgnore]
        public List<PostModel> MyPosts { get; set; }
    }
}