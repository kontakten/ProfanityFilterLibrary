using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal class TextFileModel : ITextModel
    {
        public IDictionary<string, int> AmountOfCurseWords { get; set; }
        public string OriginalText { get; set; }
        public string ReplacedText { get; set; }
        public int SumOfAllCurseWords { get; set; }
        public string Title { get; set; }
    }
}
