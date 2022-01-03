using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal class FilterTextLogic : IFilterTextLogic
    {
        
        private readonly string _curseWordsPattern = @"shit|fuck|cock|bitch|bullshit|crap";
        private ITextModel _textModel;

        public ITextModel TextModel
        {
            get { return _textModel; }
            set { _textModel = value; }
        }
        public FilterTextLogic()
        {
            
        }
        public FilterTextLogic(ITextModel textModel)
        {
            _textModel = textModel;
        }

        public FilterTextLogic(string textContent)
        {
            _textModel = TextFileFactory.CreateTextModel();
            _textModel.OriginalText = textContent;
            _textModel.ReplacedText = textContent;
        }

        public IDictionary<string ,int> ListOfMostUsedCurseWords()
        {
            _textModel.AmountOfCurseWords = new Dictionary<string ,int>();

            foreach (var curseWord in _curseWordsPattern.Split('|'))
            {
                int amountOfCurseWordUsed = Regex.Matches(_textModel.OriginalText.ToLower(), @$"\b{curseWord}\b").Count;
                
                if (amountOfCurseWordUsed <= 0) continue;

                _textModel.AmountOfCurseWords.Add(curseWord, amountOfCurseWordUsed);
            }

            return _textModel.AmountOfCurseWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public int FindSumOfAllCurseWords()
        {
            try
            {
                _textModel.SumOfAllCurseWords = Regex.Matches(_textModel.OriginalText.ToLower(), _curseWordsPattern).Count;
                return _textModel.SumOfAllCurseWords;
            }
            catch (ArgumentNullException)
            {
                return 0;
            }
            catch (ArgumentException)
            {
                return 0;
            }
        }

        public List<string> FindCursedWords()
        {
            List<string> cursedWords = new();

            try
            {
                MatchCollection matches = Regex.Matches(_textModel.OriginalText.ToLower(), _curseWordsPattern);
                
                cursedWords = matches.Cast<Match>().Select(match => match.Value).ToList();

                return cursedWords;
            }
            catch (ArgumentNullException)
            {
                return cursedWords;
            }
            catch (ArgumentException)
            {
                return cursedWords;
            }

        }
    }
}
