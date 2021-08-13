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

        public void BuildInvertedIndex(Dictionary<string, string> docsMap, ITokenizer tokenizer)
        {
            foreach (var (docId, docContent) in docsMap)
            {
                var docWords = tokenizer.Tokenize(docContent);
                AddDoc(docWords, docId);
            }
        }
        public HashSet<string> GetWordDocs(string word)
        {
            return _wordsMap.GetValueOrDefault(word, new HashSet<string>());
        }
        private void AddDoc(HashSet<string> docWords, string docId)
        {
            foreach (var word in docWords)
            {
                if (!_wordsMap.ContainsKey(word))
                    _wordsMap.Add(word, new HashSet<string>());
                _wordsMap[word].Add(docId);
            }
        }
        
    }
}