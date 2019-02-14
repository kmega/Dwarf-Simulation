using Dwarf_Town;
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
            Dwarf dwarf = new Dwarf();
            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(dwarf) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(0, guild.ShowTresure());
            Assert.AreEqual(0, dwarf.Wallet.DailyCash);
            Assert.IsTrue(dwarf.Backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForOneDwarfWithOneDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Dwarf dwarf = new Dwarf();
           dwarf.Backpack.AddOre(MineralType.DirtyGold);
            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(dwarf) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(0.5, guild.ShowTresure());
            Assert.AreEqual(1.5, dwarf.Wallet.DailyCash);
            Assert.IsTrue(dwarf.Backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForOneDwarfWithOTwoDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Dwarf dwarf = new Dwarf();
            dwarf.Backpack.AddOre(MineralType.DirtyGold);
            dwarf.Backpack.AddOre(MineralType.DirtyGold);

            List<ISell> miners = new List<ISell>() { new StandardSellingStrategy(dwarf) };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(1, guild.ShowTresure());
            Assert.AreEqual(3, dwarf.Wallet.DailyCash);
            Assert.IsTrue(dwarf.Backpack.ShowBackpack().Count == 0);

        }

        [Test]
        public void ReturnPaymentForTwoDwarvesWithOTwoDirtyGold()
        {
            //given
            Guild guild = GuildFactory.CreateStandardGuild();
            Dwarf dwarfOne = new Dwarf();
            Dwarf dwarfTwo = new Dwarf();
            dwarfOne.Backpack.AddOre(MineralType.DirtyGold);
            dwarfOne.Backpack.AddOre(MineralType.DirtyGold);
            dwarfTwo.Backpack.AddOre(MineralType.DirtyGold);
            dwarfTwo.Backpack.AddOre(MineralType.DirtyGold);


            List<ISell> miners = new List<ISell>()
            {
                new StandardSellingStrategy(dwarfOne),
                new StandardSellingStrategy(dwarfTwo)
            };

            //when
            guild.PaymentForDwarves(miners);

            //then
            Assert.AreEqual(2, guild.ShowTresure());
            Assert.AreEqual(3, dwarfOne.Wallet.DailyCash);
            Assert.AreEqual(3, dwarfTwo.Wallet.DailyCash);
            Assert.IsTrue(dwarfOne.Backpack.ShowBackpack().Count == 0);
            Assert.IsTrue(dwarfTwo.Backpack.ShowBackpack().Count == 0);


        }

        

    }
}