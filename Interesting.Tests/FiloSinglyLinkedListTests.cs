using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interesting.Tests
{
    [TestClass]
    public class FiloSinglyLinkedListTests
    {
        private const string Category = "Singly Linked List";

        [TestCategory(Category)]
        [TestMethod]
        public void AddingAnItemToAnEmptyListMustBeSuccessful()
        {
            //
            // Arrange
            //
            var list = new FiloSinglyLinkedList<int>();
            //
            // Act
            //
            list.Add(1);
            //
            // Assert
            //
            Assert.AreEqual(list[0], 1);
        }

        [TestCategory(Category)]
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void WhenTheListIsEmptyAccessingViaIndexerMustFail()
        {
            //
            // Arrange
            //
            var list = new FiloSinglyLinkedList<int>();
            //
            // Act
            //
            var data = list[0];
        }

        [TestCategory(Category)]
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void WhenNegativeIndexProvidedAccessingViaIndexerMustFail()
        {
            //
            // Arrange
            //
            var list = new FiloSinglyLinkedList<int>();
            //
            // Act
            //
            var data = list[-1];
        }

        [TestCategory(Category)]
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void WhenIndexIsGreaterThanCountAccessingViaIndexerMustFail()
        {
            //
            // Arrange
            //
            var list = new FiloSinglyLinkedList<int>();
            //
            // Act
            //
            list.Add(1);

            var data = list[1];
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenThereIsOnlyOneEntityAccessingItViaIndexerMustBeSuccessful()
        {
            //
            // Arrange
            //
            var list = new FiloSinglyLinkedList<int>();
            //
            // Act
            //
            list.Add(1);

            var data = list[0];
            //
            // Assert
            //
            Assert.AreEqual(1, data);
        }
    }
}