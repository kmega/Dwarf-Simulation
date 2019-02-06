using DwarfMineSimulator;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void T01DoesTheGuildSellWellGold()
        {
            decimal money = 0;
            Guild guild = new Guild();
            bool isGood = false;
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }               
            };

            DwarfsPopulation[0].MineralsMined[Minerals.Gold] = 1;

            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            money = DwarfsPopulation[0].Money;

            if (money >= 10 && money <= 20)
                isGood = true;
            Assert.IsTrue(isGood);
        }

        [Test]
        public void T02DoesTheGuildSellWellMithrill()
        {
            decimal money = 0;
            Guild guild = new Guild();
            bool isGood = false;
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };

            DwarfsPopulation[0].MineralsMined[Minerals.Mithril] = 1;

            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            money = DwarfsPopulation[0].Money;

            if (money >= 15 && money <= 25)
                isGood = true;
            Assert.IsTrue(isGood);
        }

        [Test]
        public void T03DoesTheGuildSellWellSilver()
        {
            decimal money = 0;
            Guild guild = new Guild();
            bool isGood = false;
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };

            DwarfsPopulation[0].MineralsMined[Minerals.Silver] = 1;

            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            money = DwarfsPopulation[0].Money;

            if (money >= 5 && money <= 15)
                isGood = true;
            Assert.IsTrue(isGood);
        }

        [Test]
        public void T04DoesTheGuildSellWellTainedGold()
        {
            decimal money = 0;
            Guild guild = new Guild();
            bool isGood = false;
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };

            DwarfsPopulation[0].MineralsMined[Minerals.TaintedGold] = 1;

            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            money = DwarfsPopulation[0].Money;

            if (money == 2)
                isGood = true;
            Assert.IsTrue(isGood);
        }

        [Test]
        public void T05DoesTheGuildSetMineralsto0()
        {
            Guild guild = new Guild();
            bool goldIs0 = false;
            bool mithrillIs0 = false;
            bool silverIs0 = false;
            bool tainedGoldIs0 = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };

            DwarfsPopulation[0].MineralsMined[Minerals.Gold] = 1;
            DwarfsPopulation[0].MineralsMined[Minerals.Mithril] = 1;
            DwarfsPopulation[0].MineralsMined[Minerals.Silver] = 1;
            DwarfsPopulation[0].MineralsMined[Minerals.TaintedGold] = 1;

            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            if (DwarfsPopulation[0].MineralsMined[Minerals.Gold] == 0)
                goldIs0 = true;
            if (DwarfsPopulation[0].MineralsMined[Minerals.Mithril] == 0)
                mithrillIs0 = true;
            if (DwarfsPopulation[0].MineralsMined[Minerals.Silver] == 0)
                silverIs0 = true;
            if (DwarfsPopulation[0].MineralsMined[Minerals.TaintedGold] == 0)
                tainedGoldIs0 = true;
            Assert.IsTrue(goldIs0);
            Assert.IsTrue(mithrillIs0);
            Assert.IsTrue(silverIs0);
            Assert.IsTrue(tainedGoldIs0);
        }
       
    }
}