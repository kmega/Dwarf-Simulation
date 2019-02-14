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
        }

        [Test]
        public void WhenSuiciderGoIntoShaftThenItShouldBeDestroyed()
        {
            // given
            var suicider = new DwarfFactory(nameRandomizerMock.Object).Create(DwarfType.Suicide);
            var notSuicider =  new DwarfFactory(nameRandomizerMock.Object).Create(DwarfType.Father);
            var shaftWithSuicider = new Shaft();
            var shaftWithoutSuicider = new Shaft();

            // when
            notSuicider.Work(shaftWithoutSuicider);
            suicider.Work(shaftWithSuicider);

            // then
            Assert.IsTrue(shaftWithoutSuicider.ShaftStatus.Equals(ShaftStatus.Working));
            Assert.IsTrue(shaftWithSuicider.ShaftStatus.Equals(ShaftStatus.Destroyed));
        }
    }
}