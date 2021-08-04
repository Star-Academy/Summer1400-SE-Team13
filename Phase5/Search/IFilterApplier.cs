using System.Collections.Generic;

namespace Phase5
{
    public interface IFilterApplier
    {
        HashSet<string> Filter(string[] commandWords);
    }
}