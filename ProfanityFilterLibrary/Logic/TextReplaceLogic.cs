using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextReplaceLogic : ITextReplaceLogic
    {
        readonly IFilterTextLogic _filterTextLogic;
        private ITextModel _textModel;
        public ITextModel TextModel
        {
            get { return _textModel; }
            set { _textModel = value; }
        }

        public TextReplaceLogic(IFilterTextLogic filterTextLogic)
        {
            _filterTextLogic = filterTextLogic;
            _textModel = filterTextLogic.TextModel;
        }

        private List<string> FindCurseWordsToReplace()
        {
            List<string> CursedWords = _filterTextLogic.FindCursedWords();

            return CursedWords;
        }

        public string ReplaceCurseWordsInText()
        {
            List<string> CursedWords = FindCurseWordsToReplace();

            _textModel.ReplacedText = _textModel.OriginalText;

            foreach (var word in CursedWords)
            {
                _textModel.ReplacedText = Regex.Replace(_textModel.ReplacedText, @$"\b{word}\b", ReplaceCursedWordToSafeWord(word));
            }

            _textModel.AmountOfCurseWords = _filterTextLogic.ListOfMostUsedCurseWords();
            _textModel.SumOfAllCurseWords = _filterTextLogic.FindSumOfAllCurseWords();

            return _textModel.ReplacedText;
        }

        private static string ReplaceCursedWordToSafeWord(string curseWord)
        {
            StringBuilder replacedWord = new ();

            for (int i = 0; i < curseWord.Length; i++)
            {
                replacedWord.Append(i > 0 && i < curseWord.Length - 1 ? curseWord.Substring(i, 1).Replace(curseWord[i].ToString(), "*") : curseWord[i]);
            }

            return replacedWord.ToString();
        }

    }
}
