using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Search.Interface;


namespace Search
{
    public class Tokenizer : ITokenizer
    {
        public IEnumerable<string> Tokenize(string doc)
        {
            var wordsDoc = Regex.Split(doc.ToLower(),"[\\W]+").Where(x => x.Length > 1).ToHashSet();
            return wordsDoc;
        }
    }
}