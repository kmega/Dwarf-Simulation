using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 

namespace UnitTestProject1
{
    [TestClass]
    public class StringCalcTest
    {
        [TestMethod]
        public void Return0IfStringIsNull()
        {
            //given
            string stringNumber = "";
            
            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Return4IfStringIs2Plus2()
        {
            //given
            string stringNumber = "2,2";

            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Return6IfStringIs2Plus2Plus2()
        {
            //given
            string stringNumber = "2,2,2";

            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ReturnSum124OfMultiAddition()
        {
            //given
            string stringNumber = "2,2,2,100,8,10";

            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(124, result);
        }

        [TestMethod]
        public void Return4DifferentDelimeters()
        {
            //given
            string stringNumber = "2\n2";

            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Return6DifferentDelimeters()
        {
            //given
            string stringNumber = "3.3";

            int result = StringCalc.StringCalculator.Add(stringNumber);

            Assert.AreEqual(6, result);
        }
    }
}
