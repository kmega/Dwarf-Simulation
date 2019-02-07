using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    public class MinesTests
    {
        [Test]
        public void TwoMinerShouldMineMinerals()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });

            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            Dictionary<Minerals, int> results = dwarfs[0].MineralsMined;
            List<int> listOfValues = new List<int>();

            listOfValues.AddRange(results.Values);
            int mineralsMined = 0;

            for (int i = 0; i < results.Count; i++)
            {
                mineralsMined += listOfValues[i];
            }

            Assert.IsTrue(mineralsMined > 0);
        }

        [Test]
        public void TenMinerShouldMineMinerals()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            for (int i = 0; i < 10; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            Dictionary<Minerals, int> results;
            List<int> listOfValues = new List<int>();

            int mineralsMined = 0;

            for (int i = 0; i < dwarfs.Count; i++)
            {
                results = dwarfs[i].MineralsMined;
                listOfValues.AddRange(results.Values);

                for (int j = 0; j < results.Count; j++)
                {
                    mineralsMined += listOfValues[j];
                }

                Assert.IsTrue(mineralsMined > 0);
                mineralsMined = 0;
            }
        }

        [Test]
        public void TwelveMinerShouldMineMineralsInTwoShafts()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            for (int i = 0; i < 12; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            Dictionary<Minerals, int> results;
            List<int> listOfValues = new List<int>();

            int mineralsMined = 0;

            for (int i = 0; i < dwarfs.Count; i++)
            {
                results = dwarfs[i].MineralsMined;
                listOfValues.AddRange(results.Values);

                for (int j = 0; j < results.Count; j++)
                {
                    mineralsMined += listOfValues[j];
                }

                Assert.IsTrue(mineralsMined > 0);
                mineralsMined = 0;
            }
        }

        [Test]
        public void TwentyMinerShouldMineMineralsInTwoShafts()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            for (int i = 0; i < 10; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            Dictionary<Minerals, int> results;
            List<int> listOfValues = new List<int>();

            int mineralsMined = 0;

            for (int i = 0; i < dwarfs.Count; i++)
            {
                results = dwarfs[i].MineralsMined;
                listOfValues.AddRange(results.Values);

                for (int j = 0; j < results.Count; j++)
                {
                    mineralsMined += listOfValues[j];
                }

                Assert.IsTrue(mineralsMined > 0);
                mineralsMined = 0;
            }
        }

        [Test]
        public void SuiciderShouldKillEveryoneInShaftAndCollapseShaft()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            for (int i = 0; i < 4; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }
            dwarfs.Add(new Dwarf() { Type = DwarfTypes.Suicider });
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            for (int i = 0; i < dwarfs.Count; i++)
            {
                Assert.IsTrue(dwarfs[i].Alive == false);
            }
        }

        [Test]
        public void AllMinersShouldBeComeBackFromMinesWhenTwoShaftsAreCollapsedAtTheSameTime()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            dwarfs.Add(new Dwarf() { Type = DwarfTypes.Suicider });

            for (int i = 0; i < 19; i++)
            {
                if (i == 12)
                {
                    dwarfs.Add(new Dwarf() { Type = DwarfTypes.Suicider });
                }
                else
                {
                    dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
                }
            }

            shafts.Add(new Shaft());
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);

            // Assert
            Dictionary<Minerals, int> results;
            List<int> listOfValues = new List<int>();

            int mineralsMined = 0;

            for (int i = 0; i < dwarfs.Count; i++)
            {
                if (i < 5)
                {
                    Assert.IsTrue(dwarfs[i].Alive == false);
                }
                else if (i >= 5 && i < 10)
                {
                    results = dwarfs[i].MineralsMined;
                    listOfValues.AddRange(results.Values);

                    for (int j = 0; j < results.Count; j++)
                    {
                        mineralsMined += listOfValues[0];
                        listOfValues.RemoveAt(0);
                    }

                    Assert.IsTrue(mineralsMined > 0);
                }
                else if (i >= 10 && i < 15)
                {
                    Assert.IsTrue(dwarfs[i].Alive == false);
                }
                else
                {
                    if (i == 15)
                    {
                        mineralsMined = 0;
                    }
                    results = dwarfs[i].MineralsMined;
                    listOfValues.AddRange(results.Values);

                    for (int j = 0; j < results.Count; j++)
                    {
                        mineralsMined += listOfValues[0];
                        listOfValues.RemoveAt(0);
                    }

                    Assert.IsTrue(mineralsMined == 0);
                }
            }
        }
    }
}