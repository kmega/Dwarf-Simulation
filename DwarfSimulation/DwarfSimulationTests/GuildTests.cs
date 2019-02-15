using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;
using Moq;


namespace GuildTests
{
    public class GuildTests
    {
        Randomizer randomizer = new Randomizer();

        [Test]
        public void ShouldClearDwarfBackpack()
        {
            // GIVEN
            Dwarf dwarf = new Dwarf()
            {
                BackPack =
              {
                  [Mineral.Gold] = 5,
                  [Mineral.Silver] = 5,
                  [Mineral.Mithril] = 5,
                  [Mineral.TaintedGold] = 5,
              }
            };

            Guild guild = new Guild(randomizer);

            // WHEN
            guild.ClearBackpack(dwarf);

            // THEN
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Gold]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Silver]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, dwarf.BackPack[Mineral.Mithril]);
        }

        [Test]
        public void ShouldClearDwarvesBackpacks()
        {
            // GIVEN
            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BackPack = {[Mineral.Gold] = 5, [Mineral.Mithril]=5,[Mineral.Silver]=5,[Mineral.TaintedGold]=5}},
                new Dwarf() {BackPack = {[Mineral.Gold] = 3, [Mineral.Mithril]=3,[Mineral.Silver]=3,[Mineral.TaintedGold]=3}},
            };

            Guild guild = new Guild(randomizer);

            // WHEN
            guild.ClearBackpacks(listOfDwarves);

            // THEN
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Gold]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Silver]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, listOfDwarves[0].BackPack[Mineral.Mithril]);

            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Gold]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Silver]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.TaintedGold]);
            Assert.AreEqual(0, listOfDwarves[1].BackPack[Mineral.Mithril]);
        }

        [Test]
        public void CalculateDwarvesBackpacksMineralsToMoney()
        {
            // GIVEN
            Mock<IMineralsPrices> calculatePrices = new Mock<IMineralsPrices>();
            calculatePrices.Setup(g => g.ReturnMineralPrice(Mineral.Gold)).Returns(20);
            calculatePrices.Setup(s => s.ReturnMineralPrice(Mineral.Silver)).Returns(15);
            calculatePrices.Setup(tg => tg.ReturnMineralPrice(Mineral.TaintedGold)).Returns(2);
            calculatePrices.Setup(m => m.ReturnMineralPrice(Mineral.Mithril)).Returns(25);



            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BackPack = {[Mineral.Gold] = 1, [Mineral.Mithril]=1,[Mineral.Silver]=1,[Mineral.TaintedGold]=1}},
                new Dwarf() {BackPack = {[Mineral.Gold] = 10, [Mineral.Silver] = 10} },
            };

            Guild guild = new Guild(calculatePrices.Object);

            // WHEN
            guild.ExchangeDwarvesMineralsAndGiveThemMoney(listOfDwarves);

            // THEN
            Assert.AreEqual(46.5M , listOfDwarves[0].Wallet);
            Assert.AreEqual(262.5M, listOfDwarves[1].Wallet);
        }

        [Test]
        public void ShouldUpdateTaxedMoneyInGuild()
        {
            // Given
            Mock<IMineralsPrices> calculatePrices = new Mock<IMineralsPrices>();
            calculatePrices.Setup(g => g.ReturnMineralPrice(Mineral.Gold)).Returns(20);
            calculatePrices.Setup(s => s.ReturnMineralPrice(Mineral.Silver)).Returns(15);
            calculatePrices.Setup(tg => tg.ReturnMineralPrice(Mineral.TaintedGold)).Returns(2);
            calculatePrices.Setup(m => m.ReturnMineralPrice(Mineral.Mithril)).Returns(25);

            List<Dwarf> listOfDwarves = new List<Dwarf>()
            {
                new Dwarf() {BackPack = {[Mineral.Gold] = 1, [Mineral.Mithril]=1,[Mineral.Silver]=1,[Mineral.TaintedGold]=1}},
                new Dwarf() {BackPack = {[Mineral.Gold] = 10, [Mineral.Silver] = 10} },
            };

            Guild guild = new Guild(calculatePrices.Object);

            // WHEN
            guild.ExchangeDwarvesMineralsAndGiveThemMoney(listOfDwarves);

            // THEN
            decimal taxedMoney = guild.TotalTaxedMoneyValue();
            Assert.AreEqual(103M, taxedMoney);

        }
    }
}
