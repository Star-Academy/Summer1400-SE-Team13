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
                AddWord(word);
                AddDocId(word, docId);
            }
        }

        private void AddWord(string word)
        {
            if (!_wordsMap.ContainsKey(word))
                _wordsMap.Add(word, new HashSet<string>());
        }

        private void AddDocId(string word, string id)
        {
            _wordsMap[word].Add(id);
        }
        public HashSet<string> GetWordDocs(string word)
        {
            return _wordsMap.GetValueOrDefault(word);
        }

        public Dictionary<string, HashSet<string>> GetWordsMap()
        {
            return _wordsMap;
        }
    }
}