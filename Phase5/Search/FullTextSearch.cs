using System.Collections.Generic;

namespace Phase5
{
    public class FullTextSearch
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly IDocsFileReader _docsFileReader;
        private readonly ITokenizer _tokenizer;
        private readonly IFilterApplier _filterApplier;

        public FullTextSearch(IInvertedIndex invertedIndex, IDocsFileReader docsFileReader,ITokenizer tokenizer, IFilterApplier filterApplier)
        {
            _invertedIndex = invertedIndex;
            _docsFileReader = docsFileReader;
            _tokenizer = tokenizer;
            _filterApplier = filterApplier;
        }

        public HashSet<string> FindCommandResult(string command)
         {
            LoadDocs();
            var commandWords = SplitCommand(command);
            return _filterApplier.Filter(commandWords);
        }

        private void LoadDocs()
        {
            var docsMap = _docsFileReader.ReadContent();
            foreach (var (docId, docContent) in docsMap)
            {
                var docWords = _tokenizer.Tokenize(docContent);
                _invertedIndex.AddDoc(docWords, docId);
            }
        }

        private string[] SplitCommand(string command)
        {
            return command.ToLower().Split(" ");
        }
    }
}