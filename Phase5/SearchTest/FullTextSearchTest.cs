using System.Collections.Generic;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly IDocsFileReader _docsFileReader;
        private readonly IFilterApplier _filterApplier;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFullTextSearch _fullTextSearch;

        public FullTextSearchTest()
        {
            var invertedIndex = Substitute.For<IInvertedIndex>();
            var tokenizer = Substitute.For<ITokenizer>();
            _queryProcessor = Substitute.For<IQueryProcessor>();
            _docsFileReader = Substitute.For<IDocsFileReader>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(invertedIndex, _docsFileReader,tokenizer, _queryProcessor, _filterApplier);
        }

        [Fact]
        public void TestSearchQueryWithOneNoSignWord()
        {
            SetupInterfaces();
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
            SetupInterfaces();
            var query = "hello +java -sample";
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
            SetupInterfaces();
            var query = "-hello java";
            _queryProcessor.MinusCommandWords.Returns(new HashSet<string>(){"hello"});
            _queryProcessor.PlusCommandWords.Returns(new HashSet<string>());
            _queryProcessor.NoSignCommandWords.Returns(new HashSet<string>(){"java"});
            var expectedResult = new HashSet<string>() {"File3"};
            var actualResult = _fullTextSearch.FindCommandResult(query);
            Assert.Equal(expectedResult, actualResult);
        }
        
        private void SetupInterfaces()
        {
            SetupDocsFileReader();
            SetupFilterApplier();
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
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File1"});
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File1", "File2"});
            _filterApplier.Filter(Arg.Is<HashSet<string>>(x => x.Count == 0),Arg.Is<HashSet<string>>(x => x.Count == 1),Arg.Is<HashSet<string>>(x => x.Count == 1)).Returns(new HashSet<string>(){"File3"});
        }
    }
}