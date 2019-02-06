using System;
using MiningSimulatorByKPMM.Enums;
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
        public void GetsEveryMineralType()
        {

        }
    }
}
