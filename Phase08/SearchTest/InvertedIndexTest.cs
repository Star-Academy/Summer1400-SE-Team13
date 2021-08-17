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
        
        private Dictionary<string, string> SetupDocs()
        {
            var docs = new Dictionary<string, string>
            {
                {"File1", "Microsoft have just announced collaborative coding via Live Share."},
                {"File2", "Hello World!"},
                {"File3", "Hello, Xunit is a free and open-source unit testing tool."}
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