using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_Hospital
    {
        [Test]
        public void CreatesInitialState()
        {
            //given
            Mock<IDwarfTypeRandomizer> mockDwarfTypeR = new Mock<IDwarfTypeRandomizer>();
            mockDwarfTypeR.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);

            //when
            var hospital = new Hospital(mockDwarfTypeR.Object, new DwarthIsBrithRandomizer());
            var dwarfList = hospital.CreateInitialState(10);

            //then
            Assert.IsTrue(dwarfList.All(x => x._dwarfType == E_DwarfType.Father));
            Assert.IsTrue(dwarfList.All(x => x._workStrategy is NormalWorkingStrategy));
        }

        [Test]
        public void CreatesRandomDwarf()
        {
            //given
            Mock<IDwarfTypeRandomizer> mockDwarfTypeR = new Mock<IDwarfTypeRandomizer>();
            mockDwarfTypeR.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);

            //when
            var hospital = new Hospital(mockDwarfTypeR.Object, new DwarthIsBrithRandomizer());
            var dwarf = hospital.CreateSingleRandomDwarf();

            //then
            Assert.IsTrue(dwarf._dwarfType == E_DwarfType.Father);
            Assert.IsTrue(dwarf._workStrategy is NormalWorkingStrategy);
            Assert.IsTrue(dwarf._backpack.Count == 0);
            Assert.IsTrue(dwarf._isAlive == true);
            Assert.IsTrue(dwarf._buyStrategy is FoodBuyingStrategy);


        }
    }
}
