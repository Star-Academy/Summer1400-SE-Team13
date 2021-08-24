﻿using System.Collections.Generic;
using Search;
using Search.Interface;
using Xunit;

namespace SearchTest
{
    public class TokenizerTest
    {
        private readonly ITokenizer _tokenizer;
        public TokenizerTest()
        {
            _tokenizer = new Tokenizer();
        }

        [Fact]
        public void TestTokenizeMethod_ShouldExtractWords()
        {
            const string testString = "Hello-hi, how? java*python! test.";
            var expected = new HashSet<string>(){"hello", "hi", "how","java","python","test"};
            Assert.Equal(expected, _tokenizer.Tokenize(testString));
        }
    }
}