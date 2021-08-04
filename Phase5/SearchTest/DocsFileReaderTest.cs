using System.Collections.Generic;
using System.IO;
using Phase5;
using Xunit;
namespace SearchTest
{
    public class DocsFileReaderTest
    {
        private DocsFileReader _docsFileReader;
        
        [Fact]
        public void TestReadContentFromSingleFile()
        {
            _docsFileReader = new DocsFileReader("TestFiles/File1.txt");
            var expected = new Dictionary<string, string>
            {
                {"File1", "Microsoft have just announced collaborative coding via Live Share."}
            };
            Assert.Equal(expected, _docsFileReader.ReadContent());
        }

        [Fact]
        public void TestReadContentFromFolder()
        {
            _docsFileReader = new DocsFileReader("TestFiles");
            var expected = new Dictionary<string, string>
            {
                {"File1", "Microsoft have just announced collaborative coding via Live Share."},
                {"File2", "Hello World!"},
                {"File3", "Hello, Xunit is a free and open-source unit testing tool."}
            };
            Assert.Equal(expected, _docsFileReader.ReadContent());
        }

        [Fact]
        public void TestReadContentForNotExistingPath_ShouldThrowIOException()
        {
            _docsFileReader = new DocsFileReader("TestFiles/File7.txt");
            Assert.Throws<IOException>(() => _docsFileReader.ReadContent());
        }
    }
}