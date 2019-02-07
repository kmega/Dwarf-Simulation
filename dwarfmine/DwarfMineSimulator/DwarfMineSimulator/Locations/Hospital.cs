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
            int dailyRaportBornFather = 0, dailyRaportBornLazy = 0, dailyRaportBornSingle = 0, dailyRaportBornSuicider = 0;
            if (chanceToBorn)
            {
                DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
                //Sent information to raport daily and from 30 days
                calculating.NumberOfBirthsAndTypes(dwarfTypes);
                hospital.CreateNewDwarf(DwarfsPopulation, dwarfTypes);
                
                if (dwarfTypes == DwarfTypes.Father)
                {
                    dailyRaportBornFather++;
                }
                else if (dwarfTypes == DwarfTypes.Lazy)
                {
                    dailyRaportBornLazy++;
                }
                else if (dwarfTypes == DwarfTypes.Single)
                {
                    dailyRaportBornSingle++;
                }
                else if (dwarfTypes == DwarfTypes.Suicider)
                {
                    dailyRaportBornSuicider++;
                }
            }
            //DailyRaport
            information.ViewBirthInformation(dailyRaportBornFather, dailyRaportBornLazy,
                dailyRaportBornSingle, dailyRaportBornSuicider);
            return DwarfsPopulation;
        }

        public void CreateNewDwarf(List<Dwarf> DwarfsPopulation, DwarfTypes dwarfTypes)
        {
            DwarfsPopulation.Add(new Dwarf
            {
                Type = dwarfTypes
            });
        }
    }
}
