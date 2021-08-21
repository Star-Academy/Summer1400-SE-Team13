using System.Collections.Generic;
using System.Linq;
using Search.Interface;

namespace Search
{
    public class FilterApplier : IFilterApplier
    {
        private readonly IInvertedIndex _invertedIndex;
        public FilterApplier(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
        }
        
        public HashSet<string> Filter(HashSet<string> plusWords, HashSet<string> minusWords, HashSet<string> noSignWords)
        {
            var plusCommandWordsDocs = GetSignDocs(plusWords);
            var minusCommandWordsDocs = GetSignDocs(minusWords);
            var noSignCommandWordsDocs = GetNoSignDocs(noSignWords);
            var result = FindFilteredResult(plusCommandWordsDocs, minusCommandWordsDocs, noSignCommandWordsDocs);
            return result;
        }

        private HashSet<string> FindFilteredResult(HashSet<string> plusDocs, HashSet<string> minusDocs, HashSet<string> noSignDocs)
        {
            var noSignWithoutMinus = new HashSet<string>(noSignDocs).Except(minusDocs).ToHashSet();
            var result = !plusDocs.Any() ? noSignWithoutMinus : noSignWithoutMinus.Intersect(plusDocs).ToHashSet();
            return result;
        }
        private HashSet<string> GetNoSignDocs(HashSet<string> noSignWords)
        {
            return noSignWords.Any()
                ? noSignWords.Select(x => _invertedIndex.GetWordDocs(x))
                    .Aggregate((a, b) => a.Intersect(b).ToHashSet())
                : new HashSet<string>();
        }

        private HashSet<string> GetSignDocs(HashSet<string> signWords)
        {
            return signWords.SelectMany(x => _invertedIndex.GetWordDocs(x)).ToHashSet();
        }
    }
}