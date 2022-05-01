
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.src.Repositories
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a theme to register</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class ThemeRegisterDTO
    {
        [Required, StringLength(30)]
        public string Description { get; set; }

        public ThemeRegisterDTO(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a theme to update</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class ThemeUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Description { get; set; }

        public ThemeUpdateDTO(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}