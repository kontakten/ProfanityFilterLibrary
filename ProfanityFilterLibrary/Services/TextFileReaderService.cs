using System.IO;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextFileReaderService : ITextReaderService
    {
        private ITextReplaceLogic _textReplacer;

        private string _filePath;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public ITextReplaceLogic TextReplacer
        {
            get { return _textReplacer; }
            private set { _textReplacer = value; }
        }

        public TextFileReaderService(string filepath)
        {
            _filePath = filepath;
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
                using var reader = File.OpenText(_filePath);
                TextReplacer.FilterTextLogic.TextModel.OriginalText = await reader.ReadToEndAsync();
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
            Task task = Task.Run(() => LoadTextAsync());
            task.Wait();
        }
    }
}
