using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;

namespace DwarfCreationTests
{
    public class DwarfCreationTests
    {
        private Mock<IDwarfNameRandomizer> nameRandomizerMock;
        [SetUp]
        public void Setup()
        {
            nameRandomizerMock = new Mock<IDwarfNameRandomizer>();
            nameRandomizerMock.Setup(x => x.GiveMeDwarfName()).Returns("Gimli");
        }

        [Test]
        public void T100_ShouldCreateDwarfFatherWithGimliName()
        {
            //given
            DwarfType dwarfType = DwarfType.Father;
            //when
            var dwarf = new DwarfFactory(nameRandomizerMock.Object).Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf._buyStrategy is BuyFoodStrategy);
            Assert.IsTrue(dwarf._workStrategy is StandardWorkStrategy);
            Assert.IsTrue(dwarf._name == "Gimli");
            Assert.IsTrue(dwarf._dwarfType == DwarfType.Father);
        }
        [Test]
        public void T101_ShouldCreateDwarfSingleWithGloinName()
        {
            //given
            DwarfType dwarfType = DwarfType.Single;
            nameRandomizerMock.Setup(x => x.GiveMeDwarfName()).Returns("Gloin");
            //when
            var dwarf = new DwarfFactory(nameRandomizerMock.Object).Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf._buyStrategy is BuyAlcoholStrategy);
            Assert.IsTrue(dwarf._workStrategy is StandardWorkStrategy);
            Assert.IsTrue(dwarf._name == "Gloin");
            Assert.IsTrue(dwarf._dwarfType == DwarfType.Single);
        }
        [Test]
        public void T102_ShouldCreateDwarfSluggard()
        {
            //given
            DwarfType dwarfType = DwarfType.Sluggard;
            //when
            var dwarf = new DwarfFactory(nameRandomizerMock.Object).Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf._buyStrategy is BuyNoneStrategy);
            Assert.IsTrue(dwarf._workStrategy is StandardWorkStrategy);
            Assert.IsTrue(dwarf._dwarfType == DwarfType.Sluggard);
        }
        [Test]
        public void T103_ShouldCreateDwarfSuicide()
        {
            //given
            DwarfType dwarfType = DwarfType.Suicide;
            //when
            var dwarf = new DwarfFactory(nameRandomizerMock.Object).Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf._buyStrategy is BuyNoneStrategy);
            Assert.IsTrue(dwarf._workStrategy is SuicideStrategy);
            Assert.IsTrue(dwarf._dwarfType == DwarfType.Suicide);
        }
    }
}