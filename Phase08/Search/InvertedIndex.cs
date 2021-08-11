using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Search.Model;

namespace Search
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, HashSet<string>> _wordsMap;
        private readonly SearchContext _searchContext;

        public InvertedIndex(SearchContext searchContext)
        {
            _wordsMap = new Dictionary<string, HashSet<string>>();
            _searchContext = searchContext;
        }

        public void AddDoc(HashSet<string> docWords, string docId)
        {
            _searchContext.Docs.Add(new Doc(){
                Name = docId
            });

            foreach (var wordStr in docWords)
            {
                if (_searchContext.Words.Include(w => w.Content == wordStr) == null)
                    _searchContext.Words.Add(new Word(){
                        Content = wordStr
                    });
                var doc = _searchContext.Docs.Single(d => d.Name == docId);
                var word = _searchContext.Words.Single(w => w.Content == wordStr);
                var docToWord = new DocToWord()
                {
                    Doc = doc,
                    Word = word
                };
                _searchContext.RelationTable.Add(docToWord);
            }
            _searchContext.SaveChanges();
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            var existingWord = _searchContext.Words.Include(w => w.Docs).FirstOrDefault(w => w.Content == word);
            var wordDocs = existingWord == null ? new HashSet<string>() : existingWord.Docs.Select(d => d.Name).ToHashSet();
            return wordDocs;
        }
    }
}