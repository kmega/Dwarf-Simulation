using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;

namespace DwarfCreationTests
{
    public class DwarfCreationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void T100_ShouldCreateDwarfFather()
        {
            //given
            DwarfType dwarfType = DwarfType.Father;
            //when
            var dwarf = DwarfFactory.Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf.buyStrategy is BuyFoodStrategy);
            Assert.IsTrue(dwarf.workStrategy is StandardWorkStrategy);
        }
        [Test]
        public void T101_ShouldCreateDwarfSingle()
        {
            //given
            DwarfType dwarfType = DwarfType.Single;
            //when
            var dwarf = DwarfFactory.Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf.buyStrategy is BuyAlcoholStrategy);
            Assert.IsTrue(dwarf.workStrategy is StandardWorkStrategy);
        }
        [Test]
        public void T102_ShouldCreateDwarfSluggard()
        {
            //given
            DwarfType dwarfType = DwarfType.Sluggard;
            //when
            var dwarf = DwarfFactory.Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf.buyStrategy is BuyNoneStrategy);
            Assert.IsTrue(dwarf.workStrategy is StandardWorkStrategy);
        }
        [Test]
        public void T103_ShouldCreateDwarfSuicide()
        {
            //given
            DwarfType dwarfType = DwarfType.Suicide;
            //when
            var dwarf = DwarfFactory.Create(dwarfType);
            //then            
            Assert.IsTrue(dwarf.buyStrategy is BuyNoneStrategy);
            Assert.IsTrue(dwarf.workStrategy is SuicideStrategy);
        }
    }
}