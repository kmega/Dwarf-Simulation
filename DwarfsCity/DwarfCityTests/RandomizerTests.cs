using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DwarfCityTests
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public void ProbabilityOfDigginng1_3Times()
        {
            //given, when, then
            int result = Randomizer.CountsOfDigging();

            Assert.IsTrue(result >=1 && result<=3);
        }

        [TestMethod]
        public void ValueOfDiggedItems_Between15and25()
        {
            //given
            Item mithril = Item.Mithril;
            Item gold = Item.Gold;
            Item silver = Item.Silver;
            Item dirtyGold = Item.DirtyGold;

            //when, then
            decimal result = Randomizer.ValueOfItem(mithril);
            Assert.IsTrue(result >= 15 && result <= 25);

            //when, then
            result = Randomizer.ValueOfItem(gold);
            Assert.IsTrue(result >= 10 && result <= 20);

            //when, then
            result = Randomizer.ValueOfItem(silver);
            Assert.IsTrue(result >= 5 && result <= 15);

            //when, then
            result = Randomizer.ValueOfItem(dirtyGold);
            Assert.IsTrue(result >= 1 && result <= 10);
        }

        //[TestMethod]
        //public void Digg3TimesAndGetEachItemsWithItsSmallestValue()
        //{
        //    //given
        //    var randomizer = new Mock<IRandomizer>();

        //    //when
        //    randomizer.Setup(x => x.RandomNumber).Returns(new Randomizer().RandomNumber);
        //    randomizer.Setup(x => x.RandomNumber.GetChanceRatio).Returns(3);
        //    //randomizer.Setup(x => x.RandomNumber.GetChanceRatio(1,100)).Returns(4);
            

        //    //then
        //    int diggedCount = randomizer.CountsOfDigging();
        //    Item mithril = Randomizer.ItemDigged();

        //    //when
        //    randomizer.Setup(x => x.GetChanceRatio(1, 100)).Returns(10);

        //    //then
        //    Item gold = Randomizer.ItemDigged();

        //    //when
        //    randomizer.Setup(x => x.GetChanceRatio(1, 100)).Returns(30);

        //    //then
        //    Item silver = Randomizer.ItemDigged();

        //    //when
        //    randomizer.Setup(x => x.GetChanceRatio(1, 100)).Returns(80);

        //    //then
        //    Item dirtyGold = Randomizer.ItemDigged();

        //    Assert.IsTrue(diggedCount == 3);
        //    Assert.IsTrue(mithril == Item.Mithril);
        //    Assert.IsTrue(gold == Item.Gold);
        //    Assert.IsTrue(silver== Item.Silver);
        //    Assert.IsTrue(dirtyGold == Item.DirtyGold);
        //}
    }
}
