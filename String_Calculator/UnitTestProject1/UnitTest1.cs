using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Calculator;

namespace UnitTestProject1
{
    [TestClass]
    public class StringCalculatorTest
    {
        public int TestInput(string value)
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(value);
            return result;
        }

        [TestMethod]
        public void ReturnValue0WhenStringIs0()
        {
            string value = "0";

            int result = TestInput(value);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ReturnValue1WhenStringIs1()
        {
            string value = "1";

            int result = TestInput(value);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ReturnValue3WhenStringIs1Comma2()
        {
            string value = "1,2";

            int result = TestInput(value);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReturnValue6WhenStringIs1NewLine2Comma3()
        {
            string value = "1\n2,3";

            int result = TestInput(value);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ReturnValue0WhenStringIsEmpty()
        {
            string value = "";

            int result = TestInput(value);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
    "Error")]
        public void ShouldThrowExceptionWhenStringIs1CommaNewLine()
        {
            string value = "1,/n";
            TestInput(value);
        }

        [TestMethod]
        public void ReturnValue3WhenStringHasDelimiter()
        {
            string value = "//;\n1;2";

            int result = TestInput(value);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReturnValue5WhenStringHasDelimiter()
        {
            string value = "//.\n2.3";

            int result = TestInput(value);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
"Error")]
        public void ShouldThrowExceptionWhenNegativeNumbers()
        {
            string value = "-1,-2";
            TestInput(value);
        }

        [TestMethod]
        public void ReturnValue2WhenStringHasHighValue()
        {
            string value = "2,1001";

            int result = TestInput(value);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ReturnValue6WhenStringHasLongDelimiter()
        {
            string value = "//[***]\n1***2***3";

            int result = TestInput(value);

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void ReturnValue6WhenStringHasMultipleDelimiters()
        {
            string value = "//[*][%]\n1*2%3";

            int result = TestInput(value);

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void ReturnValue6WhenStringHasMultipleLongDelimiters()
        {
            string value = "//[***][%%%]\n1***2%%%3";

            int result = TestInput(value);

            Assert.AreEqual(6, result);
        }
    }
}
