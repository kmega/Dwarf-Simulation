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
            Random rnd = new Random();
            //1 % chance birth
            int chanceToBirthDwarf = rnd.Next(1, 101);

            if (chanceToBirthDwarf == 1)
                hospital.CreateNewDwarf(DwarfsPopulation);

            return DwarfsPopulation;
        }

        private void  CreateNewDwarf(List<Dwarf> DwarfsPopulation)
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

        }
    }
}
