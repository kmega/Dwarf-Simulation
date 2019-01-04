using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalc;
namespace StringCalcTests
{
    [TestClass]
    public class StringCalcTest
    {
        private void TestAddMethod(string input, int expected)
        {
            int result = StringCalculator.Add(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturn0WhenGiven0()
        {
            int expected = 0;
            string input = "";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf2Numbers()
        {
            int expected = 4;
            string input = "1,3";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOf5Numbers()
        {
            int expected = 16;
            string input = "1,3,5,6,1";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldReturnSumOfNumbersInMultipleLines()
        {
            int expected = 5;
            string input = "1\n3,1";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldReturn5DifferentDelimeter()
        {
            int expected = 5;
            string input = "//[-]\n1-3-1";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldReturn5DifferentLongDelimeter()
        {
            int expected = 5;
            string input = "//[***]\n1***3***1";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        public void ShouldIgnoreBigNumbers()
        {
            int expected = 2;
            string input = "//[-]\n1-10000-1";
            TestAddMethod(input, expected);
        }
        [TestMethod]
        [ExpectedException(typeof (Exception), "Negatives are not allowed -3")]
        public void ShouldGetException()
        {
            int expected = 5;
            string input = "-3,2,5";
            TestAddMethod(input, expected);
        }
    }
}
