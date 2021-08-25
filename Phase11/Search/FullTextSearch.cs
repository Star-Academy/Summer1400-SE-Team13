using System.Collections.Generic;
using Search.Interface;

namespace Search
{
    public class FullTextSearch : IFullTextSearch
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly ITokenizer _tokenizer;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IFilterApplier _filterApplier;

        public FullTextSearch(IInvertedIndex invertedIndex, 
            IDocsFileReader docsFileReader,
            ITokenizer tokenizer, 
            IQueryProcessor queryProcessor, 
            IFilterApplier filterApplier)
        {
            _invertedIndex = invertedIndex;
            _docsFileReader = docsFileReader;
            _tokenizer = tokenizer;
            _queryProcessor = queryProcessor;
            _filterApplier = filterApplier;
        }

        public IEnumerable<string> FindCommandResult(string command, string folderPath)
        {
            var docs = _docsFileReader.ReadContent(folderPath);
            _invertedIndex.BuildInvertedIndex(docs, _tokenizer);
            var commandWords = _queryProcessor.SplitCommandWordsBySign(command);
            var result = _filterApplier.Filter(commandWords.PlusCommandWords, commandWords.MinusCommandWords, commandWords.NoSignCommandWords);
            return result;
        }
    }
}