using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 

namespace UnitTestProject1
{
    [TestClass]
    public class StringCalcTest
    {
        [TestMethod]
        public static void Return0IfStringIsNull()
        {
            //given
            string stringNumber = "";
            
            int result = StringCalc.StringCalculator.Sum(stringNumber);

            Assert.AreEqual(0, result);
        }
    }
}
