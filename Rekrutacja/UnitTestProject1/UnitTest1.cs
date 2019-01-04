using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rekrutacja;

namespace UnitTestProject1
{
    [TestClass]
    public class ReverseRecordsTest
    {
        [TestMethod]
        public void ReverseRecordsTestExample()
        {
            string[] array = { "1", "2"};
            Reverse_Records reverse = new Reverse_Records();
            array = reverse.Reverse(array);

            Assert.AreEqual(array[0], "2");
            Assert.AreEqual(array[1], "1");

        }
    }
}
