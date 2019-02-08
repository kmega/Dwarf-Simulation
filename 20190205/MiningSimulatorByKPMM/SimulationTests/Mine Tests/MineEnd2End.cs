using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
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
        public void PostiveVersionWithoutSuicide(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateXNonSuicideWorkers(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) = FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(ref backpacks, dwarfTypes, ref bools);

            //then
            Assert.IsTrue(Mine.GetPreviousShiftOfMine().Exists(x => x.backpack.ShowBackpackContent().Count != 0));
            Assert.IsTrue(Mine.GetPreviousShiftOfMine().Exists(x => x.isAlive == true));
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(15)]
        public void NegativeVersionWithSingleSuicide(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateSuicideWorkers(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) =
                FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(ref backpacks, dwarfTypes, ref bools);
            var deadWorkersCount = Mine.GetPreviousShiftOfMine().Count(x => x.isAlive == false);
            var backpacksContentCount = Mine.GetPreviousShiftOfMine().Count(x =>
                                                        x.backpack.ShowBackpackContent().Count > 0);

            //then
            if (amount <= 5)
                Assert.IsTrue(deadWorkersCount == amount);
            else
            {
                Assert.IsTrue(deadWorkersCount == 5);
                Assert.IsTrue(backpacksContentCount == amount - deadWorkersCount);
            }
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[0] == E_MiningSchaftStatus.Broken);
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[1] == E_MiningSchaftStatus.Operational);
        }

        [TestCase(7)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(15)]
        public void NegativeVersionWithSingleSuicideInSecondSchaft(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateSuicideWorkerOnlyInSecondSchaft(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) =
                FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(ref backpacks, dwarfTypes, ref bools);

            //then
            Assert.IsTrue(Mine.GetPreviousShiftOfMine().Any(x => x.isAlive == true));
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[0] == E_MiningSchaftStatus.Operational);
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[1] == E_MiningSchaftStatus.Broken);
        }

        [TestCase(7)]
        [TestCase(10)]
        public void NegativeVersionWithTwoSuicide(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateTwoSuicideWorkersInBothTeams(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) =
                FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(ref backpacks, dwarfTypes, ref bools);

            //then
            Assert.IsTrue(Mine.GetPreviousShiftOfMine().Exists(x => x.isAlive == false));
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[0] == E_MiningSchaftStatus.Broken);
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[1] == E_MiningSchaftStatus.Broken);
        }

        [TestCase(12)]
        [TestCase(15)]
        public void NegativeVersionWithTwoSuicideAndSomeWorkersSurvive(int amount)
        {
            //given
            var Mine = new MineSupervisor();
            var workers = FakeDataFactory.CreateTwoSuicideWorkersInBothTeams(amount);
            (List<Backpack> backpacks, List<E_DwarfType> dwarfTypes, List<bool> bools) =
                FakeDataFactory.ExtractListsFromWorkers(workers);

            //when
            Mine.Work(ref backpacks, dwarfTypes, ref bools);

            //then
            Assert.IsTrue(Mine.GetPreviousShiftOfMine().Any(x => x.isAlive == true));
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[0] == E_MiningSchaftStatus.Broken);
            Assert.IsTrue(Mine.GetTwoSchaftsStatus()[1] == E_MiningSchaftStatus.Broken);
        }
    }
}