using System.Collections.Generic;
using System.Linq;

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
            var noSignWithoutMinus = new HashSet<string>(noSignCommandWordsDocs).Except(minusCommandWordsDocs).ToHashSet();
            var result = !plusCommandWordsDocs.Any() ? noSignWithoutMinus : noSignWithoutMinus.Intersect(plusCommandWordsDocs).ToHashSet();
            return result;
        }
        
        private HashSet<string> GetNoSignDocs(HashSet<string> noSignWords)
        {
            var wordsDocs = new HashSet<string>();
            foreach (var docs in noSignWords.Select(word => _invertedIndex.GetWordDocs(word)))
            {
                if (!wordsDocs.Any())
                {
                    wordsDocs.UnionWith(docs);
                }
                else
                {
                    wordsDocs.IntersectWith(docs);
                }
            }
            return wordsDocs;
        }

        private HashSet<string> GetSignDocs(HashSet<string> signWords)
        {
            var wordsDocs = new HashSet<string>();
            foreach (var docs in signWords.Select(word => _invertedIndex.GetWordDocs(word)))
            {
                wordsDocs.UnionWith(docs);
            }

            return wordsDocs;
        }
    }
}