using System.Collections.Generic;

namespace Phase5
{
    public class InvertedIndex : IInvertedIndex
    {
        private Dictionary<string, HashSet<string>> _wordsMap;

        public InvertedIndex()
        {
            //_wordsMap = new Dictionary<string, HashSet<string>>();
        }

        public void Setup(Dictionary<string, HashSet<string>> wordsMap)
        {
            _wordsMap = wordsMap;
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            return _wordsMap.GetValueOrDefault(word, new HashSet<string>());
        }
    }
}