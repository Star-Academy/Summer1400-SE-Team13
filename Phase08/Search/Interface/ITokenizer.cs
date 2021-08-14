using System.Collections.Generic;

namespace Search.Interface
{
    public interface ITokenizer
    {
        HashSet<string> Tokenize(string doc);
    }
}