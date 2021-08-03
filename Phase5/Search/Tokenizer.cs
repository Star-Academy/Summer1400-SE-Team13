using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Phase5
{
    public class Tokenizer
    {
        public HashSet<string> Tokenize(string doc)
        {
            var ans = new HashSet<string>();
            Regex rx = new Regex("[a-zA-Z]+");
            var matches = rx.Matches(doc);
            foreach (Match match in matches)
            {
                string word = match.Value;
                if (word.Length > 1)
                    ans.Add(word.ToLower());
            }
            return ans;
        }
    }
}