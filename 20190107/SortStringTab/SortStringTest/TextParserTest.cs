using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortStringTab;

namespace SortStringTest
{
    [TestClass]
    public class TextParserTest
    {
        [TestMethod]
        public void createlistofstrings()
        {
            //Given
            string input = "a,b,1";
            TextParser tp = new TextParser();

            //When
            List<string> listofstrings = tp.ParseInput(input);

            //Expected
            Assert.AreEqual("a", listofstrings[0]);
            Assert.AreEqual("b", listofstrings[1]);
            Assert.AreEqual("1", listofstrings[2]);


        }
    }
}
