using System.Collections.Generic;

namespace Search
{
    public interface ITokenizer
    {
        HashSet<string> Tokenize(string doc);
    }
}