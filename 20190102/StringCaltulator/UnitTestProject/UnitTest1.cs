using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCaltulator;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Caltulator calculator = new Caltulator();

        [TestMethod]
        public void ShouldReturn0BcsStringIsEmpty()
        {
            int result = calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldReturn1Given1Number()
        {
            int result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ShouldReturn10GivenRandomString()
        {
            int result = calculator.Add("ad.fda/fa3 ht 5 2");

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ShouldReturn15Given3Ints()
        {
            int result = calculator.Add("10 3 2");

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void ShouldReturn6Given3IntsAndNewLineBetween()
        {
            int result = calculator.Add("1\n2, 3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ShouldReturn3GivenDiffrentDelimiters()
        {
            int result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }
    }
}


