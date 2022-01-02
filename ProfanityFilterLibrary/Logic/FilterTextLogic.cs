using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal class FilterTextLogic : IFilterTextLogic
    {
        private readonly string _curseWordsPattern = @"shit|fuck|cock|bitch|bullshit|crap";
        private string _textContent;

        public string TextContent
        {
            get { return _textContent; }
            set { _textContent = value; }
        }
        public FilterTextLogic(string textcontent)
        {
            _textContent = textcontent;
        }

        public Dictionary<string ,int> ListOfMostUsedCurseWords()
        {
            Dictionary<string, int> mostUsedCurseWords = new();

            foreach (var curseWord in _curseWordsPattern.Split('|'))
            {
                int amountOfCurseWordUsed = Regex.Matches(_textContent.ToLower(), @$"\b{curseWord}\b").Count;
                
                if (amountOfCurseWordUsed <= 0) continue;

                mostUsedCurseWords.Add(curseWord, amountOfCurseWordUsed);
            }

            return mostUsedCurseWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public int FindSumOfAllCurseWords()
        {
            try
            {
                return Regex.Matches(_textContent.ToLower(), _curseWordsPattern).Count;
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

        public List<string> FindCursedWords()
        {
            List<string> cursedWords = new();

            try
            {
                MatchCollection matches = Regex.Matches(_textContent.ToLower(), _curseWordsPattern);
                
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
    }
}
