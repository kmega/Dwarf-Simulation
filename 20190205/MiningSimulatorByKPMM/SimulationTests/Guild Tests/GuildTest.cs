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
        GeneralBank bank;
        Guild guild;

        [SetUp]
        public void Setup()
        {
            bank = new GeneralBank();
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
            guild.PaymentForDwarf(backpack, bankAccount, bank);

            //then
            Assert.AreEqual(0.5, guild.Account.OverallAccount);
            Assert.AreEqual(1.5, bankAccount.DailyPayment);
            Assert.IsNull(backpack.ShowBackpackContent());



        }




    }
}
