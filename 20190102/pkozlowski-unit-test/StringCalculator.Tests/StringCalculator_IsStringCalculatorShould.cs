using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Test
{
    public class StringCalculator_IsStringCalculatorShould
    {
        [TestClass]
        public class StringCalculator_IsReturn0WhenNumberIs0_Test
        {
            private readonly StringCalculator _stringCalculator;

            public StringCalculator_IsReturn0WhenNumberIs0_Test()
            {
                _stringCalculator = new StringCalculator();
            }

            [TestMethod]
            public void ShouldReturn0WhenNumberIs0()
            {
                var result = -_stringCalculator.GetSum(0);
                var expectedResult = 0;

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}