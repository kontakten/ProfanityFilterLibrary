using NUnit.Framework;
using ProfanityFilterLibrary;
using System.Collections.Generic;

namespace ProfanityFilterTest.ReplaceTextLogicTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindReplacedCurseWord()
        {
            //Arrange
            ITextReplaceLogic textReplaceLogic = TextReplaceFactory.CreateTextReplaceLogic("Hello mate i'm shit");

            string expectedText = "Hello mate i'm s**t";

            //Act
            string result = textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void FindReplacedCurseWordsWhichAreTheSameCurseWord()
        {
            //Arrange
            ITextReplaceLogic textReplaceLogic = TextReplaceFactory.CreateTextReplaceLogic("Hello mate i'm shit shit shit");

            string expectedText = "Hello mate i'm s**t s**t s**t";

            //Act
            string result = textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void FindReplacedCurseWords()
        {
            //Arrange
            ITextReplaceLogic textReplaceLogic = TextReplaceFactory.CreateTextReplaceLogic("Hello mate i'm shit fuck bullshit");

            string expectedText = "Hello mate i'm s**t f**k b******t";

            //Act
            string result = textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }
    }
}
