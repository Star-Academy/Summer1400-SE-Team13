using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Search.Model;

namespace SearchTest
{
    public static class DbContextFactory
    {
        private static SearchContext _searchContext;
        public static SearchContext CreateContext()
        {
            var contextOptions = new DbContextOptionsBuilder<SearchContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            _searchContext = new SearchContext(contextOptions);
            _searchContext.Database.EnsureDeleted();
            _searchContext.Database.EnsureCreated();
            SetupContext();
            return _searchContext;
        }

        private static void SetupContext()
        {
            var doc1 = new Doc
            {
                Name = "File1", Content = "microsoft have just announced collaborative coding via live share."
            };
            
            var doc2 = new Doc()
            {
                Name = "File2", Content = "Hello World!"
            };
            
            var doc3 = new Doc()
            {
                Name = "File3", Content = "hello, xunit is a free and open-source unit testing tool."
            };

            var word1 = new Word() {Content = "hello", Docs = new List<Doc>() {doc2, doc3}};
            var word2 = new Word() {Content = "microsoft", Docs = new List<Doc>() {doc1}};
            
            _searchContext.Docs.AddRange(doc1, doc2, doc3);
            _searchContext.Words.AddRange(word1, word2);
            _searchContext.SaveChanges();
        }
    }
}