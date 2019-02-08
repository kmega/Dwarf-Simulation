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

            guild = new Guild(new Dictionary<E_Minerals, ICreateOreValue>()
            { { E_Minerals.Gold, new ValueOfGold() },
                {E_Minerals.DirtGold, new ValueOfDirtGold() },
                {E_Minerals.Mithril, new ValueOfMithril() },
                {E_Minerals.Silver, new ValueOfSilver()}
            });


        }

        [Test]
        public void DwarfWithEmptyBackpack()
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
        public void DirtGoldForOneDwarf()
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
        public void DirtGoldForTwoDwarf()
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
        public void TwoDirtGoldForTwoDwarf()
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

    }
}
