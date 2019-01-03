using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using UnitTestProject2;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calc = new Calculator();

        [TestMethod]
        public void ShouldReturn0Becuse0()
        {
           
            int result = calc.Sum("0");
            Assert.AreEqual(0, result);
            
        }
        [TestMethod]
        public void ShouldReturn0Becuseempty()
        {

            int result = calc.Sum("");
            Assert.AreEqual(0, result);

        }
        [TestMethod]
        public void ShouldReturn3Becuse1and2()
        {

            int result = calc.Sum("2 1");
            Assert.AreEqual(3, result);

        }
        [TestMethod]
        public void ShouldReturnGoodFromManyDiffrentChars()
        {

            int result = calc.Sum("a v ok 2 1 7 93 5 3");
            Assert.AreEqual(111, result);

        }
        [TestMethod]
        public void ShouldReturnGoodWithnextline()
        {

            int result = calc.Sum("3\n4,+okkkk kkk3");
            Assert.AreEqual(10, result);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Nie wolno używać liczb ujemnych ")]

        public void ShouldReturnGException()
        {

            int result = calc.Sum("3\n-4,+okkkk kkk3");
         
        }






    }
}
