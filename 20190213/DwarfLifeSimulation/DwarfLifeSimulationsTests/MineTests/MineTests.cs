using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;

namespace Tests
{
    public class MineTests
    {
        private Mock<DwarfFactory> dwarfFactoryMock;

        [SetUp]
        public void Setup()
        {
            dwarfFactoryMock = new Mock<DwarfFactory>();
            dwarfFactoryMock.Setup(x => x.Create()).Returns(new Dwarf(name, dwarfType, new SuicideStrategy(), new BuyNoneStrategy()));
        }

        [Test]
        public void WhenSuiciderGoIntoShaftThenItShouldBeDestroyed()
        {
            // given
            var suicider = dwarfFactoryMock.Object;
            vat shaft = new Shaft();

            // when
            suicider.Work(shaft);

            // then
            Assert.IsTrue(shaft.ShaftStatus.Equals(ShaftStatus.Destroyed));
        }
    }
}