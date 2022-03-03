using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("ThemeId")]
        public ThemeModel Theme { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}