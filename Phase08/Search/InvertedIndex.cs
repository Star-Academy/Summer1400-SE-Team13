﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            _searchContext.Database.EnsureDeleted();
            _searchContext.Database.EnsureCreated();
           
            foreach (var doc in docsSet)
            {
                _searchContext.Docs.Add(doc);
                var docWords = tokenizer.Tokenize(doc.Content);
                foreach (var wordIter in docWords)
                {
                    if (!_searchContext.Words.Any(w => w.Content == wordIter))
                    {
                        _searchContext.Words.Add(new Word()
                        {
                            Content = wordIter,
                            Docs = new List<Doc>()
                        });
                    }

                    _searchContext.SaveChanges();
                    var word = _searchContext.Words.Find(wordIter);
                    word.Docs.Add(doc);
                    _searchContext.SaveChanges();
                }
            }
        }
        
        public HashSet<string> GetWordDocs(string word)
        {
            var existingWord = _searchContext.Words.Include(w => w.Docs).FirstOrDefault(w => w.Content == word);
            var wordDocs = existingWord == null ? new HashSet<string>() : existingWord.Docs.Select(d => d.Name).ToHashSet();
            return wordDocs;
        }
    }
}