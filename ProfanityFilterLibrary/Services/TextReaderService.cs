using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextReaderService : ITextReaderService
    {
        private ITextReplaceLogic _textReplacer;
        private string _text;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public ITextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }
        public TextReaderService(string text)
        {
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(Logger);
            _text = text;
        }

        public void ValidateProfanity()
        {
            TextReplacer.ReplaceCurseWordsInText();
        }

        public void LoadText()
        {
            TextReplacer.FilterTextLogic.TextModel.OriginalText = _text;
        }
    }
}
