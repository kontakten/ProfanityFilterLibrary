using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class ProfanityTextReaderService
    {
        #region Privates

        private ITextReplaceLogic _textReplacer;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        public ITextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profanityText"></param>
        public ProfanityTextReaderService(string profanityText)
        {
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(TextModelFactory.CreateTextModel());
            _textReplacer.TextModel.OriginalText = profanityText;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void ValidateProfanity()
        {
            _textReplacer.ReplaceCurseWordsInText();
        }
        #endregion
    }
}
