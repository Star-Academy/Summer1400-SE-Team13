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

        private void SplitCommandWordsBySign(string[] commandWords)
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

        private HashSet<string> FindDocs(char wordsSign)
        {
            var wordsDocs = new HashSet<string>();
            var commandWords = (wordsSign == PlusSign ? _plusCommandWords :
                wordsSign == MinusSign ? _minusCommandWords : _noSignCommandWords);
            foreach (var word in commandWords)
            {
                HashSet<string> wordDocs = _invertedIndex.GetWordDocs(word);
                if (wordDocs != null)
                {
                    if (wordsSign == PlusSign || wordsSign == MinusSign)
                    {
                        wordsDocs.UnionWith(wordDocs);
                    }
                    else
                    {
                        if (wordsDocs.Count > 0)
                        {
                            wordsDocs.IntersectWith(wordDocs);
                        }
                        else
                        {
                            wordsDocs.UnionWith(wordDocs);
                        }
                    }
                }
                    
            }
            return wordsDocs;
        } 
        public HashSet<string> Filter(string[] commandWords)
        {
            SplitCommandWordsBySign(commandWords);
            var plusCommandWordsDocs = FindDocs(PlusSign);
            var minusCommandWordsDocs = FindDocs(MinusSign);
            var noSignCommandWordsDocs = FindDocs(NoSign);
            var result = new HashSet<string>();
            if (_noSignCommandWords.Count > 0 && noSignCommandWordsDocs.Contains(null))
            {
                return result;
            }
            result = (plusCommandWordsDocs.Count > 0? plusCommandWordsDocs: noSignCommandWordsDocs);
            if (_noSignCommandWords.Count > 0)
            {
                result.IntersectWith(noSignCommandWordsDocs);
                result.UnionWith(noSignCommandWordsDocs);
            }
            foreach (var word in minusCommandWordsDocs)
            {
                result.Remove(word);
            }
            return result;
        }
    }
}