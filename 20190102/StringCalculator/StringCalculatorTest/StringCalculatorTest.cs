using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void ShouldReturn0WhenNumberIs0()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("0");
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ShouldReturn3WhenNumberIs3()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("3");
            //Assert
            Assert.AreEqual(3, result);
        }
    }
}
