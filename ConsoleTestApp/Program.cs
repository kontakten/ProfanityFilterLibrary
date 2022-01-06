using System;

namespace ConsoleTestApp
{
    internal class Program
    {
        private static ProfanityFilterLibrary.ProfanityFileReaderService _textFileReader;
        static void Main(string[] args)
        {
            
            string path = "bandeord.txt";

            _textFileReader = new (path);
            
            Console.WriteLine($"Original Text: {_textFileReader.TextReplacer.TextModel.OriginalText}");

            Console.WriteLine($"Validating profanity....");

            _textFileReader.ValidateProfanity();

            Console.WriteLine($"Replaced Text: {_textFileReader.TextReplacer.TextModel.ReplacedText}");

            Console.WriteLine($"Curse Words in total: {_textFileReader.TextReplacer.TextModel.SumOfAllCurseWords}");

            Console.WriteLine($"Most used curse word:");

            foreach (var curseWord in _textFileReader.TextReplacer.TextModel.AmountOfCurseWords)
            {
                Console.WriteLine($"Word: {curseWord.Key} - Amount used: {curseWord.Value}");
            }

            Console.ReadKey();
            
        }
    }
}
