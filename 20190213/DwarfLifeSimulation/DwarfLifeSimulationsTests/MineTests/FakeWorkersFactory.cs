using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulationsTests.MineTests
{
    internal class FakeWorkersFactory
    {
        private Mock<IDwarfNameRandomizer> nameMock;

        public FakeWorkersFactory()
        {
            nameMock = new Mock<IDwarfNameRandomizer>();
            nameMock.Setup(n => n.GiveMeDwarfName()).Returns("Gimli");
        }

        internal List<IWork> Create(int numberOfDwarves)
        {
            var factory = new DwarfFactory(nameMock.Object);
            List<IWork> list = new List<IWork>();
            for (int i = 0; i < numberOfDwarves; i++)
            {
                list.Add(factory.Create(DwarfType.Father));
            }
            return list;
        }
    }
}
