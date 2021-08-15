using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Search;
using Search.Model;
using Xunit;
using NSubstitute;
using Search.Interface;

namespace SearchTest
{
    public class InvertedIndexTest
    {
        private readonly ITokenizer _tokenizer;
        private readonly IInvertedIndex _invertedIndex;

        public InvertedIndexTest()
        {
            var contextOptions = new DbContextOptionsBuilder<SearchContext>()
                .UseInMemoryDatabase("Test")
                .Options;
            var searchContext = new SearchContext(contextOptions);
            searchContext.Database.EnsureDeleted();
            searchContext.Database.EnsureCreated();
            _invertedIndex = new InvertedIndex(searchContext);
            _tokenizer = Substitute.For<ITokenizer>();
        }
        
        [Theory]
        [InlineData("microsoft", new [] {"File1"})]
        [InlineData("word", new string[]{})]
        public void TestGetWordDocs_ForExistingAndNotExistingWord(string testWord, string[] expected)
        {
            SetupMockedTokenizer();
            _invertedIndex.BuildInvertedIndex(SetupDocs(), _tokenizer);
            Assert.Equal(expected, _invertedIndex.GetWordDocs(testWord));
        }
        private HashSet<Doc> SetupDocs()
        {
            var docs = new HashSet<Doc>()
            {
                new()
                {
                    Name = "File1", Content = "Microsoft have just announced collaborative coding via Live Share."
                },
                new()
                {
                    Name = "File2", Content = "Hello World!"
                },
                new()
                {
                    Name = "File3", Content = "Hello, Xunit is a free and open-source unit testing tool."
                }
            };
            return docs;
        }

        private void SetupMockedTokenizer()
        {
            _tokenizer.Tokenize("Microsoft have just announced collaborative coding via Live Share.")
                .Returns(new HashSet<string>(){"microsoft", "have", "just", "announced", "collaborative", "coding", "via", "live", "share"});
            _tokenizer.Tokenize("Hello World!").Returns(new HashSet<string>(){"hello", "world"});
            _tokenizer.Tokenize("Hello, Xunit is a free and open-source unit testing tool.")
                .Returns(new HashSet<string>(){"hello", "xunit", "is", "free", "and", "open", "source", "unit", "testing", "tool"});
        }
    }
}