using System.Collections.Generic;
using Search.Model;

namespace Search.Interface
{
    public interface IInvertedIndex
    {
        public void BuildInvertedIndex(HashSet<Doc> docs, ITokenizer tokenizer);
        HashSet<string> GetWordDocs(string word);
    }
}