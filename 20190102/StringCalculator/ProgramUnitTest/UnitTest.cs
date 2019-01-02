using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgramUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Return0When0()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("0");
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Return7When7()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("7");
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void Return3When1And2()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Return7When3And4()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("3,4");
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void Return100When10And20And30And40()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("10,20,30,40");
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void Return100WhenNewLineIsUsed()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("10\n20\n30\n40");
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void Return6When1NewLineAnd2And3()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            int result = calculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }
    }
}
