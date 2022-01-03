using ProfanityFilterLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class TextReplaceFactory
    {
        public static ITextReplaceLogic CreateTextReplaceLogic(ITextModel textModel)
        {
            return new TextReplaceLogic(FilterTextFactory.CreateFilterTextLogic(textModel));
        }
        public static ITextReplaceLogic CreateTextReplaceLogic(string textContent)
        {
            return new TextReplaceLogic(FilterTextFactory.CreateFilterTextLogic(textContent));
        }
    }
}
