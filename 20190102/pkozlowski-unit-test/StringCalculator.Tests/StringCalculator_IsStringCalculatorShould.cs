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
        }
    }
}