using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberMagic;

namespace UnitTestProject1
{
    [TestClass]
    public class CyberMagicTests
    {
        [TestMethod]
        public void RetrunFryderykKomciurBulitTime()
        {
            BuildFryderykKomciurTime createTmie = new BuildFryderykKomciurTime();
            string result = createTmie.BuildFryderykKomciur();

            Assert.AreEqual(result, "Fryderyk Komciur był budowany 23 minuty");
        }

        [TestMethod]
        public void BulitAllCharactersTime()
        {
            BuildAllCharactersTime allCharactersTime = new BuildAllCharactersTime();
            string result = allCharactersTime.BuildAllCharacters();

            Assert.AreEqual(result, "");
        }
    }
}
