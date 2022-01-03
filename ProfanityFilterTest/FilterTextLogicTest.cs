using NUnit.Framework;
using ProfanityFilterLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ProfanityFilterTest.FilterTextLogicTest
{
    public class Tests
    {
        FilterTextLogic _filterTextLogic;
        [SetUp]
        public void Setup()
        {
            _filterTextLogic = new FilterTextLogic(new TextModel());
        }

        [Test]
        public void FindCursedWords()
        {

            //Arrange
            _filterTextLogic.TextModel.OriginalText = "this is bullshit";
            
            int exptectedAmount = 1;

            //Act
            int CursedWordAmount = _filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(exptectedAmount, CursedWordAmount);
        }

        [Test]
        public void ValidateEmptyWord()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "";
            int expectedAmount = 0;

            //Act
            int ActualWordAmount = _filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void ValidateNonCursedWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "there nothing in this sentence";
            int expectedAmount = 0;

            //Act
            int ActualWordAmount = _filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void ValidateSentenceWithNoSpaceWithCurseWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "thisiscrap";
            int expectedAmount = 1;

            //Act
            int ActualWordAmount = _filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }

        [Test]
        public void CheckSentenceWithSameCurseWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "this is crap crap crap";
            int expectedAmount = 3;

            //Act
            int ActualWordAmount = _filterTextLogic.FindSumOfAllCurseWords();

            //Assert
            Assert.AreEqual(expectedAmount, ActualWordAmount);
        }


        [Test]
        public void FindMatchesOfOneCurseWord()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "this is crap";
            List<string> expectedCurseWords = new() { "crap" };

            //Act
            List<string> ActualCursedWords = _filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindMatchesOfCurseWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "this is crap and shit";
            List<string> expectedCurseWords = new() { "crap", "shit" };

            //Act
            List<string> ActualCursedWords = _filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindNonMatchesOfCurseWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "this is nice";
            List<string> expectedCurseWords = new();

            //Act
            List<string> ActualCursedWords = _filterTextLogic.FindCursedWords();

            //Assert
            CollectionAssert.AreEqual(expectedCurseWords, ActualCursedWords);
        }

        [Test]
        public void FindListOfMostUsedCurseWords()
        {
            //Arrange
            _filterTextLogic.TextModel.OriginalText = "there's alot of shit shit shit in this sentence, but not alot of bullshit bullshit. Tho i have to bitch bitch bitch bitch alot";
            Dictionary<string, int> ExpectedAmountOfCurseWords = new()
            {
                { "bitch", 4 },
                { "shit", 3 },
                { "bullshit", 2 }
            };

            //Act
            IDictionary<string, int> ActualAmountOfCurseWords = _filterTextLogic.ListOfMostUsedCurseWords();

            //Assert
            Assert.IsTrue(ExpectedAmountOfCurseWords.SequenceEqual(ActualAmountOfCurseWords));
        }
    }
}