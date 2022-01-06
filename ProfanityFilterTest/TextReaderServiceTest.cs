using NUnit.Framework;
using ProfanityFilterLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfanityFilterTest.TextReaderServiceTest
{
    public class Test
    {
        ProfanityTextReaderService _textReaderService;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FindCursedWords()
        {
            //Arrange
            _textReaderService = new ProfanityTextReaderService("shit");

            //Act
            _textReaderService.ValidateProfanity();

            //Assert
            
        }
    }
}
