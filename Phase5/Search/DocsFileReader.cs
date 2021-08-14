using System.Collections.Generic;
using System.IO;
using System.Linq;
using Phase5.Interface;

namespace Phase5
{
    public class DocsFileReader : IDocsFileReader
    {
        public Dictionary<string, string> ReadContent(string path)
        {
            var filesAddress = GetAllFilesAddresses(path);

            return filesAddress.ToDictionary(Path.GetFileNameWithoutExtension, File.ReadAllText);
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