using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public interface IFilterTextLogic
    {
        ITextModel TextModel { get; set; }
        List<string> GetCurseWordsList();
        int FindSumOfAllCurseWords();
        IDictionary<string, int> FindListOfMostUsedCurseWords();
    }
}