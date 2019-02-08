using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    class ShaftsResponsibilities
    {
        [Test]
        public void TwoMinersShouldEnterOneShaft()
        {
            // For
            Shafts shafts = new Shafts();

            Shaft shaft = new Shaft();
            List<Dwarf> dwarfs = new List<Dwarf>();

            // Given
            for (int i = 0; i < 2; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }

            shaft = shafts.AddToShaft(shaft, dwarfs);

            // Assert
            Assert.IsTrue(shaft.Miners.Count == 2);
        }

        [Test]
        public void FiveMinersShouldEnterOneShaft()
        {
            // For
            Shafts shafts = new Shafts();

            Shaft shaft = new Shaft();
            List<Dwarf> dwarfs = new List<Dwarf>();

            // Given
            for (int i = 0; i < 5; i++)
            {
                dwarfs.Add(new Dwarf() { Type = DwarfTypes.Father });
            }

            shaft = shafts.AddToShaft(shaft, dwarfs);

            // Assert
            Assert.IsTrue(shaft.Miners.Count == 5);
        }

        [Test]
        public void SuiciderShouldKillEveryoneInShaftAndCollapseThisShaft()
        {
            // For
            Shafts shafts = new Shafts();

            Shaft shaft = new Shaft();

            // Given
            for (int i = 0; i < 4; i++)
            {
                shaft.Miners.Add(new Dwarf() { Type = DwarfTypes.Father });
            }
            shaft.Miners.Add(new Dwarf() { Type = DwarfTypes.Suicider });

            shaft = shafts.CheckForSuicider(shaft);

            // Assert
            Assert.IsTrue(shaft.Miners.Count == 5);

            for (int i = 0; i < shaft.Miners.Count; i++)
            {
                Assert.IsTrue(shaft.Miners[i].Alive == false);
            }

            Assert.IsTrue(shaft.Collapsed == true);
        }
    }
}
