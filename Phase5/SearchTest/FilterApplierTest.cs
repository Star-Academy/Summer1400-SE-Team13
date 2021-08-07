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
        private void SetupInterfaces()
        {
            _invertedIndex.GetWordDocs("microsoft").Returns(new HashSet<string>{"File1.txt"});
            _invertedIndex.GetWordDocs("hello").Returns(new HashSet<string>{"File2.txt", "File3.txt"});
            _invertedIndex.GetWordDocs("tool").Returns(new HashSet<string>{"File3.txt"});
            _invertedIndex.GetWordDocs("xunit").Returns(new HashSet<string>{"File3.txt"});
        }
        [Theory]
        [InlineData(new [] {"+microsoft", "-xunit", "hello"}, new [] {"File2.txt"})]
        [InlineData(new [] {"-xunit", "-hello"}, new string[] {})]
        [InlineData(new [] {"+microsoft", "xunit", "+hello"}, new [] {"File3.txt"})]
        public void FilterApplierTestMethod(string[] testCommand, string[] expected)
        {
            SetupInterfaces();
            var filterApplier = new FilterApplier(_invertedIndex);
            Assert.Equal(expected.ToHashSet(), filterApplier.Filter(testCommand));
        }
    }
}