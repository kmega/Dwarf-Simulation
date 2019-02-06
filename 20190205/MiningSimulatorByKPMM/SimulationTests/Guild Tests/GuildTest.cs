using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;

namespace SimulationTests.Guild_Tests
{
    public class GuildTest
    {
      
        Guild guild;

        [SetUp]
        public void Setup()
        {
           
            guild = new Guild();

        }

        [Test]
        public void DirtGoldForOneDwarf()
        {
            //given

            BankAccount bankAccount = new BankAccount();
            Backpack backpack = new Backpack();
            backpack.AddSingleOre(new Ore(E_Minerals.DirtGold));

            //when
            guild.PaymentForDwarf(backpack, bankAccount);

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
            guild.PaymentForDwarf(backpackOne, bankAccountOne);
            guild.PaymentForDwarf(backpackTwo, bankAccountTwo);

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
            guild.PaymentForDwarf(backpackOne, bankAccountOne);
            guild.PaymentForDwarf(backpackTwo, bankAccountTwo);

            //then
            Assert.AreEqual(2, guild.Account.OverallAccount);
            Assert.AreEqual(3, bankAccountOne.LastInput);
            Assert.AreEqual(3, bankAccountTwo.LastInput);
            Assert.IsTrue(backpackOne.ShowBackpackContent().Count == 0);
            Assert.IsTrue(backpackTwo.ShowBackpackContent().Count == 0);

        }




    }
}
