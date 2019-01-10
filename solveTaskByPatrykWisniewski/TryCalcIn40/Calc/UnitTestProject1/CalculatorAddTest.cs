using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorAddTest
    {
        //Nazwy metod samą koncówkę bym napisał przez jakid kod Ascii
        //Ale mało czasu 
        [TestMethod]
        public void CalculatorAddTestWithcharacter1()
        {
            Calculator cal = new Calculator();
            int result = cal.add("2,3,4");
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void CalculatorAddTestWithcharacter2()
        {
            Calculator cal = new Calculator();
            int result = cal.add("4\n3\n4");
            Assert.AreEqual(result, 11);
        }

        [TestMethod]
        public void CalculatorAddTestWithcharacter3()
        {
            Calculator cal = new Calculator();
            int result = cal.add("3/3/4");
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void CalculatorAddTestWithDelimeter()
        {
            Calculator cal = new Calculator();
            int result = cal.add("//;\n1;2");
            Assert.AreEqual(result, 10);
        }
    }
}
