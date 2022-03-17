
using System.ComponentModel.DataAnnotations;

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
    }
}