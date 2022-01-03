using System;

namespace ConsoleTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\coNta\Desktop\profanity.txt";

            ProfanityFilterLibrary.ITextReaderService textFileReader = new ProfanityFilterLibrary.TextFileReaderService(path);

            Console.WriteLine($"Loading File: {path}");

            textFileReader.LoadText();

            Console.WriteLine($"Original Text: {textFileReader.TextReplacer.FilterTextLogic.TextModel.OriginalText}");

            Console.WriteLine($"Validating profanity....");

            textFileReader.ValidateProfanity();

            Console.WriteLine($"Replaced Text: {textFileReader.TextReplacer.FilterTextLogic.TextModel.ReplacedText}");

            Console.WriteLine($"Curse Words in total: {textFileReader.TextReplacer.FilterTextLogic.TextModel.SumOfAllCurseWords}");

            Console.WriteLine($"Most used curse word:");

            foreach (var curseWord in textFileReader.TextReplacer.FilterTextLogic.TextModel.AmountOfCurseWords)
            {
                Console.WriteLine($"Word: {curseWord.Key} - Amount used: {curseWord.Value}");
            }

            Console.ReadKey();
        }
    }
}
