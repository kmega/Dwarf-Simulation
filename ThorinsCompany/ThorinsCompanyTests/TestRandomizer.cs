using DwarfMineSimulator;
using NUnit.Framework;
using ThorinsCompany;

namespace ThorinsCompanyTests
{
    class TestRandomizer
    {
        RandomizerThorins randomizer = new RandomizerThorins();

        [Test]
        public void T01RandomizerGetFatherDwarfType()
        {
            for (int i = 1; i <= 33; i++)
            {
                DwarfType dwarfType = randomizer.GenerateDwarfType(i);
                Assert.AreEqual(dwarfType, DwarfType.Father);
            }       
        }

        [Test]
        public void T02RandomizerGetSingleDwarfType()
        {
            for (int i = 34; i <= 66; i++)
            {
                DwarfType dwarfType = randomizer.GenerateDwarfType(i);
                Assert.AreEqual(dwarfType, DwarfType.Single);
            }
        }

        [Test]
        public void T03RandomizerGetLazyDwarfType()
        {
            for (int i = 67; i <= 99; i++)
            {
                DwarfType dwarfType = randomizer.GenerateDwarfType(i);
                Assert.AreEqual(dwarfType, DwarfType.Lazy);
            }
        }

        [Test]
        public void T04RandomizerGetBomberDwarfType()
        {
            DwarfType dwarfType = randomizer.GenerateDwarfType(100);
            Assert.AreEqual(dwarfType, DwarfType.Bomber);
        }

        [Test]
        public void T05RandomizerGetBomberDwarfType()
        {
            bool chanceToBorn = randomizer.WillHeBeBorn(randomizer.ReturnRandomNumber(1, 1));

            Assert.IsTrue(chanceToBorn);
        }


    }
}
