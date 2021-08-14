using System.Collections.Generic;
using System.IO;
using System.Linq;
using Search;
using Search.Interface;
using Search.Model;
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
            var expected = new HashSet<Doc>()
            {
                new()
                {
                    Name = "File1", Content = "Microsoft have just announced collaborative coding via Live Share."
                }
            };
            var actual = _docsFileReader.ReadContent("TestFiles/File1.txt");
            Assert.Equal(expected.First().Content, actual.First().Content);
        }

        [Fact]
        public void TestReadContentFromFolder()
        {
            var expected = new HashSet<Doc>()
            {
                new()
                {
                    Name = "File1", Content = "Microsoft have just announced collaborative coding via Live Share."
                },
                new()
                {
                    Name = "File2", Content = "Hello World!"
                },
                new()
                {
                    Name = "File3", Content = "Hello, Xunit is a free and open-source unit testing tool."
                }
            };
            var expectedContent = expected.Select(d => d.Content);
            var actualContent = _docsFileReader.ReadContent("TestFiles").Select(d => d.Content);
            Assert.Equal(expectedContent, actualContent);
        }

        [Fact]
        public void TestReadContentForNotExistingPath_ShouldThrowIOException()
        {
            Assert.Throws<IOException>(() => _docsFileReader.ReadContent("TestFiles/File7.txt"));
        }
    }
}