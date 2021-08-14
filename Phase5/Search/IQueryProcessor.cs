using System.Collections.Generic;

namespace Phase5
{
    public interface IQueryProcessor
    { 
        HashSet<string> PlusCommandWords { get; }
        HashSet<string> MinusCommandWords { get; }
        HashSet<string> NoSignCommandWords { get; }
        void SplitCommandWordsBySign(string command);
    }
}