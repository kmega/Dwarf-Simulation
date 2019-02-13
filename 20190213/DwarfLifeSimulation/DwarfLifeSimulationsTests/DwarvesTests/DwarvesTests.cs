using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mine;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;

namespace Tests
{
    public class DwarvesTests
    {   
        private Mock<IWorkStrategy> workStrategy;
        
        [SetUp]
        public void Setup()
        {
            workStrategy = new Mock<IWorkStrategy>();
        }

        [Test]           
        public void ShoudDigOnlyMihrils(DwarfNames dwarfName)
        {
            Assert.Pass();
        }
    }
}