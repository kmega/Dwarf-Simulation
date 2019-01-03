using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _20190103;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        StringCaltulator cal = new StringCaltulator();

        [TestMethod]
        public void Restrun0WhenNull()
        {
            //given

            string number = "";

            int result = cal.Add(number);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ReturnSum()
        {
            string number = "//[***]\n5***4***3";
            int result = cal.Add(number);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void ReturnSumMultiLine()
        {
            string number = "//[***]\n5***4\n***3";
            int result = cal.Add(number);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Return6Sum()
        {
            string number = "1\n2,3";
            int result = cal.Add(number);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ReturnErrorIfNegative()
        {
            string number = "1\n2,-3";
            int result = cal.Add(number);
            
        }

        [TestMethod]
        public void ReturnSumDiffDelimiter()
        {
            string number = "//[aaaaa]\n5aaaaa4\naaaaa3";
            int result = cal.Add(number);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void ReturnSumMultiDelimiters()
        {
            string number = "//[***][...]\n5***4\n...3";
            int result = cal.Add(number);
            Assert.AreEqual(12, result);
        }
    }
}
