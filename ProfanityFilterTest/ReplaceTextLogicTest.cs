using NUnit.Framework;
using ProfanityFilterLibrary;
using System.Collections.Generic;

namespace ProfanityFilterTest.ReplaceTextLogicTest
{
    public class Tests
    {
        private ITextReplaceLogic _textReplaceLogic;

        [SetUp]
        public void Setup()
        {
            _textReplaceLogic = TextReplaceFactory.CreateTextReplaceLogic(TextModelFactory.CreateTextModel());
        }

        [Test]
        public void FindReplacedCurseWord()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit";

            string expectedText = "Hello mate i'm s**t";

            //Act
            _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, _textReplaceLogic.TextModel.ReplacedText);
        }

        [Test]
        public void FindReplacedCurseWordsWhichAreTheSameCurseWord()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit shit shit";

            string expectedText = "Hello mate i'm s**t s**t s**t";

            //Act
            _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, _textReplaceLogic.TextModel.ReplacedText);
        }

        [Test]
        public void FindReplacedCurseWords()
        {
            //Arrange
            _textReplaceLogic.TextModel.OriginalText = "Hello mate i'm shit fuck bullshit";

            string expectedText = "Hello mate i'm s**t f**k bulls**t";

            //Act
            _textReplaceLogic.ReplaceCurseWordsInText();

            //Assert
            Assert.AreEqual(expectedText, _textReplaceLogic.TextModel.ReplacedText);
        }
    }
}
