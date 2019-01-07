using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sortowanie;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1

    { SortingMachine sortmach = new SortingMachine();
        
        [TestMethod]
        public void TestMethod1()
        {
            string[] given = new string[] { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            string[] result = sortmach.Sort(given);
            string[] expected = new string[] {"a","a","c","k","1","1","2","4","7","9","14","b","d" };
            Assert.AreEqual(result, expected);
        }
    }
}
