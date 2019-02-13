using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Interfaces.SellingStrategy;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dwarf_TownTests.Locations
{
    [TestFixture]
    public class GuildTests
    {
        [Test]
        public void ReturnPaymentForOneDwarWithEmptyBackpack()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Backpack backpack = new Backpack();
            Wallet wallet = new Wallet();
            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(backpack, wallet) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(0, guild.ShowTresure());
            Assert.AreEqual(0, wallet.DailyCash);
            Assert.IsTrue(backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForOneDwarfWithOneDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Backpack backpack = new Backpack();
            Wallet wallet = new Wallet();
            backpack.AddOre(MineralType.DirtyGold);
            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(backpack, wallet) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(0.5, guild.ShowTresure());
            Assert.AreEqual(1.5, wallet.DailyCash);
            Assert.IsTrue(backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForOneDwarfWithOTwoDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Backpack backpack = new Backpack();
            Wallet wallet = new Wallet();
            backpack.AddOre(MineralType.DirtyGold);
            backpack.AddOre(MineralType.DirtyGold);

            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(backpack, wallet) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(1, guild.ShowTresure());
            Assert.AreEqual(3, wallet.DailyCash);
            Assert.IsTrue(backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForTwoDwarvesWithOTwoDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Backpack backpackOne = new Backpack();
            Wallet walletOne = new Wallet();
            Backpack backpackTwo = new Backpack();
            Wallet walletTwo = new Wallet();
            backpackOne.AddOre(MineralType.DirtyGold);
            backpackOne.AddOre(MineralType.DirtyGold);
            backpackTwo.AddOre(MineralType.DirtyGold);
            backpackTwo.AddOre(MineralType.DirtyGold);


            List<ISell> miners = new List<ISell>()
            {
                new StandardSellingStrategy(backpackOne, walletOne),
                new StandardSellingStrategy(backpackTwo,walletTwo)
            };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(2, guild.ShowTresure());
            Assert.AreEqual(3, walletOne.DailyCash);
            Assert.AreEqual(3, walletTwo.DailyCash);
            Assert.IsTrue(backpackOne.ShowBackpack().Count == 0);
            Assert.IsTrue(backpackTwo.ShowBackpack().Count == 0);


        }

    }
}