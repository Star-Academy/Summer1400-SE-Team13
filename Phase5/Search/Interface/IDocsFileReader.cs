using System.Collections.Generic;

namespace Phase5.Interface
{
    public interface IDocsFileReader
    {
        Dictionary<string, string> ReadContent(string path);
    }
}