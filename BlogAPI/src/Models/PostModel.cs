using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.src.Models
{
    /// <summary>
    /// <para>Resume: Class responsible for representing a posts in the database.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    [Table("tb_posts")]
    public class PostModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Title { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [ForeignKey("FK_Theme")]
        public ThemeModel RelatedTheme { get; set; }

        [ForeignKey("FK_User")]
        public UserModel Creator { get; set; }
    }
}