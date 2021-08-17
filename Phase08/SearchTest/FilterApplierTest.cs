using System.Collections.Generic;
using NSubstitute;
using Search;
using Search.Interface;
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
        
        public static IEnumerable<object[]> FilterApplierTestData()
        {
            yield return new object[] {new HashSet<string> {"microsoft"},new HashSet<string> {"xunit"},new HashSet<string> {"hello"}, new HashSet<string>()};
            yield return new object[] {new HashSet<string>(), new HashSet<string> {"xunit", "hello"}, new HashSet<string>(), new HashSet<string>()};
            yield return new object[] {new HashSet<string> {"microsoft", "hello"}, new HashSet<string>(), new HashSet<string> {"xunit"}, new HashSet<string> {"File3.txt"}};
        }
        
        [Theory, MemberData(nameof(FilterApplierTestData))]
        public void FilterApplierTestMethod(HashSet<string> plusWords, HashSet<string> minusWords, HashSet<string> noSignWords, HashSet<string> expected)
        {
            SetupInvertedIndex();
            var filterApplier = new FilterApplier(_invertedIndex);
            var actualValue = filterApplier.Filter(plusWords, minusWords, noSignWords);
            Assert.Equal(expected, actualValue);
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