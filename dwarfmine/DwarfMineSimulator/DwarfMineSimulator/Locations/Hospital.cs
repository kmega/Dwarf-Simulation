using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Hospital
    {
        Randomizer birthAndTypeDwarf = new Randomizer();
        public List<Dwarf> TryBirthDwarf(List<Dwarf> DwarfsPopulation)
        {
            CalculatingDataForTheReport calculating = new CalculatingDataForTheReport();
            ViewInformation information = new ViewInformation();
            bool chanceToBorn = birthAndTypeDwarf.WillHeBeBorn();
            int dailyRaportBornFather = 0, dailyRaportBornLazy = 0, dailyRaportBornSingle = 0, dailyRaportBornSuicider = 0;
            if (chanceToBorn)
            {
                DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
                //Sent information to raport daily and from 30 days
                calculating.NumberOfBirthsAndTypes(dwarfTypes);
                CreateNewDwarf(DwarfsPopulation, dwarfTypes, Raport.TotalBorn);
                
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

        public void HowManyYouWantCreate(int number, List<Dwarf> DwarfsPopulation)
        {
            for (int i = 0; i < number; i++)
            {
                DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
                CreateNewDwarf(DwarfsPopulation, dwarfTypes, i);
            }
        }
        public void CreateNewDwarf(List<Dwarf> DwarfsPopulation, DwarfTypes dwarfTypes, int index)
        {
            DwarfsPopulation.Add(new Dwarf
            {
                ID = index,
                Type = dwarfTypes
            });
        }
    }
}
