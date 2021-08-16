using System.Collections.Generic;
using System.IO;
using System.Linq;
using Search.Interface;
using Search.Model;

namespace Search
{
    public class DocsFileReader : IDocsFileReader
    {
        public HashSet<Doc> ReadContent(string path)
        {
            var filesAddress = GetAllFilesAddresses(path);
            var docs = new HashSet<Doc>();
            foreach (var address in filesAddress)
            {
                docs.Add(new Doc()
                {
                    Name = Path.GetFileNameWithoutExtension(address),
                    Content = File.ReadAllText(address)
                });
            }

            return docs;
        }

        private IEnumerable<string> GetAllFilesAddresses(string path)
        {
            var filesAddress = new List<string>();
            if (File.Exists(path))
                filesAddress.Add(path);
            else if (Directory.Exists(path))
                filesAddress.AddRange(Directory.GetFiles(path).ToList());
            else
                throw new IOException("File not found!");
            
            return filesAddress;
        }
    }
}