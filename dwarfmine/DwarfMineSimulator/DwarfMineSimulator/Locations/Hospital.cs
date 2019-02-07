using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Hospital
    {
        public List<Dwarf> TryBirthDwarf(List<Dwarf> DwarfsPopulation)
        {
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            CalculatingDataForTheReport calculating = new CalculatingDataForTheReport();
            ViewInformation information = new ViewInformation();
            bool chanceToBorn = birthAndTypeDwarf.WillHeBeBorn();
           
            if (chanceToBorn)
            {
                DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
                calculating.NumberOfBirthsAndTypes(dwarfTypes);
                hospital.CreateNewDwarf(DwarfsPopulation, dwarfTypes);
            }
            information.ViewBirthInformation();
            return DwarfsPopulation;
        }

        public void CreateNewDwarf(List<Dwarf> DwarfsPopulation, DwarfTypes dwarfTypes)
        {
            DwarfsPopulation.Add(new Dwarf
            {
                Type = dwarfTypes,
                Alive = true,
                Money = 0,
                MoneyEarndedThisDay = 0
            });
        }
    }
}
