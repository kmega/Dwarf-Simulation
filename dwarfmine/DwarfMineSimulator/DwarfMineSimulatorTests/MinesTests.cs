using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    public class MinesTests
    {
        [Test]
        public void x()
        {
            // For
            Mines mines = new Mines();

            List<Dwarf> dwarfs = new List<Dwarf>();
            List<Shaft> shafts = new List<Shaft>();

            // Given
            dwarfs.Add(new Dwarf({ Type = DwarfTypes.Father });
            shafts.Add(new Shaft());

            dwarfs = mines.MineInShafts(dwarfs, shafts);
            Dictionary<Minerals, int> results = dwarfs[0].MineralsMined;

            // Assert
            List<int> listOfValues = new List<int>();
            listOfValues.AddRange(results.Values);

            int mineralsMined = 0;

            for (int i = 0; i < results.Count; i++)
            {
                mineralsMined += listOfValues[i];
            }

            Assert.IsTrue(mineralsMined > 0);
        }
    }
}