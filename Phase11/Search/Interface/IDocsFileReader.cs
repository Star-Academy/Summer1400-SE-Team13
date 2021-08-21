using System.Collections.Generic;

namespace Search.Interface
{
    public interface IDocsFileReader
    {
        Dictionary<string, string> ReadContent(string path);
    }
}