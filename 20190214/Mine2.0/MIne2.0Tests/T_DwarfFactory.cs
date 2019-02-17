using Mine2._0;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_DwarfFactory
    {
        [Test]
        public void CreatesFatherDwarf()
        {
            //given
            var dwarf = DwarfFactory.CreateSingleDwarf(E_DwarfType.Father);
            //when

            //then
            Assert.IsTrue(dwarf._workStrategy is NormalWorkingStrategy);
            Assert.IsTrue(dwarf._buyStrategy is FoodBuyingStrategy);
        }

        [Test]
        public void CreatesSingleDwarf()
        {
            //given
            var dwarf = DwarfFactory.CreateSingleDwarf(E_DwarfType.Single);
            //when

            //then
            Assert.IsTrue(dwarf._workStrategy is NormalWorkingStrategy);
            Assert.IsTrue(dwarf._buyStrategy is AlcoholBuyingStrategy);
        }

        [Test]
        public void CreatesSabouterDwarf()
        {
            //given
            var dwarf = DwarfFactory.CreateSingleDwarf(E_DwarfType.Sabouter);
            //when

            //then
            Assert.IsTrue(dwarf._workStrategy is KaboomWorkingStrategy);
        }
    }
}
