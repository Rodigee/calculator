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
            var formula = "1,300";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("301", result);
        }

        [TestMethod]
        public void CalculateSum_OneNegativeNumberAndOnePositive_ThrowExceptionListingNegativeNumber()
        {
            // Arrange
            var formula = "4,-3.1";

            // Act
            // Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => calculator.CalculateSum(formula));
            Assert.IsTrue(ex.Message.Contains("-3.1"));
        }

        [TestMethod]
        public void CalculateSum_TwoNegativeNumbers_ThrowExceptionListingNegativeNumbers()
        {
            // Arrange
            var formula = "-14,-3";

            // Act
            // Assert
            var ex = Assert.ThrowsException<ArgumentException>(() => calculator.CalculateSum(formula));
            Assert.IsTrue(ex.Message.Contains("-14"));
            Assert.IsTrue(ex.Message.Contains("-3"));
        }

        [TestMethod]
        public void CalculateSum_NumbersWithDecimals_AddsNumbers()
        {
            // Arrange
            var formula = "1.24,500.1,1,1,200.1";

            // Act
            var result = calculator.CalculateSum(formula);
            // Assert
            Assert.AreEqual("703.44", result);
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
            var formula = "ty,5,ty,10,,aerd";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("15", result);
        }

        [TestMethod]
        public void CalculateSum_NewLineSeparators_ReturnSum()
        {
            // Arrange
            var formula = "1\n2\n9\narg";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("12", result);
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

        [TestMethod]
        public void CalculateSum_NumberIsGreaterThan1000_ReturnZero()
        {
            // Arrange
            var formula = "1001";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalculateSum_SomesNumbersAreGreaterThan1000_IgnoreNumbersGreaterThanZero()
        {
            // Arrange
            var formula = "1000.1,6,4,2000";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsOneCharacterCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//#\n2#5";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsCommaCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//,\n2,ff,100";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("102", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsNewLineCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//\n\n2\nff\n100";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("102", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsNumberCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//9\n29ff9100";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("102", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsSingleCharacterCustomAndCommaAndNewLineDelimiters_ReturnSum()
        {
            // Arrange
            var formula = "//t\n2t100\n1,1";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("104", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsMultiCharacterCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//[***]\n11***22***33";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("66", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsMultiNumberCustomDelimiter_ReturnSum()
        {
            // Arrange
            var formula = "//[123]\n111232212333";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("66", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsMultiCharacterCustomAndCommaAndNewLineDelimiters_ReturnSum()
        {
            // Arrange
            var formula = "//[z1z]\n2z1z100\n1,1";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("104", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsSingleCharacterCustomDelimiterOfLeftSqureBracket_ReturnSum()
        {
            // Arrange
            var formula = "//[\n2[100";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("102", result);
        }

        [TestMethod]
        public void CalculateSum_FormulaContainsBlankMultiCharacterCustomDelimiter_ReturnNumber()
        {
            // Arrange
            var formula = "//[]\n210";

            // Act
            var result = calculator.CalculateSum(formula);

            // Assert
            Assert.AreEqual("210", result);
        }
    }
}
