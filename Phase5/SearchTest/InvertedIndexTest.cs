using System.Collections.Generic;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class InvertedIndexTest
    {
        private readonly InvertedIndex _invertedIndex;

        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
        }

        private void SetupInvertedIndex()
        {
            _invertedIndex.AddDoc(new HashSet<string>(){"word1", "word2"}, "doc1");
            _invertedIndex.AddDoc(new HashSet<string>(){"word1"}, "doc2");
        }

        [Fact]
        public void TestGetExistingWordDocuments()
        {
            SetupInvertedIndex();
            var expectedDocs = new HashSet<string>() {"doc1", "doc2"};
            Assert.Equal(expectedDocs, _invertedIndex.GetWordDocs("word1"));
            
        }

        [Fact]
        public void TestGetNotExistingWordDocuments()
        {
            SetupInvertedIndex();
            Assert.Empty(_invertedIndex.GetWordDocs("word"));
        }
    }
}