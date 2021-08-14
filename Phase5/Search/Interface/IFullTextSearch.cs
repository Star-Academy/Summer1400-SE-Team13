using System.Collections.Generic;

namespace Phase5.Interface
{
    public interface IFullTextSearch
    {
        HashSet<string> FindCommandResult(string command);
    }
}