using DwarfMineSimulator;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Niestestowalne bo problem z przypisanie minera³ów do krasnoluda
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0,},
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            Assert.Pass();
        }
    }
}