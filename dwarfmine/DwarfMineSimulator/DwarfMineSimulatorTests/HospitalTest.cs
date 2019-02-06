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
            DwarfTypes dwarfTypes = hospital.RandomTypeDwarf();
            hospital.CreateNewDwarf(DwarfsPopulation, true, dwarfTypes);

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
            {
                DwarfTypes dwarfTypes = hospital.RandomTypeDwarf();
                hospital.CreateNewDwarf(DwarfsPopulation, true, dwarfTypes);
            }

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

        [Test]
        public void T03SuiciderApper()
        {
            bool suicider = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            hospital.CreateNewDwarf(DwarfsPopulation, true, DwarfTypes.Suicider);

            if (DwarfsPopulation[0].Type == DwarfTypes.Suicider)
                suicider = true;

            Assert.IsTrue(suicider);
        }
    }
}
