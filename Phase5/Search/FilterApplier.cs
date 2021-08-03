using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phase5
{
    public class FilterApplier
    {
        private IInvertedIndex _invertedIndex;
        private HashSet<string> PlusCommandWords;
        private HashSet<string> MinusCommandWords;
        private HashSet<string> NoSignCommandWords;

        private readonly char PLUS_SIGN = '+';
        private readonly char MINUS_SIGN = '-';
        private readonly char NO_SIGN = ' ';
        public FilterApplier(IInvertedIndex invertedIndex)
        {
            _invertedIndex = invertedIndex;
            PlusCommandWords = new HashSet<string>();
            MinusCommandWords = new HashSet<string>();
            NoSignCommandWords = new HashSet<string>();
        }

        private void SplitCommandWords(string[] commandWords)
        {
            foreach (string word in commandWords) {
                if (word[0] == PLUS_SIGN)
                    PlusCommandWords.Add(word.Substring(1));
                else if (word[0] == MINUS_SIGN)
                    MinusCommandWords.Add(word.Substring(1));
                else
                    NoSignCommandWords.Add(word);
            }
        }

        private HashSet<string> FindDocs(char sign)
        {
            HashSet<string> wordsDocs = new HashSet<string>();
            HashSet<string> commandWords = (sign == PLUS_SIGN ? PlusCommandWords :
                sign == MINUS_SIGN ? MinusCommandWords : NoSignCommandWords);
            foreach (var word in commandWords)
            {
                wordsDocs.UnionWith(_invertedIndex.GetWordDocs(word));
            }
            return wordsDocs;
        }
        public HashSet<string> Filter(string[] commandWords)
        {
            SplitCommandWords(commandWords);
            HashSet<string> plusCommandWordsDocs = FindDocs(PLUS_SIGN);
            HashSet<string> minusCommandWordsDocs = FindDocs(MINUS_SIGN);
            HashSet<string> noSignCommandWordsDocs = FindDocs(NO_SIGN);

            HashSet<string> result = new HashSet<string>();
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