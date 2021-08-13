using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class InvertedIndexTest
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly ITokenizer _tokenizer;

        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
            _tokenizer = Substitute.For<ITokenizer>();
        }

        [Theory]
        [InlineData("word1", new [] {"doc1", "doc2"})]
        [InlineData("word3", new string[]{})]
        public void TestGetWordDocs_ForExistingAndNotExistingWord(string word, string[] expectedDocs)
        {
            SetupMockedObjects();
            Assert.Equal(expectedDocs.ToHashSet(), _invertedIndex.GetWordDocs(word));
            
        }

        private void SetupMockedObjects()
        {
            SetupMockedTokenizer();
            SetupMockedInvertedIndex();
        }

        private void SetupMockedTokenizer()
        {
            _tokenizer.Tokenize("word1 word2").Returns(new HashSet<string>() {"word1", "word2"});
            _tokenizer.Tokenize("word1").Returns(new HashSet<string>() {"word1"});
        }
        private void SetupMockedInvertedIndex()
        {
            var docsMap = new Dictionary<string, string>()
            {
                {"doc1", "word1 word2"},
                {"doc2", "word1"}
            };
            _invertedIndex.BuildInvertedIndex(docsMap, _tokenizer);
        }
    }
}