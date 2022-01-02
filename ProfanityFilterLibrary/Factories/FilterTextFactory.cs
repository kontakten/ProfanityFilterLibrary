﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class FilterTextFactory
    {
        public static IFilterTextLogic CreateFilterTextLogic(string textcontent)
        {
            return new FilterTextLogic(textcontent);
        }
    }
}
