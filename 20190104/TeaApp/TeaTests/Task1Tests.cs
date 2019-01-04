using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaApp;

namespace TeaTests
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void ShouldReverseGivenLines()
        {
            List<string> lines = TeaData.Records();

            List<string> actual = FileManager.ReverseRecords(lines);

            Assert.AreEqual("Zielone Marzenie, zielona, 70, 3, ", actual[0]);
            Assert.AreEqual("Uśmiech Ananasa, owocowa, 96, 5, ", actual[1]);
        }
    }
}
