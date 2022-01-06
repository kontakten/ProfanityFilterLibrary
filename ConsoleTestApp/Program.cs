using System;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal class Program
    {
        private static ProfanityFilterLibrary.IProfanityReaderService _textFileReaderService;
        static async Task Main(string[] args)
        {
            
            string path = "bandeord.txt";

            _textFileReaderService = ProfanityFilterLibrary.TextReaderServiceFactory.CreateFileReaderService(path);
            
            Console.WriteLine($"Original Text: {_textFileReaderService.TextReplacer.TextModel.OriginalText}");

            Console.WriteLine($"Validating profanity....");

            await _textFileReaderService.ValidateProfanity();

            Console.WriteLine($"Replaced Text: {_textFileReaderService.TextReplacer.TextModel.ReplacedText}");

            Console.WriteLine($"Curse Words in total: {_textFileReaderService.TextReplacer.TextModel.SumOfAllCurseWords}");

            Console.WriteLine($"Most used curse word:");

            foreach (var curseWord in _textFileReaderService.TextReplacer.TextModel.AmountOfCurseWords)
            {
                Console.WriteLine($"Word: {curseWord.Key} - Amount used: {curseWord.Value}");
            }

            Console.ReadKey();
            
        }
    }
}
