using System.IO;
namespace phase04 
{
    class FileReader
    {
        public string ReadData(string path) {
            return File.ReadAllText(path);
        }
    }
}
   
