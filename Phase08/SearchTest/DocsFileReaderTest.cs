using System.Collections.Generic;
using System.IO;
using Search;
using Search.Interface;
using Xunit;
namespace SearchTest
{
    public class DocsFileReaderTest
    {
        private readonly IDocsFileReader _docsFileReader;
        public DocsFileReaderTest()
        {
            _docsFileReader = new DocsFileReader();
        }
        
        [Fact]
        public void TestReadContentFromSingleFile()
        {
            var expected = new Dictionary<string, string>
            {
                {"File1", "Microsoft have just announced collaborative coding via Live Share."}
            };
            Assert.Equal(expected, _docsFileReader.ReadContent("TestFiles/File1.txt"));
        }

        [Fact]
        public void TestReadContentFromFolder()
        {
            var expected = new Dictionary<string, string>
            {
                {"File1", "Microsoft have just announced collaborative coding via Live Share."},
                {"File2", "Hello World!"},
                {"File3", "Hello, Xunit is a free and open-source unit testing tool."}
            };
            Assert.Equal(expected, _docsFileReader.ReadContent("TestFiles"));
        }

        [Fact]
        public void TestReadContentForNotExistingPath_ShouldThrowIOException()
        {
            Assert.Throws<IOException>(() => _docsFileReader.ReadContent("TestFiles/File7.txt"));
        }
    }
}