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

        public void BuildInvertedIndex(IDictionary<string, string> docsSet, ITokenizer tokenizer)
        {
            foreach (var (docName, docContent) in docsSet)
            {
                var docWords = tokenizer.Tokenize(docContent);
                var doc = new Doc()
                {
                    Name = docName,
                    Content = docContent
                };
                AddWordsDocs(doc, docWords);
            }
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            var existingWord = _searchContext.Words.Include(w => w.Docs).SingleOrDefault(w => w.Content == word);
            var wordDocs = existingWord == null ? new HashSet<string>() : existingWord.Docs.Select(d => d.Name).ToHashSet();
            return wordDocs;
        }
        
        private void AddWordsDocs(Doc doc, IEnumerable<string> docWords)
        {
            foreach (var wordIter in docWords)
            {
                var word = GetWord(wordIter);
                if (word == null)
                {
                    AddNewWord(wordIter, doc);
                }
                else
                {
                    word.Docs.Add(doc);
                }
            }
        }

        private Word GetWord(string wordContent)
        {
            var word = _searchContext.Words.SingleOrDefault(w => w.Content == wordContent);
            return word;
        }
        
        private void AddNewWord(string word, Doc doc)
        {
            _searchContext.Words.Add(new Word()
            {
                Content = word,
                Docs = new List<Doc> {doc}
            });
            _searchContext.SaveChanges();
        }
    }
}