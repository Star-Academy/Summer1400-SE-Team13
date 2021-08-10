using System.Collections.Generic;

namespace Search
{
    public interface IInvertedIndex
    { 
        void AddDoc(HashSet<string> docWords, string docId); 
        HashSet<string> GetWordDocs(string word);
    }
}