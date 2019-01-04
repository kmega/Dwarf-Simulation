using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TeaApp;

namespace TeaTests
{
    [TestClass]
    public class Task2Tests
    {
        [TestMethod]
        public void ShouldBuildSingleTea()
        {
            List<string> lines = TeaData.RawTeas();
            //Act
            var result = TeaFactory.BuildSingleTea(FileManager.SeperateLine(lines[2]));
            var expected = new Tea("Lapacho", "napar", 96, 10);
            //assert
            Assert.AreEqual(result.Name, expected.Name);
        }
        [TestMethod]
        public void ShouldSortTeasByType()
        {
            List<string> lines = TeaData.RawTeas();
            List<string> expected = TeaData.OrderedTeaTypes();
            //Act
            var result = TeaFactory.BuildFromFile(lines).OrderBy(t => t.Type).ToList();   
            //assert
            for(int i = 0; i<result.Count; i++)
            {
                Assert.AreEqual(result[i].Type, expected[i]);
            }       
        }
    }
}