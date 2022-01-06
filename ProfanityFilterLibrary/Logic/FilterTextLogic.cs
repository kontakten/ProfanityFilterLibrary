using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProfanityFilterLibrary
{
    public class FilterTextLogic : IFilterTextLogic
    {
        #region Privates

        private readonly string _curseWordsPattern = @"shit|fuck|cock|bitch|bullshit|crap|pussy|nigger|asshole|dick|dickface";
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private ITextModel _textModel;

        #endregion

        #region Properties
        public ITextModel TextModel
        {
            get { return _textModel; }
            set { _textModel = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor which injects TextModel, and Logger.
        /// </summary>
        /// <param name="textModel">Interface of TextModel</param>
        /// <param name="logger">Logger</param>
        public FilterTextLogic(ITextModel textModel)
        {
            _textModel = textModel;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// public void method - to find list of most used curse words
        /// </summary>
        public IDictionary<string, int> FindListOfMostUsedCurseWords()
        {
            Dictionary<string, int> AmountOfCurseWords = new Dictionary<string, int>();

            try
            {
                foreach (var curseWord in _curseWordsPattern.Split('|'))
                {
                    int amountOfCurseWordUsed = Regex.Matches(_textModel.OriginalText.ToLower(), @$"{curseWord}").Count;

                    if (amountOfCurseWordUsed <= 0) continue;

                    AmountOfCurseWords.Add(curseWord, amountOfCurseWordUsed);
                }

                return AmountOfCurseWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (ArgumentNullException ex)
            {
                Logger.Log(NLog.LogLevel.Error, "", ex);
                return AmountOfCurseWords;
            }
            catch (ArgumentException ex)
            {
                return AmountOfCurseWords;
            }
            catch (Exception ex)
            {
                return AmountOfCurseWords;
            }
        }

        /// <summary>
        /// public void method - to find a sum of alle curse words
        /// </summary>
        public int FindSumOfAllCurseWords()
        {
            try
            {   
                return Regex.Matches(_textModel.OriginalText.ToLower(), _curseWordsPattern).Count;
            }
            catch (ArgumentNullException)
            {
                return 0;
            }
            catch (ArgumentException)
            {
                return 0;
            }
        }

        /// <summary>
        /// public method which returns a list of strings. The list of strings are all the cursewords from textmodels original text property.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCurseWordsList()
        {
            List<string> cursedWords = new();
            
            try
            {
                MatchCollection matches = Regex.Matches(_textModel.OriginalText.ToLower(), _curseWordsPattern);

                cursedWords = matches.Cast<Match>().Select(match => match.Value).ToList();

                return cursedWords;
            }
            catch (ArgumentNullException)
            {
                return cursedWords;
            }
            catch (ArgumentException)
            {
                return cursedWords;
            }

        }

        #endregion
    }
}
