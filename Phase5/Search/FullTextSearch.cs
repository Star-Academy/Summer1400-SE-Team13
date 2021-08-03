using Search;

namespace Phase5
{
    public class FullTextSearch
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly IFilterApplier _filterApplier;

        public FullTextSearch(IInvertedIndex invertedIndex, IDocsFileReader docsFileReader, IFilterApplier filterApplier)
        {
            _invertedIndex = invertedIndex;
            _docsFileReader = docsFileReader;
            _filterApplier = filterApplier;
        }
    }
}