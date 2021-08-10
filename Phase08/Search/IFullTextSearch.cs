using System.Collections.Generic;

namespace Search
{
    public interface IFullTextSearch
    {
        HashSet<string> FindCommandResult(string command);
    }
}