
using System.Collections.Generic;

namespace Phase5.Interface
{
    public interface ITokenizer
    {
        HashSet<string> Tokenize(string doc);
    }
}