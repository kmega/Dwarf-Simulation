﻿using System.Collections.Generic;

namespace DwarfMineSimulator
{
    class Hospital
    {
        Randomizer randomizer = new Randomizer();
        public List<Dwarf> TryBirthDwarf(List<Dwarf> DwarfsPopulation)
        {
            CalculatingDataForTheReport calculating = new CalculatingDataForTheReport();
            ViewInformation information = new ViewInformation();
            bool chanceToBorn = randomizer.WillHeBeBorn();
            int dailyRaportBornFather = 0, dailyRaportBornLazy = 0, dailyRaportBornSingle = 0, dailyRaportBornSuicider = 0;
            if (chanceToBorn)
            {
                DwarfTypes dwarfTypes = randomizer.RandomTypeDwarf();
                //Sent information to raport daily and from 30 days
                calculating.NumberOfBirthsAndTypes(dwarfTypes);
                CreateNewDwarf(DwarfsPopulation, dwarfTypes, Raport.TotalBorn + 9);
                
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
                DwarfTypes dwarfTypes = randomizer.RandomTypeDwarf();
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
