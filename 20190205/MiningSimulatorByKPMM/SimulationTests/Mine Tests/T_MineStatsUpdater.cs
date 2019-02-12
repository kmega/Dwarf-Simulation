using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_MineStatsUpdater
    {
        [Test]
        public void UpdatesDailyStatsWithProvidedData()
        {
            //given
            Dictionary<E_Minerals, int> MineSupervisorStats = new Dictionary<E_Minerals, int>()
            {
                {E_Minerals.DirtGold, 0},
                {E_Minerals.Gold, 0},
                {E_Minerals.Mithril, 0},
                {E_Minerals.Silver, 0},
            };
            var MSU = new MineStatsUpdater();
            var workers = FakeTemporaryWorkerFactory.CreateOneWorkingTemporaryWorkerNonSuicide();
            workers[0].backpack.AddSingleOre(new Ore(E_Minerals.Gold));
            workers[0].backpack.AddSingleOre(new Ore(E_Minerals.Mithril));

            //when
            MSU.UpdateDailyStats(workers, MineSupervisorStats);

            //then
            Assert.IsTrue(MineSupervisorStats[E_Minerals.Gold] == 1);
            Assert.IsTrue(MineSupervisorStats[E_Minerals.Mithril] == 1);
        }


    }
}
