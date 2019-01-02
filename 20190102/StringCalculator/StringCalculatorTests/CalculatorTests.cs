using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
namespace StringCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;
        [TestInitialize]
        public void initCalculator()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void shouldReturn0WhenStringIsEmpty()
        {
            int expected = 0;
            int actual = calculator.Add("");
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void shouldReturn1WhenStringContentIs1()
        {
            int expected = 1;
            int actual = calculator.Add("1");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldReturn2WhenStringContentIs2()
        {
            int expected = 2;
            int actual = calculator.Add("2");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldReturnNumberWhenStringContentIsSingleNumber()
        {
            int expected = 20;
            int actual = calculator.Add("20");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void shouldReturn3WhenStringContentIs2And1()
        {
            int expected = 3;
            int actual = calculator.Add("2,1");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldReturn10WhenStringContentIs5And3And2()
        {
            int expected = 10;
            int actual = calculator.Add("5,3,2");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldReturn10WhenStringContainsNewLineCharacterAsNumberSeparator()
        {
            int expected = 10;
            int actual = calculator.Add("5\n3\n2");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void shouldAddNumbersWhenStringContainsCommaAndNewLineCharacterAsNumberSeparator()
        {
            int expected = 25;
            int actual = calculator.Add("5\n3\n2,5\n10");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldThrowFormatExceptionWhenTwoNumberSeparatorsAreNextToEachOther()
        {
            Assert.ThrowsException<System.FormatException>(() => calculator.Add("1,\n"));
        }

    }
}