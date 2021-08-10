using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Search.Model
{
    public class Word
    {
        [Key]
        public string Id {get; set;}
        public string Content {get; set;}
        public List<Doc> Docs {get; set;}
    }
}