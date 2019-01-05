using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;
using System;

namespace StringCalculatorKataTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void ShouldReturn0WhenStringIsEmpty()
        {
            //Given
            string numbers = "";
            int expected = 0;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumForTwoOrOneNumbers()
        {
            //Given
            string numbers = "1,5";
            int expected = 6;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumForUnknownAmount()
        {
            //Given
            string numbers = "1,5,7,4";
            int expected = 17;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenIsNewLine()
        {
            //Given
            string numbers = "1\n5,7,4";
            int expected = 17;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenDelimiterIsUnknown()
        {
            //Given
            string numbers = "//;\n15;7;4";
            int expected = 26;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ShouldThrowExceptionWhenNumberIsNegative()
        {
            //Given
            string numbers = "-1,5,6";

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);
        }
        [TestMethod]
        public void ShouldReturnSumHavingNumbersBiggerThan1000()
        {
            //Given
            string numbers = "//;\n15;7;4000";
            int expected = 22;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenDelimiterHaveDifferentLength()
        {
            //Given
            string numbers = "//[;;;]\n15;;;7;;;4000";
            int expected = 22;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnSumWhenIsMultipleDelimiters()
        {
            //Given
            string numbers = "//[;;;][%%%]\n15;;;7%%%4000";
            int expected = 22;

            //when
            StrincCalculator calc = new StrincCalculator();
            int result = calc.Add(numbers);


            //then
            Assert.AreEqual(expected, result);
        }
    }
}
