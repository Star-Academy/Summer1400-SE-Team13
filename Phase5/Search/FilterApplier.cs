using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phase5
{
    public class FilterApplier : IFilterApplier
    {
        private readonly IInvertedIndex _invertedIndex;
        private readonly HashSet<string> _plusCommandWords;
        private readonly HashSet<string> _minusCommandWords;
        private readonly HashSet<string> _noSignCommandWords;

        private const char PlusSign = '+';
        private const char MinusSign = '-';
        private const char NoSign = ' ';
        public FilterApplier(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
            _plusCommandWords = new HashSet<string>();
            _minusCommandWords = new HashSet<string>();
            _noSignCommandWords = new HashSet<string>();
        }

        private void SplitCommandWords(string[] commandWords)
        {
            foreach (string word in commandWords) {
                if (word[0] == PlusSign)
                    _plusCommandWords.Add(word.Substring(1));
                else if (word[0] == MinusSign)
                    _minusCommandWords.Add(word.Substring(1));
                else
                    _noSignCommandWords.Add(word);
            }
        }

        private HashSet<string> FindDocs(char sign)
        {
            var wordsDocs = new HashSet<string>();
            var commandWords = (sign == PlusSign ? _plusCommandWords :
                sign == MinusSign ? _minusCommandWords : _noSignCommandWords);
            foreach (var word in commandWords)
            {
                wordsDocs.UnionWith(_invertedIndex.GetWordDocs(word));
            }
            return wordsDocs;
        }
        public HashSet<string> Filter(string[] commandWords)
        {
            SplitCommandWords(commandWords);
            var plusCommandWordsDocs = FindDocs(PlusSign);
            var minusCommandWordsDocs = FindDocs(MinusSign);
            var noSignCommandWordsDocs = FindDocs(NoSign);

            var result = new HashSet<string>();
            if (noSignCommandWordsDocs.Contains(null))
            {
                return result;
            }

            result = plusCommandWordsDocs;
            result.IntersectWith(noSignCommandWordsDocs);
            //result.RemoveWhere(MinusCommandWordsDocsContains);
            return result;
        }
    }
}