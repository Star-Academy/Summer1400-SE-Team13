using System.Collections.Generic;

namespace Search.Interface
{
    public interface IFilterApplier
    { 
        IEnumerable<string> Filter(IEnumerable<string> plusWords, IEnumerable<string> minusWords, IEnumerable<string> noSignWords);
    }
}