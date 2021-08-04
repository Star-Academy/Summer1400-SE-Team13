using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Phase5
{
    public class Tokenizer : ITokenizer
    {
        public HashSet<string> Tokenize(string doc)
        {
            var ans = new HashSet<string>();
            var regex = new Regex("[a-zA-Z]+");
            var matches = regex.Matches(doc);
            foreach (Match match in matches)
            {
                var word = match.Value;
                if (word.Length > 1)
                    ans.Add(word.ToLower());
            }
            return ans;
        }
    }
}