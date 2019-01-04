using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tea;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void IsReverseempty()
        {
            ReadingFile rf = new ReadingFile("testy1.txt");

            rf.teas.Reverse();
           string result =  String.Join(",", rf.teas);

            Assert.AreEqual("", result);

        }

        [TestMethod]
        public void IsReverseone()
        {
            ReadingFile rf = new ReadingFile("testy2.txt");
            rf.teas.Reverse();
            Assert.AreEqual("1", rf.teas[0]);

        }

        [TestMethod]
        public void IsReverstwoelements()
        {
            ReadingFile rf = new ReadingFile("testy3.txt");
            rf.teas.Reverse();
            string result = String.Join(",", rf.teas);

            Assert.AreEqual("2,1", result);

        }

       



    }
}
