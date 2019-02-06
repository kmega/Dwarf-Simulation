using System;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using Moq;
using NUnit.Framework;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class MineralRandomizer
    {
        [TestCase(E_Minerals.DirtGold)]
        [TestCase(E_Minerals.Gold)]
        [TestCase(E_Minerals.Mithril)]
        [TestCase(E_Minerals.Silver)]
        public void CreatesOreType(E_Minerals mineral)
        {
            //given
            Mock<IOreRandomizer> mockRandomizer = new Mock<IOreRandomizer>();
            mockRandomizer.Setup(x => x.GetRandomMineral()).Returns(new Ore(mineral));
            mockRandomizer.Setup(x => x.GetOreType()).Returns(mineral);

            //when
            var result = mockRandomizer.Object.GetOreType();

            //then
            Assert.IsTrue(mineral == result);
        }
    }
}