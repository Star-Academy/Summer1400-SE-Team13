using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Search
{
    public class InvertedIndex : IInvertedIndex
    {
        private readonly Dictionary<string, HashSet<string>> _wordsMap;
        //private readonly DbContext _context;

        public InvertedIndex(DbContext context)
        {
            _wordsMap = new Dictionary<string, HashSet<string>>();
            //_context = context;
        }

        public void AddDoc(HashSet<string> docWords, string docId)
        {
            using var _context = new SearchContext();
            _context.Docs.Add(new Doc(){
                        Name = docId
                    });

            foreach (string wordStr in docWords)
            {
                if (_context.Words.Include(w => w.Content == wordStr) == null)
                    //_wordsMap.Add(word, new HashSet<string>());
                    _context.Words.Add(new Word(){
                        Content = wordStr
                    });
                //_wordsMap[word].Add(docId);
                var doc = _context.Docs.Single(d => d.Name == docId);
                var word = _context.Words.Single(w => w.Content == wordStr);
                var docToWord = new DocToWord()
                {
                    Doc = doc,
                    Word = word
                };
                _context.RelationTable.Add(docToWord);
            }
            _context.SaveChanges();
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            using var _context = new SearchContext();
            var existingWord = _context.Words.Include(w => w.Docs).FirstOrDefault(w => w.Content == word);
            if (existingWord == null)
            {
                return new HashSet<string>{};
            }
            return existingWord.Docs.Select(d => d.Name).ToHashSet();
            // return _wordsMap.GetValueOrDefault(word, new HashSet<string>());
        }
    }
}