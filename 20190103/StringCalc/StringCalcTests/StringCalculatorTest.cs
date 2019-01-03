using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalc;

namespace StringCalcTests
{
    [TestClass]
    public class StringCalculatorTest
    {
        public void TestAddMethodInputResultCheck(string input, int result)
        {
            var calculator = new StringCalculator();
            int expected = result;
            Assert.AreEqual(expected, calculator.Add(input));
        }
      
        [TestMethod]
        public void CalcWhenInput0thenreturn0()
        {
            TestAddMethodInputResultCheck("0", 0);
        }

        [TestMethod]
        public void CalcWhenInput1And2Return3()
        {
            TestAddMethodInputResultCheck("1,2", 3);
        }

        [TestMethod]
        public void CalcWhenInput1Return1()
        {
            TestAddMethodInputResultCheck("1", 1);
        }

        [TestMethod]
        public void CalcWhenInputWithenterReturn6()
        {
            TestAddMethodInputResultCheck("1/n2,3", 6);
        }

        [TestMethod]
        public void CalcWhenInputMorethanTwonumberReturn10()
        {
            TestAddMethodInputResultCheck("1,2,2,5", 10);
        }

        [TestMethod]
        public void CalcWhenInputMorethan0()
        {
            TestAddMethodInputResultCheck("1,2,2,5", 10);
        }

        [TestMethod]
        public void CalcWhenInputWithDelimeterResult12()
        {
            TestAddMethodInputResultCheck("[-]/n8-1-1", 10);
        }
        [TestMethod]
        public void CalcWhenInputWithDelimeterResult20()
        {
            TestAddMethodInputResultCheck("[*]/n8*1*1*10", 20);
        }
    }
}
