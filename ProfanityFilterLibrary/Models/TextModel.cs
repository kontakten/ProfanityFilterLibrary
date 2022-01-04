using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public class TextModel : ITextModel
    {
        public string OriginalText { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ReplacedText { get; set; } = string.Empty;
        public int SumOfAllCurseWords { get; set; } = 0;
        public IDictionary<string, int> AmountOfCurseWords { get; set; } = new Dictionary<string, int>();
    }
}
