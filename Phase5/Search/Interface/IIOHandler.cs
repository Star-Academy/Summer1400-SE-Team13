using System.Collections.Generic;

namespace Phase5.Interface
{
    public interface IIOHandler
    {
        string GetUserInput();
        void PrintCommandResult(HashSet<string> commandResult);
    }
}