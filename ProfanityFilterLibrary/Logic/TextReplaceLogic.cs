using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfanityFilterLibrary
{
    public class TextReplaceLogic : ITextReplaceLogic
    {
        private IFilterTextLogic _filterTextLogic;
        public IFilterTextLogic FilterTextLogic
        {
            get { return _filterTextLogic; }
            set { _filterTextLogic = value; }
        }

        public TextReplaceLogic(IFilterTextLogic filterTextLogic)
        {
            _filterTextLogic = filterTextLogic;
        }

        private List<string> FindCurseWordsToReplace()
        {
            List<string> CursedWords = _filterTextLogic.FindCursedWords();

            return CursedWords;
        }

        public void ReplaceCurseWordsInText()
        {
            List<string> CursedWords = FindCurseWordsToReplace();

            _filterTextLogic.TextModel.ReplacedText = _filterTextLogic.TextModel.OriginalText;

            foreach (var word in CursedWords)
            {
                _filterTextLogic.TextModel.ReplacedText = Regex.Replace(_filterTextLogic.TextModel.ReplacedText, @$"\b{word}\b", ReplaceCursedWordToSafeWord(word));
            }

            _filterTextLogic.ListOfMostUsedCurseWords();
            _filterTextLogic.FindSumOfAllCurseWords();
        }

        private static string ReplaceCursedWordToSafeWord(string curseWord)
        {
            StringBuilder replacedWord = new();

            for (int i = 0; i < curseWord.Length; i++)
            {
                replacedWord.Append(i > 0 && i < curseWord.Length - 1 ? curseWord.Substring(i, 1).Replace(curseWord[i].ToString(), "*") : curseWord[i]);
            }

            return replacedWord.ToString();
        }

    }
}
