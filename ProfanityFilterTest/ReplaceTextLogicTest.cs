using NUnit.Framework;
using ProfanityFilterLibrary;
using System.Collections.Generic;

namespace ProfanityFilterTest.ReplaceTextLogicTest
{
    public class Tests
    {
        private TextReplaceLogic _textReplaceLogic;

        [SetUp]
        public void Setup()
        {
            _textReplaceLogic = new TextReplaceLogic(new FilterTextLogic(new TextModel()));
        }

        [Test]
        public void FindReplacedCurseWord()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit";

            string expectedText = "Hello mate i'm s**t";

            //Act
            string result = _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void FindReplacedCurseWordsWhichAreTheSameCurseWord()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit shit shit";

            string expectedText = "Hello mate i'm s**t s**t s**t";

            //Act
            string result = _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void FindReplacedCurseWords()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit fuck bullshit";

            string expectedText = "Hello mate i'm s**t f**k b******t";

            //Act
            string result = _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, result);
        }
    }
}
