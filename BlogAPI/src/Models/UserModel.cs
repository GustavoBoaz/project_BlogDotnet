using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlogAPI.src.Utils;

namespace BlogAPI.src.Models
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }

        [Required, StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [Required]
        public RoleType Role { get; set; }

        [JsonIgnore]
        public List<PostModel> MyPosts { get; set; }
    }
}