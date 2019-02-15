using DwarfSimulation;
using NUnit.Framework;
using System.Collections.Generic;

namespace DwarfSimulationTests.MinesTests
{
    class WorkLogicTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public void ShouldAddToOneShaft(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            // Given
            Work work = new Work();
            work.AddToShafts(dwarfs, shafts);

            // Assert
            Assert.IsTrue(shafts[0].Miners.Count == numberOfDwarfs);
        }

        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 2)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        public void ShouldAddToTwoShafts(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            // Given
            Work work = new Work();
            work.AddToShafts(dwarfs, shafts);

            // Assert
            Assert.IsTrue(shafts[0].Miners.Count == 5);
            Assert.IsTrue(shafts[1].Miners.Count == numberOfDwarfs - 5);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        public void ShouldCheckForSuicidersInOneShaft(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            dwarfs.Add(builder.CreateDwarf(DwarfType.Suicider));

            // Given
            Work work = new Work();
            work.AddToShafts(dwarfs, shafts);

            // Assert
            Assert.IsTrue(shafts[0].WorkAction is SuiciderWorkStrategy);
        }

        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 2)]
        public void ShouldCheckForSuicidersInTwoShafts(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            dwarfs.Add(builder.CreateDwarf(DwarfType.Suicider));

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            dwarfs.Add(builder.CreateDwarf(DwarfType.Suicider));

            // Given
            Work work = new Work();
            work.AddToShafts(dwarfs, shafts);

            // Assert
            foreach (var shaft in shafts)
            {
                Assert.IsTrue(shaft.WorkAction is SuiciderWorkStrategy);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnFalseWhenAtLeastOneShaftIsOperational(int numberOfShafts)
        {
            // For
            Builder builder = new Builder();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            // Given
            Mines mines = new Mines();
            bool result = mines.CheckShaftsStatus(shafts);

            // Assert
            Assert.IsTrue(result == false);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ShouldReturnTrueWhenAllShaftsAreCollapsed(int numberOfShafts)
        {
            // For
            Builder builder = new Builder();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            // Given
            for (int index = 0; index < shafts.Count; index++)
            {
                try
                {
                    shafts[index].Collapsed = true;
                }
                catch
                {
                    break;
                }
            }

            Mines mines = new Mines();
            bool result = mines.CheckShaftsStatus(shafts);

            // Assert
            Assert.IsTrue(result == true);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 2)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        public void MinersShouldMineOre(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            Raport raport = new Raport();

            // Given
            Work work = new Work();
            shafts = work.AddToShafts(dwarfs, shafts);

            shafts = work.MineForOre(shafts, raport);

            // Assert
            int miningResults = 0;

            foreach (var shaft in shafts)
            {
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

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public void ShouldRemoveFromOneShaft(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            Raport raport = new Raport();

            // Given
            Work work = new Work();
            shafts = work.AddToShafts(dwarfs, shafts);

            dwarfs = work.RemoveFromShafts(shafts);

            // Assert
            Assert.IsTrue(shafts[0].Miners.Count == 0);
        }

        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 2)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        public void ShouldRemoveFromTwoShafts(int numberOfDwarfs, int numberOfShafts)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = builder.CreateShafts(numberOfShafts);

            for (int index = 0; index < numberOfDwarfs; index++)
            {
                dwarfs.Add(builder.CreateDwarf(DwarfType.Father));
            }

            Raport raport = new Raport();

            // Given
            Work work = new Work();
            shafts = work.AddToShafts(dwarfs, shafts);

            dwarfs = work.RemoveFromShafts(shafts);

            // Assert
            foreach (var shaft in shafts)
            {
                Assert.IsTrue(shaft.Miners.Count == 0);
            }
        }
    }
}
