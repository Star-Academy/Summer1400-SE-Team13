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
            _queryProcessor.SplitCommandWordsBySign(query);
            Assert.Equal(new HashSet<string> {"microsoft", "csharp"}, _queryProcessor.PlusCommandWords);
            Assert.Equal(new HashSet<string> {"xunit"}, _queryProcessor.MinusCommandWords);
            Assert.Equal(new HashSet<string>() {"hello", "code"}, _queryProcessor.NoSignCommandWords);
        }
    }
}