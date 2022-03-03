using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlogAPI.Models
{
    public class ThemeModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<PostModel> Posts { get; set; }
    }
}