using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortArray;

namespace SortArrayTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RetardedTwoLettersForEvenLetters()
        {
            //given
            string[] notSortedArray = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };

            string firstLetter = "a";
            string secondLetter = "a";

            List<string> result = new StringLettersOps().GetEvenLetters(notSortedArray);

            Assert.AreEqual(firstLetter, result[0]);
            Assert.AreEqual(secondLetter, result[1]);
        }

        [TestMethod]
        public void RetardedTwoLettersForNotEvenLetters()
        {
            //given
            string[] notSortedArray = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };

            string firstLetter = "b";
            string secondLetter = "d";

            List<string> result = new StringLettersOps().GetNotEvenLetters(notSortedArray);

            Assert.AreEqual(firstLetter, result[0]);
            Assert.AreEqual(secondLetter, result[1]);
        }
    }
}
