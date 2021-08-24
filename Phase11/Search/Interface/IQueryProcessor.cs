using System.Collections.Generic;

namespace Search.Interface
{
    public interface IQueryProcessor
    {
        CommandWords SplitCommandWordsBySign(string command);
    }
}