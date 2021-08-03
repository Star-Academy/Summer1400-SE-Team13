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
        public void SetupInterfaces()
        {
            _invertedIndex.GetWordDocs("");
        }
        [Fact]
        public void FilterApplierTestMethod()
        {
            var filterApplier = new FilterApplier(_invertedIndex);
            var testCommand = new []{"+microsoft", "hello", "-tool"};
            var expected = new HashSet<string>(){"File1"};
            Assert.Equal(expected, filterApplier.Filter(testCommand));
        }
    }
}