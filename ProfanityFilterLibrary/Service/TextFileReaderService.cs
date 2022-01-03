using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextFileReaderService
    {
        private TextReplaceLogic _textReplacer;
        
        private string _filePath;

        public TextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }

        public TextFileReaderService(string filepath)
        {
            _filePath = filepath;

            TextReplacer = new TextReplaceLogic(new FilterTextLogic(new TextModel()));
        }

        public void LoadTextFromFileAsync()
        {
            ReadTextAsync();
        }

        public void ValidateProfanity()
        {
            TextReplacer.ReplaceCurseWordsInText();
            
        }

        private void ReadTextAsync()
        {
            using var reader = File.OpenText(_filePath);
            TextReplacer.TextModel.OriginalText = reader.ReadToEnd();
        }

    }
}
