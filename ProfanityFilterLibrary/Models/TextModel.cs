using System.Collections.Generic;

namespace ProfanityFilterLibrary
{
    public class TextModel : ITextModel
    {
        public string OriginalText { get; set; }
        public string Title { get; set; }
        public string ReplacedText { get; set; }
        public int SumOfAllCurseWords { get; set; } = 0;
        public IDictionary<string, int> AmountOfCurseWords { get; set; } = new Dictionary<string, int>();
    }
}
