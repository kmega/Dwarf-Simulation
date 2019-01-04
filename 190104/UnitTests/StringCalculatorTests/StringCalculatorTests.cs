using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorNS;
using System;

namespace StringCalculatorTestNS
{
    [TestClass]
    public class StringCalculatorTests
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void GivenStringIsEmptyThenResult0()
        {
            var result = _stringCalculator.Add("");
            var expected = 0;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GivenStringHas1ThenResult1()
        {
            var result = _stringCalculator.Add("1");
            var expected = 1;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GivenStringHas12ThenResult3()
        {
            var result = _stringCalculator.Add("1,2");
            var expected = 3;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GivenStringHas1n2ThenResult6()
        {
            var result = _stringCalculator.Add("1\n2,3");
            var expected = 6;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void GivenStringHasDifferentDelimiterThenResult3()
        {
            var result = _stringCalculator.Add("//;\n1;2");
            var expected = 3;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "negatives not allowed")]
        public void GivenStringHasNegativeNumberThenThrowExeption()
        {
            _stringCalculator.Add("-2");
        }
    }
}
