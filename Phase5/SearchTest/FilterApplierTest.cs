using System.Collections.Generic;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest.TestFiles
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
            FilterApplier _filterApplier = new FilterApplier(_invertedIndex);
            var testCommand = new []{"+microsoft", "hello", "-tool"};
            HashSet<string> expected = new HashSet<string>();
            expected.Add("File1");
            Assert.Equal(expected, _filterApplier.Filter(testCommand));
        }
    }
}