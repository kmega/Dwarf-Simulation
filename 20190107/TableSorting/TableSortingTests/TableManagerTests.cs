using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableSorting;

namespace TableSortingTests
{
    [TestClass]
    public class TableManagerTests
    {
        [TestMethod]
        public void ShouldReturnSortedTable()
        {
            //given:
            List<string> given = new List<string>()
            { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2"};
            List<string> expected = new List<string>()
            {
                "a","a","c","k","1","1","2","4","7","9","14","b","d"
            };
            //SortTable
            List<string> actual = TableManager.Sort(given);
            //Then
            for(int i = 0; i<given.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }


        }
    }
}
