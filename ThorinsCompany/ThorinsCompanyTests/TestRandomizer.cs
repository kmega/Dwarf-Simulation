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

        [Test]
        public void T10RandomizerGetMithrillWhenYouDig()
        {
            bool isMithrill = false;
            Material material = randomizer.WhatDidYouDigOut(5);
            if (material == Material.Mithril)
                isMithrill = true;
            Assert.IsTrue(isMithrill);
        }

        [Test]
        public void T11RandomizerGetSilverWhenYouDig()
        {
            bool isSilver = false;
            Material material = randomizer.WhatDidYouDigOut(33);
            if (material == Material.Silver)
                isSilver = true;
            Assert.IsTrue(isSilver);
        }

        [Test]
        public void T12RandomizerGetGoldWhenYouDig()
        {
            bool isGold = false;
            Material material = randomizer.WhatDidYouDigOut(13);
            if (material == Material.Gold)
                isGold = true;
            Assert.IsTrue(isGold);
        }

        [Test]
        public void T13RandomizerGetDirtyGoldWhenYouDig()
        {
            bool isDirtyGold = false;
            Material material = randomizer.WhatDidYouDigOut(80);
            if (material == Material.DirtyGold)
                isDirtyGold = true;
            Assert.IsTrue(isDirtyGold);
        }
    }
}
