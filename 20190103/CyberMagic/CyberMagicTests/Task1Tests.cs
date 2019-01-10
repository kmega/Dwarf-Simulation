using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberMagic;

namespace CyberMagicTests
{
    [TestClass]
    public class Task1Tests
    {

        public void Charater(string pathFile, string result)
        {
            string name = InformationExtractor.ExtractSingleName(TextFileManager.ReadFile(pathFile));
            Assert.AreEqual(result, name);
        }

        [TestMethod]
        public void RegexNameFromFormatMdFryderykKomciur()
        {
            Charater(@"C:\Users\Lenovo\code\primary\20190103\CyberMagic\CyberMagic\bin\cybermagic\karty-postaci\1807-fryderyk-komciur.md", 
                "Fryderyk Komciur");
        }

        [TestMethod]
        public void RegexNameFromFormatMdAlfredWeiner()
        {
            Charater(@"C:\Users\Lenovo\code\primary\20190103\CyberMagic\CyberMagic\bin\cybermagic\karty-postaci\1807-alfred-weiner.md",
                "Alfred Weiner");
        }
    }
}
