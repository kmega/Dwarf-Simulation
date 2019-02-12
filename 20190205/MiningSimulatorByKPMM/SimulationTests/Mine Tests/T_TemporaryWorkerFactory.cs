using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_TemporaryWorkerFactory
    {
        [Test]
        public void ThrowsExceptionWhenListsAreNotEqual()
        {
            //given
            List<Backpack> backpacks = new List<Backpack> { new Backpack() };
            List<E_DwarfType> dwarfTypes = new List<E_DwarfType> { E_DwarfType.Dwarf_Father, E_DwarfType.Dwarf_Single };
            List<bool> isAlive = new List<bool> { true };

            //when
            var TWF = new TemporaryWorkerFactory();
            var ex = Assert.Throws<ArgumentException>(() => TWF.CreateListTemporaryWorkersFromParameters(backpacks, dwarfTypes, isAlive));

            //then
            Assert.That(ex.Message == "Lists are not eqaul");
        }
    }
}
