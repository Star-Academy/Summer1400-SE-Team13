using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Search
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, HashSet<string>> _wordsMap;
        private readonly DbContext _context;

        public InvertedIndex(DbContext context)
        {
            _wordsMap = new Dictionary<string, HashSet<string>>();
            _context = context;
        }

        public void AddDoc(HashSet<string> docWords, string docId)
        {
            _context.Docs.Add(new Doc(){
                        Name = docId
                    });

            foreach (var word in docWords)
            {
                if (_context.Words.GetValueOrDefault(word) == null)
                    //_wordsMap.Add(word, new HashSet<string>());
                    _context.Words.Add(new Word(){
                        Content = word;
                    });
                //_wordsMap[word].Add(docId);
                var doc = _context.Docs.Single(d => d.name == docId);
                var word = _contect.Words.Single(w => w.Content == word);
                var docToWord = new DocToWord(){
                    Doc = doc;
                    Word = word;
                }
                _context.DocToWord.Add(docToWord);
            }
            _context.SaveChanges();
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            var existingWord = _context.Words.Include(w => w.Docs).FirstOrDefault(w => w.Content == word);
            if (existingWord == null)
            {
                return new HashSet<string>;
            }
            return existingWord.Docs;
            // return _wordsMap.GetValueOrDefault(word, new HashSet<string>());
        }
    }
}