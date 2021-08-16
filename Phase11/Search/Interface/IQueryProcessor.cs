using System.Collections.Generic;

namespace Search.Interface
{
    public interface IQueryProcessor
    { 
        HashSet<string> PlusCommandWords { get; set; }
        HashSet<string> MinusCommandWords { get; set; }
        HashSet<string> NoSignCommandWords { get; set; }
        void SplitCommandWordsBySign(string command);
    }
}