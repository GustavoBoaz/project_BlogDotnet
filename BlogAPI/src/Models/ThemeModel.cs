using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.src.Models
{
    /// <summary>
    /// <para>Resume: Class responsible for representing a themes in the database.</para>
    /// <para>Created by: Gustavo Boaz</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-03-05</para>
    /// </summary>
    [Table("tb_themes")]
    public class ThemeModel
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public string Description { get ; set; }

        [JsonIgnore]
        public List<PostModel> Posts { get; set; }
    }
}