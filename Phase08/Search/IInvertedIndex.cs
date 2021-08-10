using System.Collections.Generic;

namespace Phase5
{
    public interface IInvertedIndex
    { 
        void AddDoc(HashSet<string> docWords, string docId); 
        HashSet<string> GetWordDocs(string word);
    }
}