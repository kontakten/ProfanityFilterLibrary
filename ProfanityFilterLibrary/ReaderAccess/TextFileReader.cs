using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextFileReader : ITextReader
    {
        private TextReplaceLogic _textReplacer;
        
        private string _filePath;

        public TextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            set { _textReplacer = value; }
        }

        public TextFileReader(string filepath)
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
