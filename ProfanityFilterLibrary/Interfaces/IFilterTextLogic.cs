using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public interface IFilterTextLogic
    {
        string TextContent { get; set; }

        List<string> FindCursedWords();
        int FindSumOfAllCurseWords();

        public Dictionary<string, int> ListOfMostUsedCurseWords();
    }
}