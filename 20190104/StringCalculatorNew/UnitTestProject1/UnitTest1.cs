using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorNew;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        Calculator calc = new Calculator();
        [TestMethod]
        public void EmptyisZero()
        {
            string input = "";
           int result =calc.Sum(input);

            Assert.AreEqual(0, result);

        }
        [TestMethod]
        public void shouldReturn3beacause1and2()
        {
            string input = "1,2";
            int result = calc.Sum(input);

            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void shouldReturn6withnewline()
        {
            string input = "1\n2,3";
            int result = calc.Sum(input);

            Assert.AreEqual(6, result);

        }
        [TestMethod]
        public void shouldReturn3withdeclaredelimeter()
        {
            string input = "//;\n1;2";
            int result = calc.Sum(input);

            Assert.AreEqual(3, result);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Nie wolno ujemnych")]
        public void shouldReturnException()
        {
            string input = "-1";
            int result = calc.Sum(input);
            

        }

        [TestMethod]
      
        public void shouldReturnListExeption()
        {
            string input = "-1,-2";
            int resulttemp = calc.Sum(input);
            int result = calc.exception.Count;

            Assert.IsTrue(result > 1);

        }



    }
}
