using System.Collections.Generic;
using Search;
using Search.Model;
using Xunit;
using NSubstitute;
using Search.Interface;

namespace SearchTest
{
    public class GetWordDocsTest
    {
        private readonly ITokenizer _tokenizer;
        private IInvertedIndex _invertedIndex;

        public GetWordDocsTest()
        {
            _tokenizer = Substitute.For<ITokenizer>();
        }
        
        [Fact]
        public void BuildInvertedIndexTest()
        {
            SetupMockedTokenizer();
            using var context = new SearchContext();
            _invertedIndex = new InvertedIndex(context);
            _invertedIndex.BuildInvertedIndex(SetupDocs(), _tokenizer);
            var expected = new HashSet<string>() {"File1"};
            Assert.Equal(expected, _invertedIndex.GetWordDocs("microsoft"));
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