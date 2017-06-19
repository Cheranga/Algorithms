using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interesting.Tests
{
    [TestClass]
    public class ReverseStringWithStacksTests
    {
        private ReverseStringWithStacks _reverseStrategy;

        [TestInitialize]
        public void Init()
        {
            _reverseStrategy = new ReverseStringWithStacks();
        }

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
