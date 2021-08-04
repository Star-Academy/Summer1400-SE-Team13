using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Phase5;
using Xunit;
using Xunit.Abstractions;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly ITokenizer _tokenizer;
        private readonly IFilterApplier _filterApplier;
        private readonly FullTextSearch _fullTextSearch;

        public FullTextSearchTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _docsFileReader = Substitute.For<IDocsFileReader>();
            _tokenizer = Substitute.For<ITokenizer>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(_invertedIndex, _docsFileReader,_tokenizer, _filterApplier);
        }

        private void SetupInvertedIndex()
        {
            _invertedIndex.GetWordDocs("hello").Returns(new HashSet<string>(){"File1", "File2"});
            _invertedIndex.GetWordDocs("java").Returns(new HashSet<string>() {"File1", "File3"});
            _invertedIndex.GetWordDocs("python").Returns(new HashSet<string>() {"File2"});
            _invertedIndex.GetWordDocs("sample").Returns(new HashSet<string>() {"File3"});
            _invertedIndex.AddDoc(new HashSet<string>() {"hello", "java"}, "File1");
            _invertedIndex.AddDoc(new HashSet<string>() {"hello", "python"}, "File2");
            _invertedIndex.AddDoc(new HashSet<string>(){"sample", "java"}, "File3");
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

        private void SetupTokenizer()
        {
            _tokenizer.Tokenize("Hello Java.").Returns(new HashSet<string>() {"hello", "java"});
            _tokenizer.Tokenize("Hello, python").Returns(new HashSet<string>() {"hello", "python"});
            _tokenizer.Tokenize("sample Java").Returns(new HashSet<string>(){"sample", "java"});
        }

        private void SetupFilterApplier()
        {
            string[] temp = new string[1];
            temp[0] = "hello";
            _filterApplier.Filter(new[] {"hello", "+java", "-sample"}).Returns(new HashSet<string>(){"File1"});
            _filterApplier.Filter(temp).Returns(new HashSet<string>() {"File1", "File2"});
            _filterApplier.Filter(new[] {"+java +python"}).Returns(new HashSet<string>() {"File1", "File2"});
        }

        private void SetupInterfaces()
        {
            SetupInvertedIndex();
            SetupDocsFileReader();
            SetupTokenizer();
            SetupFilterApplier();
        }

        // [Theory]
        // [InlineData("hello +java -sample", new [] {"File1"})]
        // [InlineData("hello", new [] {"File1", "File2"})]
        // [InlineData("+java +python", new [] {"File1", "File2"})]
        // public void TestFindCommandResult_WithDifferentEntries(string testCommand, string[] expectedResult)
        // {
        //     SetupInterfaces();
        //     Assert.Equal(expectedResult, _fullTextSearch.FindCommandResult(testCommand).ToArray());
        // }

        [Fact]
        public void TestFindCommandResult()
        {
            SetupInterfaces();
            Assert.Equal(new HashSet<string>(){"File1","File2"}, _fullTextSearch.FindCommandResult("+hello"));
        }
        
        
    }
}