using System;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_StaffDisposer
    {
        [Test]
        public void Sends10WorkersIntoBothSchafts()
        {
            //given
            var SD = new StaffDisposer();
            var schafts = SchaftFactory.CreateTwoSchafts();
            var workers = FakeTemporaryWorkerFactory.CreateNWorkingTemporaryWorkerNonSuicide(10);

            //when
            SD.SendWorokersToCertainSchafts(schafts, workers);

            //then
            Assert.IsTrue(schafts[0].GetWorkers().Count == 5);
            Assert.IsTrue(schafts[1].GetWorkers().Count == 5);
            Assert.IsTrue(workers.Count == 0);
        }

        [Test]
        public void Sends7WorkersIntoBothSchafts()
        {
            //given
            var SD = new StaffDisposer();
            var schafts = SchaftFactory.CreateTwoSchafts();
            var workers = FakeTemporaryWorkerFactory.CreateNWorkingTemporaryWorkerNonSuicide(7);

            //when
            SD.SendWorokersToCertainSchafts(schafts, workers);

            //then
            Assert.IsTrue(schafts[0].GetWorkers().Count == 5);
            Assert.IsTrue(schafts[1].GetWorkers().Count == 2);
            Assert.IsTrue(workers.Count == 0);
        }

        [Test]
        public void Sends3WorkersIntoFirstSchaft()
        {
            //given
            var SD = new StaffDisposer();
            var schafts = SchaftFactory.CreateTwoSchafts();
            var workers = FakeTemporaryWorkerFactory.CreateNWorkingTemporaryWorkerNonSuicide(3);

            //when
            SD.SendWorokersToCertainSchafts(schafts, workers);

            //then
            Assert.IsTrue(schafts[0].GetWorkers().Count == 3);
            Assert.IsTrue(schafts[1].GetWorkers().Count == 0);
            Assert.IsTrue(workers.Count == 0);
        }
    }
}
