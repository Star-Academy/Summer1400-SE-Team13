
using System.Collections.Generic;

namespace Phase5
{
    public interface ITokenizer
    {
        HashSet<string> Tokenize(string doc);
    }
}