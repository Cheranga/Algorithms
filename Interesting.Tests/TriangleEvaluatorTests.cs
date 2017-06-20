using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interesting.Tests
{
    [TestClass]
    public class TriangleEvaluatorTests
    {
        private const string Category = "Triangle Evaluator";

        [TestCategory(Category)]
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void MustFailWhenThereAreNoTriangleCriteriasDefined()
        {
            //
            // Arrange, Act, Assert
            //
            var evaluator = new TriangleEvaluator(null);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void MustFailWhenOneOrMoreNegativeSidesAreProvided()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new[]
            {
                new EquilateralTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(5, 6, -1);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Error, triangleType);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void MustFailWhenOneOrMoreZeroSidesAreProvided()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new[]
            {
                new EquilateralTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(5, 0, -1);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Error, triangleType);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void TriangleTypeMustBeScaleneWhenProvidedCorrectInput()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new[]
            {
                new ScaleneTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(5, 6, 7);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Scalene, triangleType);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void TriangleTypeMustBeIsoscelesWhenProvidedCorrectInput()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new[]
            {
                new IsoscelesTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(5, 5, 7);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Isoceles, triangleType);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void TriangleTypeMustBeEquilateralWhenProvidedCorrectInput()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new[]
            {
                new EquilateralTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(6, 6, 6);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Equilateral, triangleType);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenThereAreOneOrMoreMatchingCriteriasTheFirstSelectedMustReturn()
        {
            //
            // Arrange
            //
            var evaluator = new TriangleEvaluator(new ITriangleCriteria[]
            {
                new IsoscelesTriangle(),
                new EquilateralTriangle()
            });
            //
            // Act
            //
            var triangleType = evaluator.GetTriangleType(6, 6, 6);
            //
            // Assert
            //
            Assert.AreEqual(TriangleType.Isoceles, triangleType);
        }
    }
}