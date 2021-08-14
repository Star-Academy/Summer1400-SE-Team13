using System.Collections.Generic;
using NSubstitute;
using Search;
using Search.Interface;
using Xunit;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly IFilterApplier _filterApplier;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFullTextSearch _fullTextSearch;

        public FullTextSearchTest()
        {
            var invertedIndex = Substitute.For<IInvertedIndex>();
            var tokenizer = Substitute.For<ITokenizer>();
            _queryProcessor = Substitute.For<IQueryProcessor>();
            var docsFileReader = Substitute.For<IDocsFileReader>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(invertedIndex, docsFileReader,tokenizer, _queryProcessor, _filterApplier);
        }

        [Fact]
        public void TestSearchQueryWithOneNoSignWord()
        {
            SetupMockedFilterApplier();
            const string query = "hello";
            _queryProcessor.MinusCommandWords.Returns(new HashSet<string>());
            _queryProcessor.PlusCommandWords.Returns(new HashSet<string>());
            _queryProcessor.NoSignCommandWords.Returns(new HashSet<string>(){"hello"});
            var expectedResult = new HashSet<string>() {"File1", "File2"};
            var actualResult = _fullTextSearch.FindCommandResult(query);
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void TestSearchQueryWithNoSignPlusMinusWords()
        {
            SetupMockedFilterApplier();
            const string query = "hello +java -sample";
            _queryProcessor.MinusCommandWords.Returns(new HashSet<string>(){"sample"});
            _queryProcessor.PlusCommandWords.Returns(new HashSet<string>(){"java"});
            _queryProcessor.NoSignCommandWords.Returns(new HashSet<string>(){"hello"});
            var expectedResult = new HashSet<string>() {"File1"};
            var actualResult = _fullTextSearch.FindCommandResult(query);
            Assert.Equal(expectedResult, actualResult);
        }
        
        [Fact]
        public void TestSearchQueryWithNoSignAndMinusWords()
        {
            SetupMockedFilterApplier();
            const string query = "-hello java";
            _queryProcessor.MinusCommandWords.Returns(new HashSet<string>(){"hello"});
            _queryProcessor.PlusCommandWords.Returns(new HashSet<string>());
            _queryProcessor.NoSignCommandWords.Returns(new HashSet<string>(){"java"});
            var expectedResult = new HashSet<string>() {"File3"};
            var actualResult = _fullTextSearch.FindCommandResult(query);
            Assert.Equal(expectedResult, actualResult);
        }
        
        private void SetupMockedFilterApplier()
        {
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File1"});
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File1", "File2"});
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File3"});
        }
    }
}