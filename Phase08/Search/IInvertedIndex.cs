using System.Collections.Generic;
using Search.Model;

namespace Search
{
    public interface IInvertedIndex
    {
        public void BuildInvertedIndex(HashSet<Doc> docs, ITokenizer tokenizer);
        HashSet<string> GetWordDocs(string word);
    }
}