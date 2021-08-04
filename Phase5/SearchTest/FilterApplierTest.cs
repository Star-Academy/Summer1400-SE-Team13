using System.Collections.Generic;
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
        private void SetupInterfaces()
        {
            _invertedIndex.GetWordDocs("microsoft").Returns(new HashSet<string>{"File1.txt"});
            _invertedIndex.GetWordDocs("hello").Returns(new HashSet<string>{"File2.txt"});
            _invertedIndex.GetWordDocs("tool").Returns(new HashSet<string>{"File3.txt"});
            _invertedIndex.GetWordDocs("xunit").Returns(new HashSet<string>{"File3.txt"});
        }
        [Fact]
        public void FilterApplierTestMethod()
        {
            SetupInterfaces();
            var filterApplier = new FilterApplier(_invertedIndex);
            var testCommand = new []{"+microsoft", "-xunit", "hello"};
            var expected = new HashSet<string>(){"File2.txt"};
            Assert.Equal(expected, filterApplier.Filter(testCommand));
        }
    }
}