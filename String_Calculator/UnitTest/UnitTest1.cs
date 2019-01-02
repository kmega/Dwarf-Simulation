using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Calculator;

namespace UnitTest
{

    [TestClass]
    public class StringCalculatorTest
    {
        public int Calculate(string value)
        {
            var calculator = new Calculator();
            int result = calculator.Add(value);
            return result;
        }

        [TestMethod]
        public void ShouldReturn0WhenStringIs0()
        {         
            string value = "0";
            int expectedResult = 0;

            int result = Calculate(value);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn1WhenStringIs1()
        {
            string value = "1";
            int expectedResult = 1;

            int result = Calculate(value);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn2WhenStringIs2()
        {
            string value = "2";
            int expectedResult = 2;

            int result = Calculate(value);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn3WhenStringAre1And2()
        {
            string value = "1,2";
            int expectedResult = 3;

            int result = Calculate(value);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn0WhenStringIsEpmpty()
        {
            string value = "";
            int expectedResult = 0;

            int result = Calculate(value);
            Assert.AreEqual(expectedResult, result);
        }


    }
}
