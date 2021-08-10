using System.Collections.Generic;

namespace Search
{
    public interface IFilterApplier
    { 
        HashSet<string> Filter(HashSet<string> plusWords, HashSet<string> minusWords, HashSet<string> noSignWords);
    }
}