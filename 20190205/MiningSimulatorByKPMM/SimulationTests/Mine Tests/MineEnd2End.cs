using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class MineEnd2End
    {
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(15)]
        public void PostiveVersionWithoutSlaggers(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateXNonSluggardWorkers(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) = FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(backpacks, dwarfTypes, bools);

            //then
            Assert.IsTrue(Mine.GetTemporaryWorkers().Exists(x => x.backpack.ShowBackpackContent().Count != 0));
            Assert.IsTrue(Mine.GetTemporaryWorkers().Exists(x => x.isAlive == true));
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(15)]
        public void NegativeVersionWithSingleSlagger(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateSluggardWorkers(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) = FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(backpacks, dwarfTypes, bools);

            //then
            Assert.IsTrue(Mine.GetTemporaryWorkers().Exists(x => x.isAlive == false));
        }
    }
}

