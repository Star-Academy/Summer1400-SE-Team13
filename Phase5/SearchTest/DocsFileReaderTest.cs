using System.Collections.Generic;
using Phase5;
using Xunit;
namespace SearchTest
{
    public class DocsFileReaderTest
    {
        private readonly DocsFileReader _docsFileReader;

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
                {"File3", "Xunit is a free and open-source unit testing tool."}
            };
            Assert.Equal(expected, _docsFileReader.ReadContent("TestFiles"));
        }
    }
}