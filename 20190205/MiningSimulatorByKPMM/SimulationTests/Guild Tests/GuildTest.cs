using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using MiningSimulatorByKPMM.PersonalItems;
using Moq;
using NUnit.Framework;

namespace SimulationTests.Guild_Tests
{
    public class GuildTest
    {

        Guild guild;

        [SetUp]
        public void Setup()
        {

            guild = GuildFactory.CreateStandardGuild();


        }

        [Test]
        public void ShouldReturnPaymentForDwarfWithEmptyBackpack()
        {
            //given

            BankAccount bankAccount = new BankAccount();
            Backpack backpack = new Backpack();


            //when
            guild.PaymentForDwarf(backpack, bankAccount, true);

            //then
            Assert.AreEqual(0, guild.Account.OverallAccount);
            Assert.AreEqual(0, bankAccount.LastInput);
            Assert.IsTrue(backpack.ShowBackpackContent().Count == 0);

        }
        [Test]
        public void ShouldReturnPaymentForOneDwarfWithDirtGold()
        {
            //given

            BankAccount bankAccount = new BankAccount();
            Backpack backpack = new Backpack();
            backpack.AddSingleOre(new Ore(E_Minerals.DirtGold));

            //when
            guild.PaymentForDwarf(backpack, bankAccount, true);

            //then
            Assert.AreEqual(0.5, guild.Account.OverallAccount);
            Assert.AreEqual(1.5, bankAccount.LastInput);
            Assert.IsTrue(backpack.ShowBackpackContent().Count == 0);

        }

        [Test]
        public void ShouldReturnPaymentForTwoDwarfWithDirtGold()
        {
            //given

            BankAccount bankAccountOne = new BankAccount();
            BankAccount bankAccountTwo = new BankAccount();
            Backpack backpackOne = new Backpack();
            Backpack backpackTwo = new Backpack();
            backpackOne.AddSingleOre(new Ore(E_Minerals.DirtGold));
            backpackTwo.AddSingleOre(new Ore(E_Minerals.DirtGold));


            //when
            guild.PaymentForDwarf(backpackOne, bankAccountOne, true);
            guild.PaymentForDwarf(backpackTwo, bankAccountTwo, true);

            //then
            Assert.AreEqual(1, guild.Account.OverallAccount);
            Assert.AreEqual(1.5, bankAccountOne.LastInput);
            Assert.AreEqual(1.5, bankAccountTwo.LastInput);
            Assert.IsTrue(backpackOne.ShowBackpackContent().Count == 0);
            Assert.IsTrue(backpackTwo.ShowBackpackContent().Count == 0);

        }

        [Test]
        public void ShouldReturnPaymentForTwoDwarvesWithTwoDirtGold()
        {
            //given

            BankAccount bankAccountOne = new BankAccount();
            BankAccount bankAccountTwo = new BankAccount();
            Backpack backpackOne = new Backpack();
            Backpack backpackTwo = new Backpack();
            backpackOne.AddSingleOre(new Ore(E_Minerals.DirtGold));
            backpackOne.AddSingleOre(new Ore(E_Minerals.DirtGold));
            backpackTwo.AddSingleOre(new Ore(E_Minerals.DirtGold));

            backpackTwo.AddSingleOre(new Ore(E_Minerals.DirtGold));

            //when
            guild.PaymentForDwarf(backpackOne, bankAccountOne, true);
            guild.PaymentForDwarf(backpackTwo, bankAccountTwo, true);

            //then
            Assert.AreEqual(2, guild.Account.OverallAccount);
            Assert.AreEqual(3, bankAccountOne.LastInput);
            Assert.AreEqual(3, bankAccountTwo.LastInput);
            Assert.IsTrue(backpackOne.ShowBackpackContent().Count == 0);
            Assert.IsTrue(backpackTwo.ShowBackpackContent().Count == 0);

        }

        [Test]
        public void ShouldReturnPaymentForTwoDwarvesWithDiffrentOres()
        {
            //given
            Mock<ICreateOreValue> fakeMarket = new Mock<ICreateOreValue>();
            Guild guild = new Guild(new Dictionary<E_Minerals, ICreateOreValue>()
            { { E_Minerals.DirtGold, fakeMarket.Object },
            { E_Minerals.Gold, fakeMarket.Object },
            { E_Minerals.Silver, fakeMarket.Object },
            { E_Minerals.Mithril, fakeMarket.Object }});
            fakeMarket.Setup(i => i.GenerateSingleValue()).Returns(1);
            BankAccount bankAccountOne = new BankAccount();
            BankAccount bankAccountTwo = new BankAccount();
            Backpack backpackOne = new Backpack();
            Backpack backpackTwo = new Backpack();
            backpackOne.AddSingleOre(new Ore(E_Minerals.DirtGold));
            backpackOne.AddSingleOre(new Ore(E_Minerals.Mithril));
            backpackTwo.AddSingleOre(new Ore(E_Minerals.Silver));
            backpackTwo.AddSingleOre(new Ore(E_Minerals.Gold));


            //when
            guild.PaymentForDwarf(backpackOne, bankAccountOne, true);
            guild.PaymentForDwarf(backpackTwo, bankAccountTwo, true);

            //then
            Assert.AreEqual(1, guild.Account.OverallAccount);
            Assert.AreEqual(1.5, bankAccountOne.LastInput);
            Assert.AreEqual(1.5, bankAccountTwo.LastInput);
            Assert.IsTrue(backpackOne.ShowBackpackContent().Count == 0);
            Assert.IsTrue(backpackTwo.ShowBackpackContent().Count == 0);

        }
    }
}
