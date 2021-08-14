using System.Collections.Generic;

namespace Phase5.Interface
{
    public interface IInvertedIndex
    {
        void BuildInvertedIndex(Dictionary<string, string> docsMap, ITokenizer tokenizer);
        HashSet<string> GetWordDocs(string word);
    }
}