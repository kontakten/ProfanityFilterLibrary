using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public interface IFilterTextLogic
    {
        public ITextModel TextModel { get; set; }
        List<string> GetCurseWordsList();
        void FindSumOfAllCurseWords();
        public void FindListOfMostUsedCurseWords();
    }
}