using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_WorkProcessor
    {
        [Test]
        public void IfCanStillWorkShouldReturnTrue()
        {
            //given
            var WP = new WorkProcessor();
            var workers = FakeTemporaryWorkerFactory.CreateOneWorkingTemporaryWorkerNonSuicide();
            var schafts = new List<MiningSchaft> { new MiningSchaft() };

            //when
            var result = WP.IfCanStillWork(workers, schafts);

            //then
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IfCanStillWorkShouldReturnFalse()
        {
            //given
            var WP = new WorkProcessor();
            var workers = FakeTemporaryWorkerFactory.CreateOneWorkingTemporaryWorkerNonSuicide();
            var schaft = new MiningSchaft();
            schaft.DestroyShaftTEST();
            var schafts = new List<MiningSchaft> { schaft };

            //when
            var result = WP.IfCanStillWork(workers, schafts);

            //then
            Assert.AreEqual(false, result);
        }
    }
}
