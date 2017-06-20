using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interesting.Tests
{
    [TestClass]
    public class ReverseStringWithStacksTests
    {
        private const string Category = "Reverse String";
        private ReverseStringWithStacks _reverseStrategy;

        [TestInitialize]
        public void Init()
        {
            _reverseStrategy = new ReverseStringWithStacks();
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenStringIsNullOrEmptyMustReturnTheSame()
        {
            //
            // Act
            //
            var result = _reverseStrategy.Get("cat and dog", ' ');
            //
            // Assert
            //
            Assert.AreEqual(result, "tac dna god");
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenThereExistsLeadingDelimeterMustReturnTheSame()
        {
            //
            // Act
            //
            var result = _reverseStrategy.Get(" cat and dog", ' ');
            //
            // Assert
            //
            Assert.AreEqual(result, " tac dna god");
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenThereExistsTrailingDelimeterMustReturnTheSame()
        {
            //
            // Act
            //
            var result = _reverseStrategy.Get("cat and dog ", ' ');
            //
            // Assert
            //
            Assert.AreEqual(result, "tac dna god ");
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenThereExistsPunctuationMarksMustReturnTheSame()
        {
            //
            // Act
            //
            var result = _reverseStrategy.Get(@"cat and, 'dog!", ' ');
            //
            // Assert
            //
            Assert.AreEqual(result, "tac ,dna !god'");
        }
    }
}