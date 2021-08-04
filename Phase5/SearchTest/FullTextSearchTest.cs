using System.Collections.Generic;
using NSubstitute;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class FullTextSearchTest
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly ITokenizer _tokenizer;
        private readonly IFilterApplier _filterApplier;
        private readonly FullTextSearch _fullTextSearch;

        public FullTextSearchTest()
        {
            _invertedIndex = Substitute.For<IInvertedIndex>();
            _docsFileReader = Substitute.For<IDocsFileReader>();
            _tokenizer = Substitute.For<ITokenizer>();
            _filterApplier = Substitute.For<IFilterApplier>();
            _fullTextSearch = new FullTextSearch(_invertedIndex, _docsFileReader,_tokenizer, _filterApplier);
        }
        
        
        
    }
}