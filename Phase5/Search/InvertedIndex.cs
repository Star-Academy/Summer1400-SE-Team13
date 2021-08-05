using System.Collections.Generic;

namespace Phase5
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, HashSet<string>> _wordsMap;

        public InvertedIndex()
        {
            _wordsMap = new Dictionary<string, HashSet<string>>();
        }

        public void AddDoc(HashSet<string> docWords, string docId)
        {
            foreach (var word in docWords)
            {
                if (!_wordsMap.ContainsKey(word))
                    _wordsMap.Add(word, new HashSet<string>());
                _wordsMap[word].Add(docId);
            }
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            return _wordsMap.GetValueOrDefault(word);
        }
    }
}