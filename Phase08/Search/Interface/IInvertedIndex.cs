using System.Collections.Generic;

namespace Search.Interface
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(Dictionary<string, string> docsSet, ITokenizer tokenizer);
        HashSet<string> GetWordDocs(string word);
    }
}