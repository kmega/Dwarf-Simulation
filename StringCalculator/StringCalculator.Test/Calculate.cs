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

            int result = calculator.Calculate(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnValueWhenParseIsTrue()
        {
            //Given
            var calculator = new Calculator();
            string value = "6";
            int expectedResult = int.Parse(value);

            //when

            int result = calculator.Calculate(value);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionIfValueParseIsFalse()
        {
            //Given
            var calculator = new Calculator();
            string value = "sdgds";

            //when

            int result = calculator.Calculate(value);

        }

        [TestMethod]
        public void ShouldReturn0WhenFirstNumberAndSecondNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "";
            string value2 = "";
            int expectedResult = 0;

            //when

            int result = calculator.Calculate(value1, value2);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSecondNumberWhenFirstNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "";
            string value2 = "4";
            int expectedResult = int.Parse(value2);

            //when

            int result = calculator.Calculate(value1, value2);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnFirstNumberWhenSecondNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "5";
            string value2 = "";
            int expectedResult = int.Parse(value1);

            //when

            int result = calculator.Calculate(value1, value2);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnFirstNumbersWhenOnlySecondNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "4";
            string value2 = "";
            int expectedResult = int.Parse(value1 + value2);

            //when

            int result = int.Parse(value1);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSecondNumbersWhenOnlyFirstNumberIsEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "";
            string value2 = "47";
            int expectedResult = int.Parse(value1 + value2);

            //when

            int result = int.Parse(value2);

            //then
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void ShouldReturnSumNumbers()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "6";
            string value2 = "8";
            int expectedResult = int.Parse(value1) + int.Parse(value2);

            //when

            int result = calculator.Calculate(value1, value2);

            //then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionIfFirstOrSecondNumbersParseIsFalseAndNotEmpty()
        {
            //Given
            var calculator = new Calculator();
            string value1 = "dhd";
            string value2 = "457";

            //when
            int result = calculator.Calculate(value1, value2);

        }

    } 
}
