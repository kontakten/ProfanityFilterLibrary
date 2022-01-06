using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class TextReplaceFactory
    {

        public static ITextReplaceLogic CreateTextReplaceLogic(ITextModel textModel)
        {
            return new TextReplaceLogic(textModel);
        }
    }
}
