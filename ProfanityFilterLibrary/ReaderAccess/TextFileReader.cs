using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal class TextFileReader : ITextReader
    {
        private ITextModel _textModel;
        private string _filePath;
        public TextFileReader(ITextModel textModel, string path)
        {
            _textModel = textModel;
            _filePath = path;
        }

        public async Task ReadText()
        {
            using var reader = File.OpenText(_filePath);
            _textModel.OriginalText = await reader.ReadToEndAsync();
        }

    }
}
