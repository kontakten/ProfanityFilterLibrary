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
        IProfanityReaderService _textReaderService;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task FindCursedWords()
        {
            //Arrange
            _textReaderService = TextReaderServiceFactory.CreateTextReaderService("shit");

            //Act
            await _textReaderService.ValidateProfanity();

            //Assert
        }
    }
}
