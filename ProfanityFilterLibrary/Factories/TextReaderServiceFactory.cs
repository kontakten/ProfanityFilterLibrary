using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public static class TextReaderServiceFactory
    {
        public static IProfanityReaderService CreateTextReaderService(string profanityText)
        {
            return new ProfanityTextReaderService(profanityText);
        }
        public static IProfanityReaderService CreateFileReaderService(string filepath)
        {
            return new ProfanityFileReaderService(filepath);
        }
        public static IProfanityReaderService CreateStreamReaderService(Stream stream)
        {
            return new ProfanityStreamReaderService(stream);
        }
    }
}
