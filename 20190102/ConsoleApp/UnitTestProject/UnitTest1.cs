using System;
using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnExWhenValueIsErrorString()
        {
            var calculator = new StringCalculator();
            int result = calculator.Calculate("dasddsa");
                      
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldReturnExWhenBothValuesAreErrorStrings()
        {
            var calculator = new StringCalculator();
            int result = calculator.Calculate("dasddsa","dsadaads");

        }
              

        [TestMethod]

        public void ShouldReturn0WhenValueIsEmptyString()
        {
            //given
            var calculator = new StringCalculator();
            //when
            int result = calculator.Calculate("");
            //then
            Assert.AreEqual(0, result);
        }

        [TestMethod]

        public void ShouldReturnValueWhenValueIsSingleString()
        {
            //given
            var calculator = new StringCalculator();

            //when
            int result = calculator.Calculate("5");

            //then
            Assert.AreEqual(5, result);
        }

        [TestMethod]

        public void ShouldReturnValuesSumWhenTwoValuesAreString()
        {
            //given
            var calculator = new StringCalculator();

            //when
            int result = calculator.Calculate("3","4");

            //then
            Assert.AreEqual(7, result);
        }

        [TestMethod]

        public void ShouldReturnSumWhenOneOfTwoValuesisEmptyString()
        {
            //given
            var calculator = new StringCalculator();

            //when
            int result = calculator.Calculate("", "54");

            //then
            Assert.AreEqual(54, result);
        }

        [TestMethod]

        public void ShouldReturn0WhenTwoOfTwoValuesAreEmptyString()
        {
            //given
            var calculator = new StringCalculator();

            //when
            int result = calculator.Calculate("","");

            //then
            Assert.AreEqual(0, result);
           
        }

        
    }
}
