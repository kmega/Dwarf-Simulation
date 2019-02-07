using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    [TestFixture]
    public class SplittingWorkers
    {
        [Test]
        public void IntoSingleTeamAndOneWaits()
        {
            //given
            var Splitter = new TeamSplitter();
            List<TemporaryWorker> templist = new List<TemporaryWorker>
            {
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true)
            };

            //when
            var result = Splitter.SplitWorkersIntoTeam(templist);

            //then
            Assert.IsTrue(result.Count == 5);
            Assert.IsTrue(templist.Count == 1);
        }

        [Test]
        public void OneThreeMembersTeam()
        {
            //given
            var Splitter = new TeamSplitter();
            List<TemporaryWorker> templist = new List<TemporaryWorker>
            {
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true),
                new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true)
            };
            //when
            var result = Splitter.SplitWorkersIntoTeam(templist);

            //then
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(templist.Count == 0);
        }
    }
}