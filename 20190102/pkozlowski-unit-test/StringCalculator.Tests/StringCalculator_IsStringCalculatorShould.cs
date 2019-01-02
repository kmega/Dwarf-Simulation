using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Test
{
    public class StringCalculator_IsStringCalculatorShould
    {
        [TestClass]
        public class StringCalculator_IsSum3WhenNumbersAre12_Test
        {
            private readonly StringCalculator _stringCalculator;

            public StringCalculator_IsSum3WhenNumbersAre12_Test()
            {
                _stringCalculator = new StringCalculator();
            }

            [TestMethod]
            public void ShouldReturn3WhenNumbersAre12()
            {
                var result = _stringCalculator.Add("1,2");
                var expectedResult = 3;

                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            public void ShouldReturnNumberWhenStringIsSingleNumber()
            {
                var result = _stringCalculator.Add("2");
                var expectedResult = 2;

                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            public void ShouldReturn0WhenEmpty()
            {
                var result = _stringCalculator.Add("");
                var expectedResult = 0;

                Assert.AreEqual(expectedResult, result);
            }

            [TestMethod]
            public void ShouldReturn6WhenHaveNewLines()
            {
                var result = _stringCalculator.Add("1\n2,3");
                var expectedResult = 6;

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}