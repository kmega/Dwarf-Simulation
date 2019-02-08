using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;
using MiningSimulatorByKPMM.PersonalItems;
using Moq;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{

    [TestFixture]
    public class MiningSchaftPositiveProcess
    {
        [TestCase(E_Minerals.DirtGold)]
        [TestCase(E_Minerals.Gold)]
        [TestCase(E_Minerals.Mithril)]
        [TestCase(E_Minerals.Silver)]
        public void GivesMinerSingleCeratinOre(E_Minerals mineral)
        {
            //given
            Mock<IOreRandomizer> oreRandomizer = new Mock<IOreRandomizer>();
            oreRandomizer.Setup(x => x.GetRandomMineral()).Returns(new Ore(mineral));

            Mock<IOreUnitAmountRandomizer> oreUnitAmountRandomizer = new Mock<IOreUnitAmountRandomizer>();
            oreUnitAmountRandomizer.Setup(x => x.GetAmountOfOreUnintsToRandom()).Returns(1);

            var schaft = new MiningSchaft();
            var workers = FakeDataFactory.CreateXNonSuicideWorkers(1);

            //when
            schaft.SetSchaftWorkers(workers);
            schaft.ExecuteWorkStrategy(oreRandomizer.Object, oreUnitAmountRandomizer.Object);

            //then
            Assert.IsTrue(workers[0].isAlive == true);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == 1);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Any(x => x.OutputType == mineral));
        }

        [TestCase(2)]
        [TestCase(3)]
        public void GivesMinersAmountOfRandomOres(int amount)
        {
            //given
            Mock<IOreUnitAmountRandomizer> oreUnitAmountRandomizer = new Mock<IOreUnitAmountRandomizer>();
            oreUnitAmountRandomizer.Setup(x => x.GetAmountOfOreUnintsToRandom()).Returns(amount);

            var schaft = new MiningSchaft();
            var workers = FakeDataFactory.CreateXNonSuicideWorkers(5);

            //when
            schaft.SetSchaftWorkers(workers);
            schaft.ExecuteWorkStrategy(new OreRandomizer(), oreUnitAmountRandomizer.Object);

            //then
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(workers[i].isAlive == true);
                Assert.IsTrue(workers[i].backpack.ShowBackpackContent().Count == amount);
            }
        }
    }

    [TestFixture]
    public class MiningSchaftNegativeProcess
    {
        [Test]
        public void ExplodesWithSingleWorkerWhoIsSuicide()
        {
            //given
            var oreRandomizer = new OreRandomizer();
            var oreUnitAmountRandomizer = new OreUnitAmountRandomizer();

            var schaft = new MiningSchaft();
            var workers = FakeDataFactory.CreateSuicideWorkers(1);
            //when
            schaft.SetSchaftWorkers(workers);
            schaft.ExecuteWorkStrategy(oreRandomizer, oreUnitAmountRandomizer);

            //then
            Assert.IsTrue(workers[0].isAlive == false);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == 0);
            Assert.IsTrue(schaft.GetSchaftStatus() == E_MiningSchaftStatus.Broken);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void ExplodesWithWorkersAndKillsEverybody(int amount)
        {
            //given
            var oreRandomizer = new OreRandomizer();
            var oreUnitAmountRandomizer = new OreUnitAmountRandomizer();

            var schaft = new MiningSchaft();
            var workers = FakeDataFactory.CreateSuicideWorkers(amount);

            //when
            schaft.SetSchaftWorkers(workers);
            schaft.ExecuteWorkStrategy(oreRandomizer, oreUnitAmountRandomizer);

            //then
            for (int i = 0; i < amount; i++)
            {
                Assert.IsTrue(workers[i].isAlive == false);
                Assert.IsTrue(workers[i].backpack.ShowBackpackContent().Count == 0);
            }
            Assert.IsTrue(schaft.GetSchaftStatus() == E_MiningSchaftStatus.Broken);
        }
    }
}
