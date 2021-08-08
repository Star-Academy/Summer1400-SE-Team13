using System.Collections.Generic;

namespace Phase5
{
    public interface IFullTextSearch
    {
        HashSet<string> FindCommandResult(string command);
    }
}