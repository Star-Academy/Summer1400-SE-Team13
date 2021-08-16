using System.Collections.Generic;
using Search.Model;

namespace Search.Interface
{
    public interface IDocsFileReader
    {
        HashSet<Doc> ReadContent(string path);
    }
}