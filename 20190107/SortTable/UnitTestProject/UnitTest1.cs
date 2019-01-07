using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortTable;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Filters filter = new Filters();
        List<string> testList = new List<string>() { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };

        [TestMethod]
        public void TestForGettingNumbers()
        {
            
            List<string> expected = new List<string>() { "1", "7", "4", "9", "14", "1", "2"};
            
            List<string> result = filter.FilterNumbers(testList);
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void TestForLetters()
        {
            List<string> expected = new List<string>() { "a", "b", "c", "d", "k", "a" };
            List<string> result = filter.FilterOddLetters(testList);
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void ShouldGetSortedListOfNumbers()
        {
            List<string> expected = new List<string>() { "1", "1", "2", "4", "7", "9", "14" };
            List<string> result = filter.SortListOfNumbers(testList);
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }

        }

    }
}
