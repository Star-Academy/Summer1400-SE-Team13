using System.Collections.Generic;
using NSubstitute;
using Phase5;
using Search;
using Xunit;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly IFilterApplier _filterApplier;
        private readonly FullTextSearch _fullTextSearch;

        public FullTextSearchTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _docsFileReader = Substitute.For<IDocsFileReader>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(_invertedIndex, _docsFileReader, _filterApplier);
        }
    }
}