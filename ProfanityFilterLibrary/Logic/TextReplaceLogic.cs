using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal class TextReplaceLogic : ITextReplaceLogic
    {
        readonly IFilterTextLogic _filterTextLogic;
        private string _originalText;
        private string _replacedText;

        public string OriginalText
        {
            get { return _originalText; }
            set { _originalText = value; }
        }

        public string ReplacedText
        {
            get { return _replacedText; }
            set { _replacedText = value; }
        }

        public TextReplaceLogic(IFilterTextLogic filterTextLogic)
        {
            _filterTextLogic = filterTextLogic;
            _originalText = filterTextLogic.TextContent;
        }
        private List<string> FindCurseWordsToReplace()
        {
            List<string> CursedWords = _filterTextLogic.FindCursedWords();

            return CursedWords;
        }

        public string ReplaceCurseWordsInText()
        {
            List<string> CursedWords = FindCurseWordsToReplace();

            _replacedText = _originalText;

            foreach (var word in CursedWords)
            {
                _replacedText = Regex.Replace(_replacedText, @$"\b{word}\b", ReplaceCursedWordToSafeWord(word));
            }

            return _replacedText;
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
