using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;

namespace Tests
{
    public class DwarfNameRandomizerTests
    {
        private Mock<IDwarfNameRandomizer> dwarfNameRandomizer;
        
        [SetUp]
        public void Setup()
        {
            dwarfNameRandomizer = new Mock<IDwarfNameRandomizer>();
        }

        [TestCase(DwarfNames.None)]           
        [TestCase(DwarfNames.Blick)]
        [TestCase(DwarfNames.Flick)]
        [TestCase(DwarfNames.Glick)]
        [TestCase(DwarfNames.Snick)]
        [TestCase(DwarfNames.Plick)]
        [TestCase(DwarfNames.Whick)]
        [TestCase(DwarfNames.Quee)]
        [TestCase(DwarfNames.Galadriela)]
        [TestCase(DwarfNames.Gimli)]
        public void ShoudReturnNameOF(DwarfNames dwarfName)
        {
            dwarfNameRandomizer.Setup(x => x.GiveMeDwarfName()).Returns(dwarfName.ToString());
            Assert.AreEqual(dwarfName.ToString(), dwarfNameRandomizer.Object.GiveMeDwarfName());
        }
    }
}