using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Search.Model
{
    public class Doc
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public List<Word> Words { get; set; }
    }
}