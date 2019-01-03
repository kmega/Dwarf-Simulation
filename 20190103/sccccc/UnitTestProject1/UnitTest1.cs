using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sccccc;

namespace sccccc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calculator = new StringCalculator();
            string value = "2";
            int expected = 2;
            string[] separator = { ",", Environment.NewLine };

            int result = calculator.Add(value, separator);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var calculator = new StringCalculator();
            string value = "2,3";
            int expected = 5;
            string[] separator = { ",", Environment.NewLine };

            int result = calculator.Add(value, separator);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var calculator = new StringCalculator();
            string value = "2,3";
            string value2 = "1,3";
            string[] separator = { ",", Environment.NewLine, "***" };

            int expected = 9;

            int result = calculator.Add(value, value2, separator);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var calculator = new StringCalculator();
            string value = "Bardzo3Lubie, Jendka32";
            string[] separator = { ",", Environment.NewLine };

            int expected = 35;

            int result = calculator.Add(value, separator);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var calculator = new StringCalculator();
            string value = "Bardzo3Lubie,\nJendka32";
            string[] separator = { ",", Environment.NewLine };
            int expected = 35;

            int result = calculator.Add(value, separator);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethod6()
        {
            var calculator = new StringCalculator();
            string value = "Bardzo3Lubie,\nJendka32";
            string value2 = "Make2DreamsComme***True-1,Day2";
            string[] separator = { ",", Environment.NewLine, "***" };

            int result = calculator.Add(value, value2, separator);

            Assert.Fail();
        }

        [TestMethod]
        public void TestMethod7()
        {
            var calculator = new StringCalculator();
            string value = "//[*][%]\n1*2%3";
            string[] separator = { ",", Environment.NewLine, "***" , "*", "%"};

            int expected = 6;

            int result = calculator.Add(value, separator);

            Assert.AreEqual(expected, result);
        }
    }
}
