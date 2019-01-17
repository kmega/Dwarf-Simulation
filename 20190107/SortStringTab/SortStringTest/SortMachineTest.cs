using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortStringTab;

namespace SortStringTest
{
    [TestClass]
    public class SortMachineTest
    {
        [TestMethod]
        public void isworkforsimplelettersandnumbers()
        {
            List<string> input = new List<string>()
            {

              "a",
                "b",
                 "1",
                 "7",
                "4",
               "c","9","d","14","k","a","1","2"
            };

            SortMachine sm = new SortMachine();

            List<string> result = new List<string>();
            result = sm.SortString(input);

            List<string> resultiwant = new List<string>()
            {
                "a","a","c","k", "1","1","2","4","7","9","14","b","d"
            };


            CollectionAssert.AreEqual(resultiwant, result);

        }
        [TestMethod]
        public void isworkwithweirdoddnumber()
        {
            List<string> input = new List<string>()
            {

              "a","$",
                "b",
                 "1",
                 "7","$",
                "4",
               "c","9","d","14","k","a","1","2"
            };

            SortMachine sm = new SortMachine();

            List<string> result = new List<string>();
            result = sm.SortString(input);

            List<string> resultiwant = new List<string>()
            {
                "a","a","c","k", "1","1","2","$","$","4","7","9","14","b","d"
            };


            CollectionAssert.AreEqual(resultiwant, result);

        }

        [TestMethod]
        public void isworkwithweirdevenumber()
        {
            List<string> input = new List<string>()
            {

              "a","$",
                "b",
                 "1",
                 "7","$",
                "4",
               "c","9","d","14","k","a","2"
            };

            SortMachine sm = new SortMachine();

            List<string> result = new List<string>();
            result = sm.SortString(input);

            List<string> resultiwant = new List<string>()
            {
                "a","a","c","k", "1","2","4","$","$","7","9","14","b","d"
            };


            CollectionAssert.AreEqual(resultiwant, result);


        }

        [TestMethod]
        public void isworkwithpolishletter()
        {
            List<string> input = new List<string>()
            {

              "a","ą",
                "b",
                 "1",
                 "7","ą",
                "4",
               "c","9","d","14","k","a","2"
            };

            SortMachine sm = new SortMachine();

            List<string> result = new List<string>();
            result = sm.SortString(input);

            List<string> resultiwant = new List<string>()
            {
                "a","a","c","k", "1","2","4","ą","ą","7","9","14","b","d"
            };


            CollectionAssert.AreEqual(resultiwant, result);

        }

    }
}
