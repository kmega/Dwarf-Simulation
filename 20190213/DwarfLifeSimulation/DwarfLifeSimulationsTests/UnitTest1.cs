using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Hospital;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;

namespace Tests
{
    public class DwarfCreationTests
    {
        private Mock<IDwarfTypeRandomizer> nameRandomizerMock;
        private Mock<IIsDwarfBornRandomizer> isBornMock;
        [SetUp]
        public void Setup()
        {
            nameRandomizerMock = new Mock<IDwarfTypeRandomizer>();
            isBornMock = new Mock<IIsDwarfBornRandomizer>();
        }

        [Test]
        public void Test1()
        {
            nameRandomizerMock.Setup(x => x.GiveMeDwarfType(false))
                .Returns(DwarfType.Single);

            Hospital hospital = new Hospital()
            Assert.Pass();
        }
    }
}