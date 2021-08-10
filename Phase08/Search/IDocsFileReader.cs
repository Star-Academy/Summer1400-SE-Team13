using System.Collections.Generic;

namespace Search
{
    public interface IDocsFileReader
    {
        Dictionary<string, string> ReadContent();
    }
}