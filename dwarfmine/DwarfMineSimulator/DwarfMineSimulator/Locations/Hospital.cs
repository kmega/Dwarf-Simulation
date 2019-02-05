using System;
using System.Collections.Generic;
using System.Text;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator
{
    class Hospital
    {
        public List<Dwarf> TryBirthDwarf(List<Dwarf> DwarfsPopulation)
        {
            Hospital hospital = new Hospital();
            Random rnd = new Random();
            //1 % chance birth
            int chanceToBirthDwarf = rnd.Next(1, 101);

            if (chanceToBirthDwarf == 1)
            {
                hospital.CreateNewDawrf(DwarfsPopulation);
            }
            return DwarfsPopulation;
        }

        public List<Dwarf> CreateNewDawrf(List<Dwarf> DwarfsPopulation)
        {
            Random rnd = new Random();
            DwarfTypes dwarfTypes;
            //33 % chance to Father, Lazy, Single
            int chanceToFatherOrSingle = rnd.Next(1, 100);
            if (chanceToFatherOrSingle <= 33)
                dwarfTypes = DwarfTypes.Father;
            else if (chanceToFatherOrSingle > 33 && chanceToFatherOrSingle <= 66)
                dwarfTypes = DwarfTypes.Single;
            else
                dwarfTypes = DwarfTypes.Lazy;

            DwarfsPopulation.Add(new Dwarf {
                Type = dwarfTypes,
                Alive = true,
            Money = 0,
            MoneyEarndedThisDay = 0});

            return DwarfsPopulation;
        }
    }
}
