using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;

namespace Tests
{
    public class MineTests
    {
        private Mock<IDwarfNameRandomizer> nameRandomizerMock;
        private Mock<IDwarfTypeRandomizer> dwarfTypeRandomizer;

        [SetUp]
        public void Setup()
        {
            nameRandomizerMock = new Mock<IDwarfNameRandomizer>();
            nameRandomizerMock.Setup(x => x.GiveMeDwarfName()).Returns("Gimli");

            dwarfTypeRandomizer = new Mock<IDwarfTypeRandomizer>();
            dwarfTypeRandomizer.Setup(x => x.GiveMeDwarfType(false)).Returns(DwarfType.Suicide);
        }

        [Test]
        public void WhenSuiciderGoIntoShaftThenItShouldBeDestroyed()
        {
            // given
            var suicider = new DwarfFactory(nameRandomizerMock.Object).Create(DwarfType.Suicide);
            var shaft = new Shaft();

            // when
            suicider.Work(shaft);

            // then
            Assert.IsTrue(shaft.ShaftStatus.Equals(ShaftStatus.Destroyed));
        }
    }
}