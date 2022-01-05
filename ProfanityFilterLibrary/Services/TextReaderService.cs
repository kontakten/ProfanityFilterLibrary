using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextReaderService
    {
        private ITextReplaceLogic _textReplacer;

        private Stream _fileStream;
        private string _text;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public ITextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }

        public TextReaderService(Stream filestream)
        {
            _fileStream = filestream;
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(Logger);
        }
        public TextReaderService(string text)
        {
            _text = text;
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(Logger);
        }
        public async Task LoadTextAsync()
        {
            await ReadTextAsync();
        }

        public void ValidateProfanity()
        {
            TextReplacer.ReplaceCurseWordsInText();
        }

        private async Task ReadTextAsync()
        {
            try
            {
                using var sr = new StreamReader(_fileStream, Encoding.UTF8);
                TextReplacer.FilterTextLogic.TextModel.OriginalText = await sr.ReadToEndAsync();
            }
            catch (System.UnauthorizedAccessException)
            {

            }
            catch (FileNotFoundException ex)
            {
                Logger.Error(ex, "Error: File not found");
            }
        }
        public void LoadText()
        {
            TextReplacer.FilterTextLogic.TextModel.OriginalText = _text;
        }
    }
}
