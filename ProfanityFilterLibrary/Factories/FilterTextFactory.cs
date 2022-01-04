using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class FilterTextFactory
    {
        public static IFilterTextLogic CreateFilterTextLogic(NLog.Logger logger)
        {
            return new FilterTextLogic(TextModelFactory.CreateTextModel(), logger);
        }
        public static IFilterTextLogic CreateFilterTextLogic()
        {
            return new FilterTextLogic(TextModelFactory.CreateTextModel());
        }
    }
}
