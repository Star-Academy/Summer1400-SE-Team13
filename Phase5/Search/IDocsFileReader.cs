using System.Collections.Generic;

namespace Phase5
{
    public interface IDocsFileReader
    {
        Dictionary<string, string> ReadContent(string path);
    }
}