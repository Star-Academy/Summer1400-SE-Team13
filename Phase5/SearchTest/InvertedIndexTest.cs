using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [InlineData("word1", new [] {"doc1", "doc2"})]
        [InlineData("word3", new string[]{})]
        public void TestGetWordDocs_ForExistingAndNotExistingWord(string word, string[] expectedDocs)
        {
            SetupInvertedIndex();
            Assert.Equal(expectedDocs.ToHashSet(), _invertedIndex.GetWordDocs(word));
            
        }
        private void SetupInvertedIndex()
        {
            var wordsMap = new Dictionary<string, HashSet<string>>()
            {
                {"word1", new HashSet<string>(){"doc1", "doc2"}},
                {"word2", new HashSet<string>(){"doc1"}}
            };
            _invertedIndex.SetupInvertedIndex(wordsMap);
        }
    }
}