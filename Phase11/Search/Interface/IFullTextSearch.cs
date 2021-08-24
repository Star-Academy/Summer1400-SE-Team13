using System.Collections.Generic;

namespace Search.Interface
{
    public interface IFullTextSearch
    {
        IEnumerable<string> FindCommandResult(string command, string folderPath);
    }
}