using System.Collections.Generic;
using Search.Model;

namespace Search
{
    public interface IDocsFileReader
    {
        HashSet<Doc> ReadContent(string path);
    }
}