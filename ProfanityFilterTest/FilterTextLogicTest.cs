using NUnit.Framework;
using ProfanityFilterLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ProfanityFilterTest.FilterTextLogicTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindCursedWords()
        {

            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("this is bullshit");
            int exptectedAmount = 1;

            //Act
            int CursedWordAmount = filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(exptectedAmount, CursedWordAmount);
        }

        [Test]
        public void ValidateEmptyWord()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("");
            int expectedAmount = 0;

            //Act
            int ActualWordAmount = filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void ValidateNonCursedWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("there nothing in this sentence");
            int expectedAmount = 0;

            //Act
            int ActualWordAmount = filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void ValidateSentenceWithNoSpaceWithCurseWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("thisiscrap");
            int expectedAmount = 1;

            //Act
            int ActualWordAmount = filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void CheckSentenceWithSameCurseWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("this is crap crap crap");
            int expectedAmount = 3;

            //Act
            int ActualWordAmount = filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }


        [Test]
        public void FindMatchesOfOneCurseWord()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("this is crap");
            List<string> expectedCurseWords = new() { "crap" };

            //Act
            List<string> ActualCursedWords = filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindMatchesOfCurseWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("this is crap and shit");
            List<string> expectedCurseWords = new() { "crap", "shit" };

            //Act
            List<string> ActualCursedWords = filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindNonMatchesOfCurseWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("this is nice");
            List<string> expectedCurseWords = new();

            //Act
            List<string> ActualCursedWords = filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindListOfMostUsedCurseWords()
        {
            //Arrange
            IFilterTextLogic filterTextLogic = FilterTextFactory.CreateFilterTextLogic("there's alot of shit shit shit in this sentence, but not alot of bullshit bullshit. Tho i have to bitch bitch bitch bitch alot");
            Dictionary<string, int> ExpectedAmountOfCurseWords = new()
            {
                { "bitch", 4 },
                { "shit", 3 },
                { "bullshit", 2 }
            };

            //Act
            Dictionary<string, int> ActualAmountOfCurseWords = filterTextLogic.ListOfMostUsedCurseWords();

            //ExpectedAmountOfCurseWords = ExpectedAmountOfCurseWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //Assert
            Assert.IsTrue(ExpectedAmountOfCurseWords.SequenceEqual(ActualAmountOfCurseWords));
        }
    }
}