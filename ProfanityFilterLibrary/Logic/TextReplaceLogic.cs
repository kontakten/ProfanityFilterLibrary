using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfanityFilterLibrary
{
    public class TextReplaceLogic : ITextReplaceLogic
    {
        #region Privates

        private IFilterTextLogic _filterTextLogic;
        private ITextModel _textModel;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        #endregion

        #region Properties
        public ITextModel TextModel
        {
            get { return _textModel; }
            set { _textModel = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor which injects Textmodel.
        /// </summary>
        /// <param name="filterTextLogic"></param>
        public TextReplaceLogic(ITextModel textModel)
        {
            _filterTextLogic = FilterTextFactory.CreateFilterTextLogic(textModel);
            _textModel = _filterTextLogic.TextModel;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// private static method which returns a string of a curseword which is replaced by * in between - to filter the word.
        /// </summary>
        /// <param name="curseWord">a curse word which need to be handled</param>
        /// <returns></returns>
        private static string ReplaceCursedWordToSafeWord(string curseWord)
        {
            StringBuilder replacedWord = new();

            for (int i = 0; i < curseWord.Length; i++)
            {
                replacedWord.Append(i > 0 && i < curseWord.Length - 1 ? curseWord.Substring(i, 1).Replace(curseWord[i].ToString(), "*") : curseWord[i]);
            }

            return replacedWord.ToString();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// public method which handles 
        /// </summary>
        public void ReplaceCurseWordsInText()
        {
            List<string> CursedWords = _filterTextLogic.GetCurseWordsList();

            _textModel.ReplacedText = _textModel.OriginalText;

            foreach (var word in CursedWords)
            {
                _filterTextLogic.TextModel.ReplacedText = Regex.Replace(_filterTextLogic.TextModel.ReplacedText, @$"{word}", ReplaceCursedWordToSafeWord(word));
            }

            _textModel.AmountOfCurseWords = _filterTextLogic.FindListOfMostUsedCurseWords();
            _textModel.SumOfAllCurseWords = _filterTextLogic.FindSumOfAllCurseWords();
        }
        #endregion

    }
}
