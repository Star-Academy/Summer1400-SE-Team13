using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Search;
using Search.Model;
using Xunit;
using NSubstitute;
using NSubstitute.ClearExtensions;


namespace SearchTest
{
    public class GetWordDocsTest
    {
        private HashSet<Doc> _docs;
        private ITokenizer _tokenizer;
        private InvertedIndex _invertedIndex;

        public GetWordDocsTest()
        {
            _docs = new HashSet<Doc>();
            _tokenizer = Substitute.For<ITokenizer>();
        }
        HashSet<Doc> SetupDocs()
        {
            _docs.Add(new Doc()
            {
                Name = "File1.txt",
                Content = "Microsoft have just announced collaborative coding via Live Share."
            });
            _docs.Add(new Doc()
            {
                Name = "File2.txt",
                Content = "Hello World!"
            });
            _docs.Add(new Doc()
            {
                Name = "File3.txt",
                Content = "Hello, Xunit is a free and open-source unit testing tool."
            });
            return _docs;
        }

        private void SetupMockedTokenizer()
        {
            _tokenizer.Tokenize("Microsoft have just announced collaborative coding via Live Share.")
                .Returns(new HashSet<string>(){"microsoft", "have", "just", "announced", "collaborative", "coding", "via", "live", "share"});
            _tokenizer.Tokenize("Hello World!").Returns(new HashSet<string>(){"hello", "world"});
            _tokenizer.Tokenize("Hello, Xunit is a free and open-source unit testing tool.")
                .Returns(new HashSet<string>(){"hello", "xunit", "is", "free", "and", "open", "source", "unit", "testing", "tool"});
        }
        
        [Fact]
        public void BuildInvertedIndexTest()
        {
            SetupDocs();
            SetupMockedTokenizer();
            using var context = new SearchContext();
            _invertedIndex = new InvertedIndex(context);
            HashSet<string> expected = new HashSet<string>() { "File1" };
            Assert.Equal(_invertedIndex.GetWordDocs("microsoft"), expected);
        }
    }
}