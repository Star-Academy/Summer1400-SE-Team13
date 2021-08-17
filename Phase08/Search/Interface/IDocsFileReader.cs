using System.Collections.Generic;
using Search.Model;

namespace Search.Interface
{
    public interface IDocsFileReader
    {
        Dictionary<string, string> ReadContent(string path);
    }
}