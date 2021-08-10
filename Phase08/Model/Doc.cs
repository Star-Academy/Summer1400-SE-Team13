using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Doc
    {
        [Key]
        public string Id {set; get;}
        public string Name {set; get;}
        //public string Content {set; get;}
        public List<Word> Words {set; get;}
    }
}