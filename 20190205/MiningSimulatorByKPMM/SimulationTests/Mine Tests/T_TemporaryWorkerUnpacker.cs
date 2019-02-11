using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class T_TemporaryWorkerUnpacker
    {
        [Test]
        public void ProperlyUnpacksWorkerAndUpdatesParams()
        {
            //given
            var workers = FakeTemporaryWorkerFactory.CreateOneWorkingTemporaryWorkerNonSuicide();
            List<Backpack> backpacks = new List<Backpack> { new Backpack() };
            List<E_DwarfType> _DwarfTypes = new List<E_DwarfType> { E_DwarfType.Dwarf_Father };
            List<bool> isAlive = new List<bool> { true };

            Assert.IsTrue(backpacks[0].ShowBackpackContent().Count == 0);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == 0);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == backpacks[0].ShowBackpackContent().Count);

            var TWU = new TemporaryWorkerUnpacker();

            //when
            workers[0].backpack.AddSingleOre(new Ore(E_Minerals.Mithril));
            TWU.ChangesStatesFromUnpackedTemporaryWorkers( ref backpacks, ref _DwarfTypes, ref isAlive, workers);

            //then
            Assert.IsTrue(backpacks[0].ShowBackpackContent().Count == 1);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == 1);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent()[0].OutputType == E_Minerals.Mithril);
            Assert.IsTrue(workers[0].backpack.ShowBackpackContent().Count == backpacks[0].ShowBackpackContent().Count);
        }
    }
}
