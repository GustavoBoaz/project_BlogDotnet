
using BlogAPI.src.Utils;

namespace BlogAPI.src.DTOs
{
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
    }
}