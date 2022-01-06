using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public class ProfanityFileReaderService : IProfanityReaderService
    {
        #region Privates

        private ITextReplaceLogic _textReplacer;
        private string _filePath;
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
        public ProfanityFileReaderService(string filePath)
        {
            _textReplacer = TextReplaceFactory.CreateTextReplaceLogic(TextModelFactory.CreateTextModel());
            _filePath = filePath;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task ValidateProfanity()
        {
            await ReadText();
            _textReplacer.ReplaceCurseWordsInText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task ReadText()
        {
            if (File.Exists(_filePath))
                try
                {
                    try
                    {
                        using var reader = File.OpenText(_filePath);
                        TextReplacer.TextModel.OriginalText = await reader.ReadToEndAsync();
                    }
                    catch (System.UnauthorizedAccessException)
                    {

                    }
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
