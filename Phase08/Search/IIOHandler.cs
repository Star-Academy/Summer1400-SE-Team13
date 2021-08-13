using System.Collections.Generic;

namespace Search
{
    public interface IIOHandler
    {
        string GetUserInput();
        void PrintCommandResult(HashSet<string> commandResult);
    }
}