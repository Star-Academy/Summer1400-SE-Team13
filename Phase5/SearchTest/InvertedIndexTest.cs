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

        private void Setup()
        {
            _testWordsMap.Add("word1", new HashSet<string>(){"doc1", "doc2"});
            _testWordsMap.Add("word2", new HashSet<string>(){"doc1"});
            _invertedIndex.AddDoc(new HashSet<string>(){"word1", "word2"}, "doc1");
            _invertedIndex.AddDoc(new HashSet<string>(){"word1"}, "doc2");
        }

        [Fact]
        public void TestAddDocumentToInvertedIndex()
        {
            Setup();
            Assert.Equal(_testWordsMap, _invertedIndex.GetWordsMap());
        }
        
        [Fact]
        public void TestGetWordDocuments()
        {
            Setup();
            HashSet<string> expectedDocs = new HashSet<string>() {"doc1", "doc2"};
            Assert.Equal(expectedDocs, _invertedIndex.GetWordDocs("word1"));
            
        }
    }
}