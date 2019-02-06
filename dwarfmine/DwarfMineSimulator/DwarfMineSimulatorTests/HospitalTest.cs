using DwarfMineSimulator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalTest
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

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            hospital.CreateNewDwarf(DwarfsPopulation, true);

            if (DwarfsPopulation.Count > 0)
                moreDwars = true;

            Assert.IsTrue(moreDwars);
        }

        [Test]
        public void T02CheckNewDwarfsAreLazyOrFatherOrSingle()
        {
            bool lazy = false;
            bool father = false;
            bool single = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            for (int i = 0; i < 20; i++)
                hospital.CreateNewDwarf(DwarfsPopulation, true);

            for (int i = 0; i < DwarfsPopulation.Count; i++)
            {
                if (DwarfsPopulation[i].Type == DwarfTypes.Lazy)
                    lazy = true;
                if (DwarfsPopulation[i].Type == DwarfTypes.Single)
                    single = true;
                if (DwarfsPopulation[i].Type == DwarfTypes.Father)
                    father = true;
            }

            Assert.IsTrue(lazy);
            Assert.IsTrue(single);
            Assert.IsTrue(father);
        }
    }
}
