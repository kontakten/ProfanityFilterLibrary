using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public interface ITextModel
    {
        IDictionary<string, int> AmountOfCurseWords { get; set; }
        string OriginalText { get; set; }
        string ReplacedText { get; set; }
        int SumOfAllCurseWords { get; set; }
    }
}