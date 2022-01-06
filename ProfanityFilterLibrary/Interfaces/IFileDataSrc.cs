using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    internal interface IFileDataSrc
    {
        FileStream Open(string path,
                   FileMode mode,
                   FileAccess access,
                   FileShare share);
    }
}
