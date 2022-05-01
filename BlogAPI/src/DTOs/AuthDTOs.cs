
using System.ComponentModel.DataAnnotations;
using BlogAPI.src.Utils;

namespace BlogAPI.src.DTOs
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting login information</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-17</para>
    /// </summary>
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserLoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting the Authorization data</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-17</para>
    /// </summary>
    public class AuthorizationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
        public string Token { get; set; }

        public AuthorizationDTO(int id, string name, string email, RoleType role, string token)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Token = token;
        }
    }
}