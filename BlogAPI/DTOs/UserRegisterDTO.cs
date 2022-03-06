using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DTOs
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a user to register</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class UserRegisterDTO
    {
        [Required][StringLength(30)]
        public string Name { get; set; }

        [Required][StringLength(30)]
        public string Email { get; set; }

        [Required][StringLength(100)]
        public string Password { get; set; }
    }
}