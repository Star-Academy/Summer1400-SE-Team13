using System.Collections.Generic;

namespace Search.Interface
{
    public interface ICommandWords
    {
        public IEnumerable<string> PlusCommandWords { get; }
        public IEnumerable<string> MinusCommandWords { get; }
        public IEnumerable<string> NoSignCommandWords { get; }
    }
}