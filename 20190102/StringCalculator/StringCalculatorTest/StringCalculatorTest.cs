using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        private void TestCalculatorAdding(string input, int expected)
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add(input);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Negative numbers are not allowed: -2 ")]
        public void ShouldReturnException()
        {
            string input = "-2,4hsa7";
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add(input);
        }
        [TestMethod]
        public void ShouldReturn0WhenNumberIs0()
        {
            string input = "0";
            int expected = 0;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturn3WhenNumberIs3()
        {
            string input = "3";
            int expected = 3;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf2Numbers()
        {
            string input = "3lkasdhas,8";
            int expected = 11;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf3Numbers()
        {
            string input = "3lkasdhas,8,9";
            int expected = 20;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf3BigNumbers()
        {
            string input = "3lkasdhas,8,98";
            int expected = 109;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf5Numbers()
        {
            string input = "3lkasdhas,8,98,11,15";
            int expected = 135;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturn0WhenEmptyStringIsSent()
        {
            string input = "";
            int expected = 0;
            TestCalculatorAdding(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumWhenMultipleLinesAreSent()
        {
            string input = "3,kass8\n6";
            int expected = 17;
            TestCalculatorAdding(input, expected);
        }
    }
}
