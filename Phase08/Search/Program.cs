using Search.Model;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioHandler = new IOHandler();
            var command = ioHandler.GetUserInput();
            var context = new ContextFactory().CreateDbContext();
            var invertedIndex = new InvertedIndex(context);
            var docsFileReader = new DocsFileReader();
            var tokenizer = new Tokenizer();
            var queryProcessor = new QueryProcessor();
            var filterApplier = new FilterApplier(invertedIndex);
            var fullTextSearch = new FullTextSearch(invertedIndex, docsFileReader, tokenizer, queryProcessor, filterApplier);
            var searchResult = fullTextSearch.FindCommandResult(command);
            ioHandler.PrintCommandResult(searchResult);
        }
    }
}