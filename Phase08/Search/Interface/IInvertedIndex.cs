using System.Collections.Generic;
using Search.Model;

namespace Search.Interface
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(Dictionary<string, string> docsSet, ITokenizer tokenizer);
        HashSet<string> GetWordDocs(string word);
    }
}