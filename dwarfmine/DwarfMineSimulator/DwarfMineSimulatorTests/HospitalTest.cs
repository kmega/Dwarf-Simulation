using DwarfMineSimulator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulatorTests
{
    class HospitalTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void T01PopulationIsGrowing()
        {
            bool moreDwars = false;
            //Poprawic bo random i mogą byc testy czerwone
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0,},
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            Hospital hospital = new Hospital();
            for (int i = 0; i < 1000; i++)
                hospital.TryBirthDwarf(DwarfsPopulation);

            if (DwarfsPopulation.Count > 4)
                moreDwars = true;

            Assert.IsTrue(moreDwars);
        }

        [Test]
        public void T02CheckNewDwarfsAreLazyFatherSingle()
        {
            bool moreDwars = false;
            //Poprawic bo random i mogą byc testy czerwone
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
            };
            Hospital hospital = new Hospital();
            for (int i = 0; i < 1000; i++)
                hospital.TryBirthDwarf(DwarfsPopulation);

            if (DwarfsPopulation.Count > 4)
                moreDwars = true;

            Assert.IsTrue(moreDwars);
        }
    }
}
