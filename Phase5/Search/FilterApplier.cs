using System.Collections.Generic;
using System.Linq;

namespace Phase5
{
    public class FilterApplier : IFilterApplier
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly HashSet<string> _plusCommandWords;
        private readonly HashSet<string> _minusCommandWords;
        private readonly HashSet<string> _noSignCommandWords;
        public FilterApplier(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
            _plusCommandWords = new HashSet<string>();
            _minusCommandWords = new HashSet<string>();
            _noSignCommandWords = new HashSet<string>();
        }
        public HashSet<string> Filter(string[] commandWords)
        {
            SplitCommandWordsBySign(commandWords);
            var plusCommandWordsDocs = GetSignDocs(_plusCommandWords);
            var minusCommandWordsDocs = GetSignDocs(_minusCommandWords);
            var noSignCommandWordsDocs = GetNoSignDocs(_noSignCommandWords);
            var noSignWithoutMinus = new HashSet<string>(noSignCommandWordsDocs).Except(minusCommandWordsDocs).ToHashSet();
            return !plusCommandWordsDocs.Any() ? noSignWithoutMinus : noSignWithoutMinus.Intersect(plusCommandWordsDocs).ToHashSet();

        }
        
        private void SplitCommandWordsBySign(string[] commandWords)
        {
            foreach (var word in commandWords)
            {
                switch (word[0])
                {
                    case '+':
                        _plusCommandWords.Add(word.Substring(1));
                        break;
                    case '-':
                        _minusCommandWords.Add(word.Substring(1));
                        break;
                    default:
                        _noSignCommandWords.Add(word);
                        break;
                }
            }
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