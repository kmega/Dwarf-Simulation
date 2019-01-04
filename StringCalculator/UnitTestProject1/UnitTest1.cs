using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTest
    {
        public int Input(string value)
        {
            Calculator calculator = new Calculator();
            return calculator.Add(value);
        }

        [TestMethod]
        public void Return0WhenStringIs0()
        {
            string value = "0";
            int expectedValue = 0;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Return0WhenStringIsEmpty()
        {
            string value = "";
            int expectedValue = 0;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Return1WhenStringIs1()
        {
            string value = "1";
            int expectedValue = 1;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Return2WhenStringIs2()
        {
            string value = "2";
            int expectedValue = 2;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Return3WhenStringIs1Comma2()
        {
            string value = "1,2";
            int expectedValue = 3;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void Return6WhenStringIs1NewLine2Comma3()
        {
            string value = "1\n2,3";
            int expectedValue = 6;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }


        [TestMethod]
        public void Return3WhenStringHasNewDelimiter()
        {
            string value = "//;\n1;2";
            int expectedValue = 3;

            int result = Input(value);

            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
    "Error")]
        public void ThrowExepctionNegative()
        {
            string value = "-1,2,3";

            int result = Input(value);

        }

    }
}
