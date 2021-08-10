using System;
using System.Collections.Generic;
using Model;

namespace Search
{
    class Program
    {
        static void PrintCommandResult(HashSet<string> commandResult)
        {
            if (commandResult.Count == 0)
            {
                Console.WriteLine("No do found!");
            }
            else
            {
                Console.WriteLine("Count: " + commandResult.Count);
                Console.WriteLine("Docs: " + string.Join(",", commandResult));
            }
        }
        static void Main(string[] args)
        {
            const string filePath = "EnglishData";
            var command = Console.ReadLine();
            using var context = new SearchContext();
            var invertedIndex = new InvertedIndex(context);
            var docsFileReader = new DocsFileReader(filePath);
            var tokenizer = new Tokenizer();
            var queryProcessor = new QueryProcessor();
            var filterApplier = new FilterApplier(invertedIndex);
            var fullTextSearch = new FullTextSearch(invertedIndex, docsFileReader, tokenizer, queryProcessor, filterApplier);
            var searchResult = fullTextSearch.FindCommandResult(command);
            PrintCommandResult(searchResult);
        }
    }
}
