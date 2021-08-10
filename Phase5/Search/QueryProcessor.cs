using System.Collections.Generic;

namespace Phase5
{
    public class QueryProcessor : IQueryProcessor
    {
        public HashSet<string> PlusCommandWords { get; set; }
        public HashSet<string> MinusCommandWords { get; set; }
        public HashSet<string> NoSignCommandWords { get; set; }

        public QueryProcessor()
        {
            PlusCommandWords = new HashSet<string>();
            MinusCommandWords = new HashSet<string>();
            NoSignCommandWords = new HashSet<string>();
        }

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