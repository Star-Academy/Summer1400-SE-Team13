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
        
        public IEnumerable<string> Filter(IEnumerable<string> plusWords, IEnumerable<string> minusWords, IEnumerable<string> noSignWords)
        {
            var plusCommandWordsDocs = GetSpecificSignWordsDocs(plusWords);
            var minusCommandWordsDocs = GetSpecificSignWordsDocs(minusWords);
            var noSignCommandWordsDocs = GetNoSignWordsDocs(noSignWords);
            var result = FindFilteredResult(plusCommandWordsDocs, minusCommandWordsDocs, noSignCommandWordsDocs);
            return result;
        }

        private IEnumerable<string> FindFilteredResult(IEnumerable<string> plusDocs, IEnumerable<string> minusDocs, IEnumerable<string> noSignDocs)
        {
            var noSignWithoutMinus = new HashSet<string>(noSignDocs).Except(minusDocs).ToHashSet();
            var result = !plusDocs.Any() ? noSignWithoutMinus : noSignWithoutMinus.Intersect(plusDocs).ToHashSet();
            return result;
        }
        private IEnumerable<string> GetNoSignWordsDocs(IEnumerable<string> noSignWords)
        {
            return noSignWords.Any()
                ? noSignWords.Select(x => _invertedIndex.GetWordDocs(x))
                    .Aggregate((a, b) => a.Intersect(b).ToHashSet())
                : new HashSet<string>();
        }

        private IEnumerable<string> GetSpecificSignWordsDocs(IEnumerable<string> signWords)
        {
            return signWords.SelectMany(x => _invertedIndex.GetWordDocs(x)).ToHashSet();
        }
    }
}