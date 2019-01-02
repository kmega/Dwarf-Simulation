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
        [TestMethod]
        public void ShouldReturnSumOf2Numbers()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("3lkasdhas,8");
            //Assert
            Assert.AreEqual(11, result);
        }
        [TestMethod]
        public void ShouldReturnSumOf3Numbers()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("3lkasdhas,8,9");
            //Assert
            Assert.AreEqual(20, result);
        }
        [TestMethod]
        public void ShouldReturnSumOf3BigNumbers()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("3lkasdhas,8,98");
            //Assert
            Assert.AreEqual(109, result);
        }
        [TestMethod]
        public void ShouldReturnSumOf3NumbersWhenGiven4Num()
        {
            //Arrange
            var stringCalculator = new Calculator();
            //Act
            var result = stringCalculator.Add("3lkasdhas,8,98,11");
            //Assert
            Assert.AreEqual(109, result);
        }
    }
}
