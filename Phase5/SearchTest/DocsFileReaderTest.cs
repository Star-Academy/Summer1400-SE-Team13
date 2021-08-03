using Xunit;
using System.Collections.Generic;


namespace SearchTest
{
    public class DocsFileReaderTest
    {
        private readonly DocsFileReader _fileReader;
        public DocsFileReader()
        {
            _fileReader = new DocsFileReader();
        }
        [Fact]
        public void TestReadContentFromSingleFile()
        {
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected.Add("File1", "Microsoft have just announced collaborative coding via Live Share.");
            Assert.Equal(expected, _fileReader.ReadContent("Phase5\TestFiles\File1"));
        }

        [Fact]
        public void TestReadContentFromFolder()
        {

        }
    
    }
}