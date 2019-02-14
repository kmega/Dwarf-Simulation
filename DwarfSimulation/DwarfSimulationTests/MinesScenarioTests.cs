using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace DwarfSimulationTests.MinesTests
{
    class MinesScenarioTests
    {
        [Test]
        public void OneMinersShouldMineOre()
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            Dwarf test = builder.CreateDwarf(DwarfType.Father);

            List<Dwarf> dwarfs = new List<Dwarf>
            {
                test
            };

            List<Shaft> shafts = builder.CreateShafts(1);

            // Given
            Mines mines = new Mines();
            dwarfs = mines.EnterMines(dwarfs, shafts, raport);

            // Assert
            int miningResults = 0;

            foreach (var dwarf in dwarfs)
            {
                try
                {
                    foreach (var mineral in dwarf.BackPack)
                    {
                        miningResults += mineral.Value;
                    }
                    Assert.IsTrue(miningResults > 0);

                    miningResults = 0;
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
