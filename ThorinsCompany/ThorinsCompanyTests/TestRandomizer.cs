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
        public void T05RandomizerGetChanceDwarfBorn()
        {
            bool chanceToBorn = randomizer.WillHeBeBorn(randomizer.ReturnRandomNumber(1, 1));

            Assert.IsTrue(chanceToBorn);
        }

        [Test]
        public void T06RandomizerGetPriceDirtyGoldBetween1And5()
        {
            bool isThePriceCorret = false;
            int priceofDirtyGold = randomizer.ReturnPriceMaterials(Material.DirtyGold);
            if (priceofDirtyGold >= 1 && priceofDirtyGold <= 5)
                isThePriceCorret = true;
            Assert.IsTrue(isThePriceCorret);
        }

        [Test]
        public void T07RandomizerGetPriceMithrillBetween15And25()
        {
            bool isThePriceCorret = false;
            int priceofMithril = randomizer.ReturnPriceMaterials(Material.Mithril);
            if (priceofMithril >= 15 && priceofMithril <= 25)
                isThePriceCorret = true;
            Assert.IsTrue(isThePriceCorret);
        }

        [Test]
        public void T08RandomizerGetPriceSilverBetween5And15()
        {
            bool isThePriceCorret = false;
            int priceofSilver = randomizer.ReturnPriceMaterials(Material.Silver);
            if (priceofSilver >= 5 && priceofSilver <= 15)
                isThePriceCorret = true;
            Assert.IsTrue(isThePriceCorret);
        }

        [Test]
        public void T09RandomizerGetPriceGoldBetween10And20()
        {
            bool isThePriceCorret = false;

            int priceofDirtyGold = randomizer.ReturnPriceMaterials(Material.Silver);
            if (priceofDirtyGold >= 5 && priceofDirtyGold <= 15)
                isThePriceCorret = true;
            Assert.IsTrue(isThePriceCorret);
        }
    }
}
