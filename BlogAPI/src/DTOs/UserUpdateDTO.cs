using System.ComponentModel.DataAnnotations;
using BlogAPI.src.Utils;

namespace BlogAPI.src.DTOs
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a user to update</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserUpdateDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public RoleType Role { get; set; }
    }
}