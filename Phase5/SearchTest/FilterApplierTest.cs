using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class FilterApplierTest
    {
        private readonly IInvertedIndex _invertedIndex;

        public FilterApplierTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
        }
      
        [Theory]
        [InlineData(new [] {"microsoft"},new [] {"xunit"},new [] {"hello"}, new string[] {})]
        [InlineData(new string[]{}, new [] {"xunit", "hello"}, new string[] {}, new string[] {})]
        [InlineData(new [] {"microsoft", "hello"}, new string[] {}, new [] {"xunit"}, new [] {"File3.txt"})]
        public void FilterApplierTestMethod(string[] plusWords, string[] minusWords, string[] noSignWords, string[] expected)
        {
            SetupInvertedIndex();
            var filterApplier = new FilterApplier(_invertedIndex);
            var actualValue =
                filterApplier.Filter(plusWords.ToHashSet(), minusWords.ToHashSet(), noSignWords.ToHashSet());
            Assert.Equal(expected.ToHashSet(), actualValue);
        }
        private void SetupInvertedIndex()
        {
            _invertedIndex.GetWordDocs("microsoft").Returns(new HashSet<string>{"File1.txt"});
            _invertedIndex.GetWordDocs("hello").Returns(new HashSet<string>{"File2.txt", "File3.txt"});
            _invertedIndex.GetWordDocs("tool").Returns(new HashSet<string>{"File3.txt"});
            _invertedIndex.GetWordDocs("xunit").Returns(new HashSet<string>{"File3.txt"});
        }
    }
}