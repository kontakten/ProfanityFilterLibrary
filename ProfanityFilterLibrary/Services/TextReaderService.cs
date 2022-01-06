using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class TextReaderService
    {
        #region Privates

        private ITextReplaceLogic _textReplacer;
        private Stream _fileStream;
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
        /// <param name="filestream"></param>
        public TextReaderService(Stream filestream)
        {
            _fileStream = filestream;
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(TextModelFactory.CreateTextModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profanityText"></param>
        public TextReaderService(string profanityText)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task ReadTextAsync()
        {
            try
            {
                using var StreamReader = new StreamReader(_fileStream, Encoding.UTF8);
                _textReplacer.TextModel.OriginalText = await StreamReader.ReadToEndAsync();
            }
            catch (System.UnauthorizedAccessException)
            {

            }
            catch (FileNotFoundException ex)
            {
                Logger.Error(ex, "Error: File not found");
            }
        }
        #endregion
    }
}
