using System.Collections.Generic;

namespace Search.Interface
{
    public interface IDocsFileReader
    {
        IDictionary<string, string> ReadContent(string path);
    }
}