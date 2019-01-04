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
            List<string> lines = TeaData.Records();

            //Act
            var result = TeaFactory.BuildSingleTea(FileManager.SeperateLine(lines[4]));
            var expected = new Tea("Lapacho", "napar", 96, 10);
            //assert
            Assert.AreEqual(result.Name, expected.Name);
        }
        [TestMethod]
        public void ShouldSortTeasByType()
        {
            List<string> lines = TeaData.Records();
            lines.RemoveRange(0, 2);
            //Act
            var result = TeaFactory.BuildFromFile(lines).OrderBy(t => t.Type).ToList();

            var expectedTypeAt4Position = "owocowa";
            var expectedTypeAt5Position = "zielona";
            //assert
            Assert.AreEqual(expectedTypeAt4Position, result[4].Type);
            Assert.AreEqual(expectedTypeAt5Position, result[5].Type);
        }
    }
}