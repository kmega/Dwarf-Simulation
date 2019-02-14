using DwarfSimulation;
using NUnit.Framework;
using System.Collections.Generic;

namespace DwarfSimulationTests.MinesTests
{
    class WorkTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public void ShouldAddToOneShaft(int numberOfDwarfs, int shaft)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = builder.CreateDwarves(numberOfDwarfs);
            List<Shaft> shafts = builder.CreateShafts(shaft);

            // Given
            Mines mines = new Mines();
            mines.AddToShafts(dwarfs, shafts);

            // Assert
            Assert.IsTrue(shafts[0].Miners.Count == numberOfDwarfs);
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public void x(int numberOfDwarfs, int shaft)
        {
            // For
            Builder builder = new Builder();

            List<Dwarf> dwarfs = builder.CreateDwarves(numberOfDwarfs);
            List<Shaft> shafts = builder.CreateShafts(shaft);

            // Given
            Mines mines = new Mines();
            mines.AddToShafts(dwarfs, shafts);

            // Assert
            Assert.IsTrue(shafts[0].Miners.Count == numberOfDwarfs);
        }
    }
}
