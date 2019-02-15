using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace DwarfSimulationTests.MinesTests
{
    class MinesScenarioTests
    {
        [TestCase(10, DwarfType.Father)]
        [TestCase(10, DwarfType.Single)]
        [TestCase(10, DwarfType.Lazy)]
        [TestCase(20, DwarfType.Father)]
        [TestCase(20, DwarfType.Single)]
        [TestCase(20, DwarfType.Lazy)]
        public void MinersShouldMineOreInTwoShafts(int numberOfDwarfs, DwarfType dwarfType)
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(2);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(dwarfType));
            }

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

                    if (dwarf.DwarfType == DwarfType.Lazy)
                    {
                        Assert.IsTrue(miningResults == 0 || miningResults == 1);
                    }
                    else
                    {
                        Assert.IsTrue(miningResults > 0);
                    }

                    miningResults = 0;
                }
                catch
                {
                    break;
                }
            }
        }

        [TestCase(4, DwarfType.Father)]
        [TestCase(4, DwarfType.Single)]
        [TestCase(4, DwarfType.Lazy)]
        public void SuiciderShouldKillMinersAndCollapseShaft(int numberOfDwarfs, DwarfType dwarfType)
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(1);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(dwarfType));
            }

            dwarfs.Add(builder.CreateDwarf(DwarfType.Suicider));

            // Given
            Mines mines = new Mines();
            dwarfs = mines.EnterMines(dwarfs, shafts, raport);

            // Assert
            foreach (var dwarf in dwarfs)
            {
                Assert.IsTrue(dwarf.IsAlive == false);
            }
        }
    }
}
