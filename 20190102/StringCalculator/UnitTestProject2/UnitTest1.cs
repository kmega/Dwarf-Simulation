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

        public void Return0()
        {
            int result = calc.Sum("");

            Assert.AreEqual(0, result);


        }
        [TestMethod]

       public void ReturnSum ()
        {
           int result= calc.Sum("1,2,3");

            Assert.AreEqual(6, result);


        }

        [TestMethod]

        public void ReturnSumWithnewline()
        {
            int result = calc.Sum("1\n2,3");

            Assert.AreEqual(6, result);
            
        }

        [TestMethod]

        public void ReturnSumWithGivenDelimteter()
        {
            int result = calc.Sum("//;\n1;2");

            Assert.AreEqual(3, result);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Nie wolno używać ujemnych")]
        public void ReturnException()
        {
           

            int result = calc.Sum("-1,2,-5");

        }



        [TestMethod]

        public void Returnwithount1000()
        {
            int result = calc.Sum("2,1001");

            Assert.AreEqual(2, result);


        }
        [TestMethod]

        public void ReturnwithManyCharDelimeter()
        {
            int result = calc.Sum("//[***]\n1***2***3");

            Assert.AreEqual(6, result);


        }














    }
}
