using System;
using HappyPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HappyPathTests
{
    [TestClass]
    public class TextParserTests
    {
        private TextParser textParser;

        [TestInitialize]
        public void init()
        {
            textParser = new TextParser();
        }
        [TestMethod]
        public void shouldReturnProfileNameWhenStringMatchesToProfileNameRegex()
        {
            string stringContent = "title: \"Fryderyk Komciur\"";
            string expected = "Fryderyk Komciur";
            string actual = textParser.ExtractProfileName(stringContent);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void shouldReturnTimeToCreateWhenStringMatchesToTimeToCreteRegex()
        {
            string stringContent = "(23 min)";
            string expected = "23";
            string actual = textParser.ExtractTimeToCreate(stringContent);
            Assert.AreEqual(expected, actual);
        }
    }
}
