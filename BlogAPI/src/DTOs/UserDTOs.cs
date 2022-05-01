using System.ComponentModel.DataAnnotations;
using BlogAPI.src.Utils;

namespace BlogAPI.src.DTOs
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a user to register</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserRegisterDTO
    {
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

        public UserRegisterDTO(string name, string email, string password, string photo, RoleType role)
        {
            Name = name;
            Email = email;
            Password = password;
            Photo = photo;
            Role = role;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a user to update</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserUpdateDTO
    {
        [Required]
         public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [Required]
        public RoleType Role { get; set; }

        public UserUpdateDTO(int id, string name, string password, string photo, RoleType role)
        {
            Id = id;
            Name = name;
            Password = password;
            Photo = photo;
            Role = role;
        }
    }
}