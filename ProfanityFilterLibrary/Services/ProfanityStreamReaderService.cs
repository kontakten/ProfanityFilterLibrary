using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class ProfanityStreamReaderService
    {
        #region Privates

        private ITextReplaceLogic _textReplacer;
        private Stream _stream;
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
        public ProfanityStreamReaderService(Stream stream)
        {
            _stream = stream;
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(TextModelFactory.CreateTextModel());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task ValidateProfanity()
        {
            await ReadTextAsync(); 
            _textReplacer.ReplaceCurseWordsInText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task ReadTextAsync()
        {
            try
            {
                using var StreamReader = new StreamReader(_stream, Encoding.UTF8);
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
