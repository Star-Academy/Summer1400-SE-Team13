using System.Collections.Generic;

namespace Search.Interface
{
    public interface ITokenizer
    {
        IEnumerable<string> Tokenize(string doc);
    }
}