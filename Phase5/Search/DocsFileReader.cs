using System.Collections.Generic;

namespace Search
{
    public class DocsFileReader : IDocsFileReader
    {
        public Dictionary<String, String> ReadContent(){
            Dictionary<String, String> doc = new Dictionary<String, String>();
            doc.Add("1", "Microsoft have just announced collaborative coding via Live Share.");
            return doc;
        }
    }
}