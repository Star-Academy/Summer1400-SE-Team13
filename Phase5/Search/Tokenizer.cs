using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Phase5
{
    public class Tokenizer : ITokenizer
    {
        public HashSet<string> Tokenize(string doc)
        {
            doc = doc.ToLower();
            var wordsDoc = Regex.Split(doc,"[\\W]+").Where(x => x.Length > 1).ToHashSet();
            return wordsDoc;
        }
    }
}