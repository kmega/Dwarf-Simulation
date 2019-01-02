using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace stringCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturn0WhenStringIsEmpty()
        {
            //given
            var stringCalc = new StringCalc();

            //when
            int result = stringCalc.Add("");

            //then
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldReturn1WhenStringIs1()
        {
            //given
            var stringCalc = new StringCalc();

            //when
            int result = stringCalc.Add("1");

            //then
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ShouldReturn5WhenAdd3To2()
        {
            //given
            var stringCalc = new StringCalc();

            //when
            int result = stringCalc.Add("3,2");

            //then
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ShouldReturn9WhenAdd3To3To3()
        {
            //given
            var stringCalc = new StringCalc();

            //when
            int result = stringCalc.Add("3,3,3");

            //then
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void ShouldReturn6WhenAdd1NewLineTo2To3()
        {
            //given
            var stringCalc = new StringCalc();

            //when
            int result = stringCalc.Add("1\n2,3");

            //then
            Assert.AreEqual(6, result);
        }

        

    }
}
