using System.Collections.Generic;
using Search;
using Search.Interface;
using Xunit;

namespace SearchTest
{ 
    public class QueryProcessorTest
    { 
        private readonly IQueryProcessor _queryProcessor;
        
        public QueryProcessorTest()
        {
            _queryProcessor = new QueryProcessor();
        }
                
        [Fact]
        public void SplitBySign_ShouldFillSetOfNoSignAndPlusAndMinus()
        {
            const string query = "Hello +microsoft -xunit code +csharp";
            var commandWords = _queryProcessor.SplitCommandWordsBySign(query);
            Assert.Equal(new HashSet<string> {"microsoft", "csharp"}, commandWords.PlusCommandWords);
            Assert.Equal(new HashSet<string> {"xunit"}, commandWords.MinusCommandWords);
            Assert.Equal(new HashSet<string>() {"hello", "code"}, commandWords.NoSignCommandWords);
        }
    }
}