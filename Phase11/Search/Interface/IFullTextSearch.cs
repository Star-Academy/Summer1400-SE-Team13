using System.Collections.Generic;

namespace Search.Interface
{
    public interface IFullTextSearch
    {
        HashSet<string> FindCommandResult(string command, string folderPath);
    }
}