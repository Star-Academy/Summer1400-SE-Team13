using System.Collections.Generic;
using Search.Interface;

namespace Search
{
    public class CommandWords : ICommandWords
    {
        public IEnumerable<string> PlusCommandWords { get; }
        public IEnumerable<string> MinusCommandWords { get; }
        public IEnumerable<string> NoSignCommandWords { get; }
        
        public CommandWords(IEnumerable<string> plusCommandWords, IEnumerable<string> minusCommandWords, IEnumerable<string> noSignCommandWords)
        {
            PlusCommandWords = plusCommandWords;
            MinusCommandWords = minusCommandWords;
            NoSignCommandWords = noSignCommandWords;
        }
    }
}