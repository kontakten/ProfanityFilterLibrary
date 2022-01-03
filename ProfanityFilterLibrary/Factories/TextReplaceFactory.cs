using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class TextReplaceFactory
    {
        public static ITextReplaceLogic CreateTextReplaceLogic()
        {
            return new TextReplaceLogic(FilterTextFactory.CreateFilterTextLogic());
        }
    }
}
