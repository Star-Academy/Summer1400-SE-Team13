using System;
using System.Collections.Generic;

namespace Phase5
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
            var invertedIndex = new InvertedIndex();
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
