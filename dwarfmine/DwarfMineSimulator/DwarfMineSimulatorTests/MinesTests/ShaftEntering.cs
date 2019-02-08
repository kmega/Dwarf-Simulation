using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    class ShaftEntering
    {
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
    }
}
