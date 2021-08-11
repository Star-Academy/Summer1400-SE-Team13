using System.Collections.Generic;

namespace Phase5
{
    public interface IInvertedIndex
    { 
        void Setup(Dictionary<string, HashSet<string>> wordsMap); 
        HashSet<string> GetWordDocs(string word);
    }
}