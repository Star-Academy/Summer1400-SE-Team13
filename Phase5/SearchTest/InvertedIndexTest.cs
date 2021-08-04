using System.Collections.Generic;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class InvertedIndexTest
    {
        private readonly InvertedIndex _invertedIndex;
        private readonly Dictionary<string, HashSet<string>> _testWordsMap;

        public InvertedIndexTest()
        {
            _invertedIndex = new InvertedIndex();
            _testWordsMap = new Dictionary<string, HashSet<string>>();
        }

        private void SetupInvertedIndex()
        {
            _invertedIndex.AddDoc(new HashSet<string>(){"word1", "word2"}, "doc1");
            _invertedIndex.AddDoc(new HashSet<string>(){"word1"}, "doc2");
        }

        private void SetupTestWordsMap()
        {
            _testWordsMap.Add("word1", new HashSet<string>(){"doc1", "doc2"});
            _testWordsMap.Add("word2", new HashSet<string>(){"doc1"});
        }

        [Fact]
        public void TestAddDocumentToInvertedIndex()
        {
            SetupInvertedIndex();
            SetupTestWordsMap();
            Assert.Equal(_testWordsMap, _invertedIndex.GetWordsMap());
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
            Assert.Null(_invertedIndex.GetWordDocs("word"));
        }
    }
}