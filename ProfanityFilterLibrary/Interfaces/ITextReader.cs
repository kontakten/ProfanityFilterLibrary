using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public interface ITextReader
    {
        public TextReplaceLogic TextReplacer { get; set; }
        public void LoadTextFromFileAsync();
    }
}
