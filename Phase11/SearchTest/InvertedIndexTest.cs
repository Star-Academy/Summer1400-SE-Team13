using Search;
using Xunit;
using Search.Interface;

namespace SearchTest
{
    public class InvertedIndexTest
    {
        private readonly IInvertedIndex _invertedIndex;

        public InvertedIndexTest()
        {
            var searchContext = DbContextFactory.CreateContext();
            _invertedIndex = new InvertedIndex(searchContext);
        }
        
        [Theory]
        [InlineData("microsoft", new [] {"File1"})]
        [InlineData("word", new string[]{})]
        public void TestGetWordDocs_ForExistingAndNotExistingWord(string testWord, string[] expected)
        {
            Assert.Equal(expected, _invertedIndex.GetWordDocs(testWord));
        }
    }
}