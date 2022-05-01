using System.ComponentModel.DataAnnotations;

namespace BlogAPI.src.Repositories
{
    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a post to register</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class PostRegisterDTO
    {
        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [Required, StringLength(30)]
        public string DescriptionTheme { get; set; }

        [Required, StringLength(30)]
        public string EmailCreator { get; set; }

        public PostRegisterDTO(string title, string description, string photo, string descriptionTheme, string emailCreator)
        {
            Title = title;
            Description = description;
            Photo = photo;
            DescriptionTheme = descriptionTheme;
            EmailCreator = emailCreator;
        }
    }

    /// <summary>
    /// <para>Resume: Mirror class responsible for transporting a post to update</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    public class PostUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [Required, StringLength(30)]
        public string DescritionTheme { get; set; }

        public PostUpdateDTO(int id, string title, string description, string photo, string descritionTheme)
        {
            Id = id;
            Title = title;
            Description = description;
            Photo = photo;
            DescritionTheme = descritionTheme;
        }
    }
}