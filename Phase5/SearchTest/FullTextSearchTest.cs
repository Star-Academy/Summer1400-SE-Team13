using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly IDocsFileReader _docsFileReader;
        private readonly IFilterApplier _filterApplier;
        private readonly IFullTextSearch _fullTextSearch;

        public FullTextSearchTest()
        {
            var invertedIndex = Substitute.For<IInvertedIndex>();
            var tokenizer = Substitute.For<ITokenizer>();
            _docsFileReader = Substitute.For<IDocsFileReader>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(invertedIndex, _docsFileReader,tokenizer, _filterApplier);
        }

        private void SetupDocsFileReader()
        {
            _docsFileReader.ReadContent().Returns(new Dictionary<string, string>
            {
                {"File1","Hello Java."},
                {"File2", "Hello, python"},
                {"File3", "sample Java"}
            });
        }
        
        private void SetupFilterApplier()
        {
            _filterApplier.Filter(Arg.Is<string[]>(x => x.Length == 3)).Returns(new HashSet<string>(){"File1"});
            _filterApplier.Filter(Arg.Is<string[]>(x => x.Length == 1)).Returns(new HashSet<string>(){"File1", "File2"});
            _filterApplier.Filter(Arg.Is<string[]>(x => x.Length == 2)).Returns(new HashSet<string>(){"File1", "File2"});
        }

        private void SetupInterfaces()
        {
            SetupDocsFileReader();
            SetupFilterApplier();
        }

        [Theory]
        [InlineData("hello +java -sample", new [] {"File1"})]
        [InlineData("hello", new [] {"File1", "File2"})]
        [InlineData("+java +python", new [] {"File1", "File2"})]
        public void TestFindCommandResult_WithDifferentEntries(string testCommand, string[] expectedResult)
        {
            SetupInterfaces();
            var actualResult = _fullTextSearch.FindCommandResult(testCommand);
            Assert.Equal(expectedResult, actualResult.ToArray());
        }
    }
}