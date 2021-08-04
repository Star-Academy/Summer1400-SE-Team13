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
            var command = Console.ReadLine();
            var invertedIndex = new InvertedIndex();
            var docsFileReader = new DocsFileReader("EnglishData");
            var tokenizer = new Tokenizer();
            var filterApplier = new FilterApplier(invertedIndex);
            var fullTextSearch = new FullTextSearch(invertedIndex, docsFileReader, tokenizer, filterApplier);
            var commandResult = fullTextSearch.FindCommandResult(command);
            PrintCommandResult(commandResult);
        }
    }
}