using System.Collections.Generic;

namespace Search
{
    public class CommandWords
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