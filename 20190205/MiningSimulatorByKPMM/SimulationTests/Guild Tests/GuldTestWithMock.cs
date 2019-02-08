using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using MiningSimulatorByKPMM.PersonalItems;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationTests.Guild_Tests
{
    class GuldTestWithMock
    {


        [Test]
        public void TwoDwarfWithDiffrentOre()
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
