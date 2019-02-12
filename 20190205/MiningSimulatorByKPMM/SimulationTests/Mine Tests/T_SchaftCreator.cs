using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;
using NUnit.Framework;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_SchaftCreator
    {
        [Test]
        public void CreatesTwoWithOperationalStatus()
        {
            //given
            List<MiningSchaft> schafts = SchaftFactory.CreateTwoSchafts();
            E_MiningSchaftStatus expectedStaus = E_MiningSchaftStatus.Operational;

            //then
            Assert.IsTrue(schafts[0].GetSchaftStatus() == expectedStaus);
            Assert.IsTrue(schafts[1].GetSchaftStatus() == expectedStaus);
        }
    }
}
