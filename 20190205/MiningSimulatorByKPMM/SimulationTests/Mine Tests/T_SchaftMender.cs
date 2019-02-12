using System;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_SchaftMender
    {
        [Test]
        public void MendsBothBrokenSchafts()
        {
            //given
            var schafts = SchaftFactory.CreateTwoSchafts();
            schafts.ForEach(x => x.DestroyShaft());
            var Mender = new SchaftMender();

            //when
            foreach (var schaft in schafts)
                Assert.IsTrue(schaft.GetSchaftStatus() == E_MiningSchaftStatus.Broken);
            Mender.FixSchafts(schafts);

            //then
            foreach (var schaft in schafts)
                Assert.IsTrue(schaft.GetSchaftStatus() == E_MiningSchaftStatus.Operational);
        }
    }
}
