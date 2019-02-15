using NUnit.Framework;
using DwarfSimulation;

namespace MinesTests
{
    class MinesRaportTests
    {
        [Test]
        public void RaportShouldRegisterMithrilMining()
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            Dwarf dwarf = builder.CreateDwarf(DwarfType.Father);

            // Given
            DefaultWorkStrategy strategy = new DefaultWorkStrategy();
            dwarf = strategy.MineOre(dwarf, 1, 1, raport);

            // Assert
            Assert.IsTrue(raport.MithrilMined == 1);
        }

        [Test]
        public void RaportShouldRegisterGoldMining()
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            Dwarf dwarf = builder.CreateDwarf(DwarfType.Father);

            // Given
            DefaultWorkStrategy strategy = new DefaultWorkStrategy();
            dwarf = strategy.MineOre(dwarf, 1, 15, raport);

            // Assert
            Assert.IsTrue(raport.GoldMined == 1);
        }

        [Test]
        public void RaportShouldRegisterSilverMining()
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            Dwarf dwarf = builder.CreateDwarf(DwarfType.Father);

            // Given
            DefaultWorkStrategy strategy = new DefaultWorkStrategy();
            dwarf = strategy.MineOre(dwarf, 1, 30, raport);

            // Assert
            Assert.IsTrue(raport.SilverMined == 1);
        }

        [Test]
        public void RaportShouldRegisterTaintedGolMining()
        {
            // For
            Builder builder = new Builder();
            Raport raport = new Raport();

            Dwarf dwarf = builder.CreateDwarf(DwarfType.Father);

            // Given
            DefaultWorkStrategy strategy = new DefaultWorkStrategy();
            dwarf = strategy.MineOre(dwarf, 1, 60, raport);

            // Assert
            Assert.IsTrue(raport.TaintedGoldMined == 1);
        }
    }
}
