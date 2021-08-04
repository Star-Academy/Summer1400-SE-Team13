using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase5
{
    public class DocsFileReader
    {
        public Dictionary<string, string> ReadContent(string path)
        {
            var filesAddress = GetAllFiles(path);
            var filesContents = new Dictionary<string, string>();

            foreach (var address in filesAddress)
                filesContents.Add(Path.GetFileNameWithoutExtension(address), File.ReadAllText(address));
            return filesContents;
        }

        private List<string> GetAllFiles(string path)
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