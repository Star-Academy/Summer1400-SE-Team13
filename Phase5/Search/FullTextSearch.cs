﻿using System.Collections.Generic;

namespace Phase5
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

        public HashSet<string> FindCommandResult(string command)
        {
            LoadDocs();
            _queryProcessor.SplitCommandWordsBySign(command);
            var result = _filterApplier.Filter(_queryProcessor.PlusCommandWords, _queryProcessor.MinusCommandWords, _queryProcessor.NoSignCommandWords);
            return result;
        }

        private void LoadDocs()
        {
            var docsMap = _docsFileReader.ReadContent();
            Dictionary<string, HashSet<string>> invertedIndexMap = new Dictionary<string, HashSet<string>>();
            foreach (var (docId, docContent) in docsMap)
            {
                var docWords = _tokenizer.Tokenize(docContent);
                invertedIndexMap.Add(docId, docWords);
                _invertedIndex.Setup(invertedIndexMap);
            }
        }
    }
}