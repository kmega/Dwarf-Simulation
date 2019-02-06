using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine;
using NUnit.Framework;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class SplittingWorkers
    {
        [Test]
        public void IntoSingleTeam()
        {
            //given
            var Splitter = new TeamSplitter();

            //when
            var result = Splitter.SplitWorkersIntoTeam(10);

            //then
            Assert.IsTrue(result == 5);
        }

        [Test]
        public void IntoSmallerTeam()
        {
            //given
            var Splitter = new TeamSplitter();

            //when
            var result = Splitter.SplitWorkersIntoTeam(3);

            //then
            Assert.IsTrue(result == 3);
        }
    }
}