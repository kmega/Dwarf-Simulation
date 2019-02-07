using DwarfMineSimulator;
using NUnit.Framework;
using System.Collections.Generic;

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
            bool moreDwarfs = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
            hospital.CreateNewDwarf(DwarfsPopulation, dwarfTypes);

            if (DwarfsPopulation.Count > 0)
                moreDwarfs = true;

            Assert.IsTrue(moreDwarfs);
        }

        [Test]
        public void T02CheckNewDwarfsAreLazyOrFatherOrSingle()
        {
            bool lazy = false;
            bool father = false;
            bool single = false;
            Randomizer randomizer = new Randomizer();
            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //1 - 33 Father,  34 - 66 Single, 67 - 99 Lazy, 100 Suicider
            hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(22));
            hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(68));
            hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(35));


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
            Randomizer randomizer = new Randomizer();
            bool suicider = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //100 Suicider
            hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(100));

            if (DwarfsPopulation[0].Type == DwarfTypes.Suicider)
                suicider = true;

            Assert.IsTrue(suicider);
        }
    }
}
