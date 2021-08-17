using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Search.Interface;
using Search.Model;

namespace Search
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly SearchContext _searchContext;

        public InvertedIndex(SearchContext searchContext)
        {
            _searchContext = searchContext;
        }

        public void BuildInvertedIndex(HashSet<Doc> docsSet, ITokenizer tokenizer)
        {
            foreach (var doc in docsSet)
            {
                var docWords = tokenizer.Tokenize(doc.Content);
                AddWordsDocs(doc, docWords);
            }
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            var existingWord = _searchContext.Words.Include(w => w.Docs).FirstOrDefault(w => w.Content == word);
            var wordDocs = existingWord == null ? new HashSet<string>() : existingWord.Docs.Select(d => d.Name).ToHashSet();
            return wordDocs;
        }
        
        private void AddWordsDocs(Doc doc, IEnumerable<string> docWords)
        {
            foreach (var wordIter in docWords)
            {
                if (!_searchContext.Words.Any(w => w.Content == wordIter))
                {
                   AddNewWord(wordIter);
                }
                var word = _searchContext.Words.Find(wordIter);
                word.Docs.Add(doc);
            }
        }
        
        private void AddNewWord(string word)
        {
            _searchContext.Words.Add(new Word()
            {
                Content = word,
                Docs = new List<Doc>()
            });
            _searchContext.SaveChanges();
        }
    }
}