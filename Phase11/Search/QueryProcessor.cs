using System.Collections.Generic;
using Search.Interface;

namespace Search
{
    public class QueryProcessor : IQueryProcessor
    {
        public CommandWords SplitCommandWordsBySign(string command)
        {
            var commandWords = command.ToLower().Split(" ");
            var plusCommandWords = new HashSet<string>();
            var minusCommandWords = new HashSet<string>();
            var noSignCommandWords = new HashSet<string>();
            foreach (var word in commandWords)
            {
                switch (word[0])
                {
                    case '+':
                        plusCommandWords.Add(word.Substring(1));
                        break;
                    case '-':
                        minusCommandWords.Add(word.Substring(1));
                        break;
                    default:
                        noSignCommandWords.Add(word);
                        break;
                }
            }
            return new CommandWords(plusCommandWords, minusCommandWords, noSignCommandWords);
        }
    }
}