using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    public class MinesTests
    {
        [Test]
        public void OneMinerShouldMineMinerals()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
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
    }
}