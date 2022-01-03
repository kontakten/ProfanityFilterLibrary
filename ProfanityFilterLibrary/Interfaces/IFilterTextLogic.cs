using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public interface IFilterTextLogic
    {
        public ITextModel TextModel { get; set; }
        List<string> FindCursedWords();
        void FindSumOfAllCurseWords();
        public void ListOfMostUsedCurseWords();
    }
}