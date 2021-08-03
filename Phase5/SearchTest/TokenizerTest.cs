using System.Collections.Generic;
using Phase5;
using Xunit;

namespace SearchTest
{
    public class TokenizerTest
    {
        private readonly Tokenizer _tokenizer;

        public TokenizerTest()
        {
            _tokenizer = new Tokenizer();
        }
        

        [Fact]
        public void TestTokenizeMethod()
        {
            string test = "Hello-hi, how? java*python! test.";
            HashSet<string> expected = new HashSet<string> { };
        }
            
    }
}