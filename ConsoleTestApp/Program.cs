using System;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\coNta\Desktop\profanity.txt";

            ProfanityFilterLibrary.TextFileReaderService textFileReader = new ProfanityFilterLibrary.TextFileReaderService(path);
            
            Console.WriteLine($"Loading File: {path}");

            textFileReader.LoadTextFromFileAsync();

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
