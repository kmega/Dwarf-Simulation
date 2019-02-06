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
        public void IntoTwoTeams()
        {
            //given
            List<Dwarf> dwarves = new List<Dwarf>
            {
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father),
                new Dwarf(E_DwarfType.Dwarf_Father)
            };

            var Splitter = new TeamSplitter();

            //when
            (List<Dwarf> team1, List<Dwarf> team2) = Splitter.SplitWorkersIntoTwoTeams(dwarves);

            //then
            Assert.IsTrue(team1.Count == 5);
            Assert.IsTrue(team2.Count == 5);
        }
    }
}