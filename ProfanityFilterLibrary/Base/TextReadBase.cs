using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public abstract class TextReadBase
    {
        public abstract ITextReplaceLogic TextReplacer { get; set; }
        public abstract void LoadText();
        public abstract void ValidateProfanity();
    }
}
