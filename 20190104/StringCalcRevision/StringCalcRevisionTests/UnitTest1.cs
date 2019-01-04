using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalcRevision;

namespace StringCalcRevisionTests
{
    [TestClass]
    public class StringCalc
    {
        [TestMethod]
        public void Return0WhenStringIsEmpty()
        {
            //given
            string value = "";
            string[] delimiter = null;

            //expected 
            int expected = 0;

            //when
            int result = new Calculator().Add(value, delimiter);

            //then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns0WhenNoNumberInString()
        {
            //given
            string value = "abs";
            string[] delimiter = { "," };

            //expected 
            int expected = 0;

            //when
            int result = new Calculator().Add(value, delimiter);

            //then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReturnsResultsWhenNumberInString()
        {
            //given
            string value = "abs32,ff3";
            string[] delimiter = { "," };

            //expected 
            int expected = 35;

            //when
            int result = new Calculator().Add(value, delimiter);

            //then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReturnsResultsWhenNumberInStringWhenMultilne()
        {
            //given
            string value = "abs32,f\nf3";
            string[] delimiter = { ",", Environment.NewLine };

            //expected 
            int expected = 35;

            //when
            int result = new Calculator().Add(value, delimiter);

            //then
            Assert.AreEqual(expected, result);
        }

    }
}
