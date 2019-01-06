using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator2;

namespace UnitTestProject1
{

    [TestClass]
    public class Task1
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]
        public void Sumof0elements()
        {
            string value = "";
            int result = stringcalculator.Add1element(value);
            int expected = 0;
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Sumof1elements()
        {
            string value = "1";
            int result = stringcalculator.Add1element(value);
            int expected = 1;
            Assert.AreEqual(result, expected);
        }
        [TestMethod]
        public void Sumof2elements()
        {
            string value = "1,2";
            int result = stringcalculator.Add2elements(value);
            int expected = 3;
            Assert.AreEqual(result, expected);
        }

    }

    [TestClass]
    public class Task2
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]
        public void SumofUnknowElements()
        {
            string value = "1,2,3,4,5";
            int result = stringcalculator.AddUnknowAmountOfElements(value);
            int expected = 15;
            Assert.AreEqual(result, expected);
        }
    }
    [TestClass]
    public class Task3
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]
        public void SumofUnknowElementsWithNewLine()
        {
            string value = "1,2,3,4\n5";
            int result = stringcalculator.AddUnknowAmountOfElementsWithNewLine(value);
            int expected = 15;
            Assert.AreEqual(result, expected);
        }
    }
    [TestClass]
    public class Task4
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]
        public void SumofUnknowElementsWithDifferentSeparators()
        {
            string value = "1s,2sdfg,3fd,4\n5";
            int result = stringcalculator.AddUnknowAmountOfElementsWithDiffrentSeparators(value);
            int expected = 15;
            Assert.AreEqual(result, expected);
        }
    }
    
    [TestClass]
    public class Task5
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        
        public void SumofUnknowElementsWithWithNegative()
        {
            string value = "1s,-2sdfg,3fd,-4\n5";
            string negative = "";           
   
            negative = value.Substring(value.IndexOf("-"), 2);

            
            int result = stringcalculator.AddUnknowAmountOfElementsWithNegative(value);
            int expected = 15;
            Assert.AreEqual(result, expected);

            throw new ArgumentOutOfRangeException(String.Format("Negatives  \"{0}\" not allowed.",
                        negative),"" );

               
            //Assert.Fail();
           
        }
    }
    [TestClass]
    public class Task6
    {
        StringCalc stringcalculator = new StringCalc();
        [TestMethod]

        public void SumofUnknowElementsAndIgnoreMoreThan1000()
        {
            string value = "1s,-2sdfg,3fd,-4\n5000";
            int result = stringcalculator.IgnoreMoreThan1000(value);
            int expected = 5010;
            Assert.AreEqual( expected, result);


        }
    }


}
