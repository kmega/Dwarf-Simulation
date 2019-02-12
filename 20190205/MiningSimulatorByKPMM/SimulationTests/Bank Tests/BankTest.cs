using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;

namespace SimulationTests.Bank_Tests
{
    public class BankTest
    {
        GeneralBank bank;
        

        [SetUp]
        public void Setup()
        {
            bank = new GeneralBank();

        }

        [Test]
        public void ShouldReturnTaxFor100()
        {
            //when
            bank.PayTax(100);

            //then
            Assert.IsTrue(bank.BankTresure() == 23);

        }

        [Test]
        public void ShouldReturnTresureAfterTwoDwarvesPaidTax()
        {
            //when
            bank.PayTax(100);
            bank.PayTax(50);

            //then
            Assert.IsTrue(bank.BankTresure() == 34.5m);

        }



    }
}
