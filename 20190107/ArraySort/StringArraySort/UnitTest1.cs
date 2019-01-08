using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArraySort;
using System.Collections.Generic;

namespace StringArraySort
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldExtractEvenLettersWhenArrayContainsEvenLetters()
        {
            StringSorter stringSorter = new StringSorter();
            string[] array = { "a","b","1","7","4","c","9","d","14","k","a","1","2" };
            List<char> expected = new List<char>{ 'b','d' };
            var actual = stringSorter.ExtractLetters(array, true);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldExtractOddLettersWhenArrayContainsOddLetters()
        {
            StringSorter stringSorter = new StringSorter();
            string[] array = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            List<char> expected = new List<char> { 'a','c','k','a' };
            var actual = stringSorter.ExtractLetters(array, false);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ShouldCreateNewStringArrayWithSortedEvenCharsAndNumbersAndOddChars()
        {
            StringSorter stringSorter = new StringSorter();
            string[] array = { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            string[] expected = { "a", "a", "c", "k", "1", "1", "2", "4", "7", "9", "14", "b", "d" };
            var actual = stringSorter.Sort(array);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
