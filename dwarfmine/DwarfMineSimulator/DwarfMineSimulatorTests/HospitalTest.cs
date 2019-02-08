using DwarfMineSimulator;
using NUnit.Framework;
using System.Collections.Generic;

namespace DwarfMineSimulatorTests
{
    class HospitalTest
    {
        [Test]
        public void T01PopulationIsGrowing()
        {
            bool moreDwarfs = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
            hospital.CreateNewDwarf(DwarfsPopulation, dwarfTypes, Raport.TotalBorn);

            if (DwarfsPopulation.Count > 0)
                moreDwarfs = true;

            Assert.IsTrue(moreDwarfs);
        }

        [Test]
        public void T02Chec33percentkNewDwarfsAreFather()
        {
            bool father = false;
            Randomizer randomizer = new Randomizer();
            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //1 - 33 Father,  34 - 66 Single, 67 - 99 Lazy, 100 Suicider
            for (int j = 1; j <= 33; j++)
            {
                hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(j), Raport.TotalBorn);
                if (DwarfsPopulation[j-1].Type == DwarfTypes.Father)
                    father = true;
                else
                    father = false;
                Assert.IsTrue(father);
            }
        }

        [Test]
        public void T03Chec33percentkNewDwarfsAreSingle()
        {
            bool single = false;
            Randomizer randomizer = new Randomizer();
            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //1 - 33 Father,  34 - 66 Single, 67 - 99 Lazy, 100 Suicider
            for (int j = 34; j <= 66; j++)
            {
                hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(j), Raport.TotalBorn);
                if (DwarfsPopulation[j - 34].Type == DwarfTypes.Single)
                    single = true;
                else
                    single = false;
                Assert.IsTrue(single);
            }
        }
        [Test]
        public void T04Chec33percentkNewDwarfsAreLazy()
        {
            bool lazy = false;
            Randomizer randomizer = new Randomizer();
            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //1 - 33 Father,  34 - 66 Single, 67 - 99 Lazy, 100 Suicider
            for (int j = 67; j <= 99; j++)
            {
                hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(j), Raport.TotalBorn);
                if (DwarfsPopulation[j - 67].Type == DwarfTypes.Lazy)
                    lazy = true;
                else
                    lazy = false;
                Assert.IsTrue(lazy);
            }
        }
        [Test]
        public void T05SuiciderApper()
        {
            Randomizer randomizer = new Randomizer();
            bool suicider = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            //100 Suicider
            hospital.CreateNewDwarf(DwarfsPopulation, randomizer.GenerateDwarfType(100), Raport.TotalBorn);

            if (DwarfsPopulation[0].Type == DwarfTypes.Suicider)
                suicider = true;

            Assert.IsTrue(suicider);
        }
        [Test]
        public void T06Create10DwarfWithOneMethodFromHospital()
        {
            bool moreDwarfs = false;

            List<Dwarf> DwarfsPopulation = new List<Dwarf>();
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
            hospital.HowManyYouWantCreate(10, DwarfsPopulation);

            if (DwarfsPopulation.Count == 10)
                moreDwarfs = true;

            Assert.IsTrue(moreDwarfs);
        }

    }
}
