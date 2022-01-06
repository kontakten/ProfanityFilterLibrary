using System;
using System.IO;

namespace ConsoleTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string profanityText = "shit this is shitty fuck";

            ProfanityFilterLibrary.TextReaderService textFileReader = new (profanityText);
            
            Console.WriteLine($"Original Text: {textFileReader.TextReplacer.TextModel.OriginalText}");

            Console.WriteLine($"Validating profanity....");

            textFileReader.ValidateProfanity();

            Console.WriteLine($"Replaced Text: {textFileReader.TextReplacer.TextModel.ReplacedText}");

            Console.WriteLine($"Curse Words in total: {textFileReader.TextReplacer.TextModel.SumOfAllCurseWords}");

            Console.WriteLine($"Most used curse word:");

            foreach (var curseWord in textFileReader.TextReplacer.TextModel.AmountOfCurseWords)
            {
                Console.WriteLine($"Word: {curseWord.Key} - Amount used: {curseWord.Value}");
            }

            Console.ReadKey();
            
        }
    }
}
