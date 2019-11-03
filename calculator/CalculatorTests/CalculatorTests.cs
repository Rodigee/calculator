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
        public void CalculateSum_OneNumber_ReturnNumber()
        {
            // Arrange
            var formula = "20";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("20", result);
        }

        [TestMethod]
        public void CalculateSum_TwoNumbers_AddNumbers()
        {
            // Arrange
            var formula = "1,5000";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("5001", result);
        }

        [TestMethod]
        public void CalculateSum_OneNegativeNumberAndOnePositive_AddNumbers()
        {
            // Arrange
            var formula = "4,-3";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void CalculateSum_TwoNegativeNumbers_AddNumbers()
        {
            // Arrange
            var formula = "-14,-3";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("-17", result);
        }

        [TestMethod]
        public void CalculateSum_FiveNumbersWithMixedSigns_AddsNumbers()
        {
            // Arrange
            var formula = "1,5000,1,1,-2000";

            // Act
            var result = calculator.CalculateSum(formula);
            // Assert
            Assert.AreEqual("3003", result);
        }

        [TestMethod]
        public void CalculateSum_SevenNumbers_AddsNumbers()
        {
            // Arrange
            var formula = "1,2,3,4,5,6,7,8,9,10,11,12";

            // Act
            var result = calculator.CalculateSum(formula);
            // Assert
            Assert.AreEqual("78", result);
        }

        [TestMethod]
        public void CalculateSum_EmptyInput_ReturnZero()
        {
            // Arrange
            var formula = "";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateSum_NullInput_ReturnZero()
        {
            // Arrange
            // Act
            var result = calculator.CalculateSum(null);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateSum_InvalidInput_ReturnZero()
        {
            // Arrange
            var formula = "ty";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateSum_TwoInvalidInputs_ReturnZero()
        {
            // Arrange
            var formula = "ty,ty";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateSum_InvalidInputAndValidInput_ReturnOnlyValidInput()
        {
            // Arrange
            var formula = "ty,5";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void CalculateSum_MultipleInvalidAndValidInputs_ReturnOnlyValidInput()
        {
            // Arrange
            var formula = "ty,5,ty,10,-20,,aerd";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("-5", result);
        }

        [TestMethod]
        public void CalculateSum_NewLineSeparators_ReturnSum()
        {
            // Arrange
            var formula = "1\n2\n-9\narg";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("-6", result);
        }

        [TestMethod]
        public void CalculateSum_NewLineAndCommaSeparators_ReturnSum()
        {
            // Arrange
            var formula = "1\n2,3";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("6", result);
        }
    }
}
