using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator.Test
{
    [TestClass]
    public class CalculateTest
    {
        [TestMethod]
        public void ShouldReturn0WhenNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value = "";
            int expectedResult = 0;

            //when

            int result = calculator.Add(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenNumbersAreSplitByComa()
        {
            //Given
            var calculator = new Calculator();
            string value = "1,4,5";
            int expectedResult = 10;

            //when

            int result = calculator.Add(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenNumbersAreSplitByNewLine()
        {
            //Given
            var calculator = new Calculator();
            string value = "1\n2,3";
            int expectedResult = 6;

            //when

            int result = calculator.Add(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenNumbersAreSplitByDelimiter()
        {
            //Given
            var calculator = new Calculator();
            string value = "//;;;;\n2,3";
            int expectedResult = 5;

            //when

            int result = calculator.Add(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenNumberAreNegative()
        {
            //Given
            var calculator = new Calculator();
            string value = "sdgdfhdfg";

            //when

            int result = calculator.Add(value);
        }

        [TestMethod]
        public void ShouldReturnSumIgnoringNumberBiggerThan1000()
        {
            //Given
            var calculator = new Calculator();
            string value = "//[;;;;]\n,1002,\n,2";
            int expectedResult = 2;

            //when

            int result = calculator.Add(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }

    } 
}
