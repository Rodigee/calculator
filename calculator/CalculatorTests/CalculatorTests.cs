using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator.Calculator calculator;

        [TestInitialize]
        public void Init()
        {
            calculator = new Calculator.Calculator();
        }

        [TestMethod]
        public void CalculateFormula_OneNumber_ReturnNumber()
        {
            // Arrange
            var formula = "20";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("20", result);
        }

        [TestMethod]
        public void CalculateFormula_TwoNumbers_AddNumbers()
        {
            // Arrange
            var formula = "1,5000";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("5001", result);
        }

        [TestMethod]
        public void CalculateFormula_OneNegativeNumberAndOnePositive_AddNumbers()
        {
            // Arrange
            var formula = "4,-3";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void CalculateFormula_TwoNegativeNumbers_AddNumbers()
        {
            // Arrange
            var formula = "-14,-3";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("-17", result);
        }

        [TestMethod]
        public void CalculateFormula_MoreThanTwoNumbers_ThrowException()
        {
            // Arrange
            var formula = "1,5000,1";

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => calculator.CalculateFormula(formula));
        }

        [TestMethod]
        public void CalculateFormula_EmptyInput_ReturnZero()
        {
            // Arrange
            var formula = "";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateFormula_NullInput_ReturnZero()
        {
            // Arrange
            // Act
            var result = calculator.CalculateFormula(null);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateFormula_InvalidInput_ReturnZero()
        {
            // Arrange
            var formula = "ty";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateFormula_TwoInvalidInputs_ReturnZero()
        {
            // Arrange
            var formula = "ty,ty";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateFormula_InvalidInputAndValidInput_ReturnOnlyValidInput()
        {
            // Arrange
            var formula = "ty,5";

            // Act
            var result = calculator.CalculateFormula(formula);

            // Assert
            Assert.AreEqual("5", result);
        }
    }
}
