using System.Collections.Generic;
using Search.Interface;

namespace Search
{
    public class QueryProcessor : IQueryProcessor
    {
        public HashSet<string> PlusCommandWords { get; set; } = new();
        public HashSet<string> MinusCommandWords { get; set; } = new();
        public HashSet<string> NoSignCommandWords { get; set; } = new();
        
        public void SplitCommandWordsBySign(string command)
        {
            var commandWords = command.ToLower().Split(" ");
            foreach (var word in commandWords)
            {
                switch (word[0])
                {
                    case '+':
                        PlusCommandWords.Add(word.Substring(1));
                        break;
                    case '-':
                        MinusCommandWords.Add(word.Substring(1));
                        break;
                    default:
                        NoSignCommandWords.Add(word);
                        break;
                }
            }
        }
    }
}