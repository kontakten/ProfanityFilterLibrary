using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProfanityFilterLibrary
{
    public class FilterTextLogic : IFilterTextLogic
    {

        private readonly string _curseWordsPattern = @"shit|fuck|cock|bitch|bullshit|crap";
        private ITextModel _textModel;

        public ITextModel TextModel
        {
            get { return _textModel; }
            set { _textModel = value; }
        }

        public FilterTextLogic(ITextModel textModel)
        {
            _textModel = textModel;
        }

        public void ListOfMostUsedCurseWords()
        {
            _textModel.AmountOfCurseWords = new Dictionary<string, int>();

            foreach (var curseWord in _curseWordsPattern.Split('|'))
            {
                int amountOfCurseWordUsed = Regex.Matches(_textModel.OriginalText.ToLower(), @$"\b{curseWord}\b").Count;

                if (amountOfCurseWordUsed <= 0) continue;

                _textModel.AmountOfCurseWords.Add(curseWord, amountOfCurseWordUsed);
            }

            _textModel.AmountOfCurseWords = _textModel.AmountOfCurseWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public void FindSumOfAllCurseWords()
        {
            try
            {
                _textModel.SumOfAllCurseWords = Regex.Matches(_textModel.OriginalText.ToLower(), _curseWordsPattern).Count;
            }
            catch (ArgumentNullException)
            {

            }
            catch (ArgumentException)
            {

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
