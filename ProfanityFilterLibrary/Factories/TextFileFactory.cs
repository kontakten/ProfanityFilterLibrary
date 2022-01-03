using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class TextFileFactory
    {
        public static ITextModel CreateTextModel()
        {
            return new TextModel();
        }
    }
}
