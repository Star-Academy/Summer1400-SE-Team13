using System.Collections.Generic;

namespace Search.Interface
{
    public interface IIOHandler
    {
        string GetUserInput();
        void PrintCommandResult(HashSet<string> commandResult);
    }
}