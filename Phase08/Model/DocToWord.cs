using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class DocToWord
    {
        [Key]
        public int DocId {get; set;}
        public Doc Doc {get; set;}

        [Key]
        public int WordId {get; set;}
        public Word Word {get; set;}
    }
}