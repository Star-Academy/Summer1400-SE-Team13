using System.Collections.Generic;

namespace Phase5
{
    public interface IInvertedIndex
    {
        public void AddDoc(HashSet<string> docWords, string docId);
        public HashSet<string> GetWordDocs(string word);
    }
}