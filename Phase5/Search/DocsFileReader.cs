using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase5
{
    public class DocsFileReader : IDocsFileReader
    {
        private readonly string _filePath;

        public DocsFileReader(string filePath)
        {
            _filePath = filePath;
        }
    
        public Dictionary<string, string> ReadContent()
        {
            var filesAddress = GetAllFilesAddresses();

            return filesAddress.ToDictionary(Path.GetFileNameWithoutExtension, File.ReadAllText);
        }

        private IEnumerable<string> GetAllFilesAddresses()
        {
            var filesAddress = new List<string>();
            if (File.Exists(_filePath))
                filesAddress.Add(_filePath);

            else if (Directory.Exists(_filePath))
                filesAddress.AddRange(Directory.GetFiles(_filePath).ToList());
            else
                throw new IOException("File not found!");
            
            return filesAddress;
        }
    }
}