using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary.Services
{
    internal class TextReaderService : ITextReaderService
    {
        private ITextReplaceLogic _textReplacer;
        private string _text;
        public ITextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }
        public TextReaderService(string text)
        {
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic();
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
