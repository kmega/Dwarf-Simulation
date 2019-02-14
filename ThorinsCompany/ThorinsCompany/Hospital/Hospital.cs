using DwarfMineSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Hospital
    {
        Randomizer randomizer = new Randomizer();
        public List<Dwarf> CreateDwarves(int howManyDwarfYouWantCreate)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < howManyDwarfYouWantCreate; i++)
            {
                DwarfType dwarfTypes = randomizer.RandomTypeDwarf();
                dwarves.Add(new Dwarf
                {
                    dwarfType = dwarfTypes
                });
            }           
            return dwarves;
        }

        public void GiveBirthToDwarf(List<Dwarf> dwarves)
        {
            bool chanceToBorn = randomizer.WillHeBeBorn();
            if (chanceToBorn)
                dwarves.AddRange(CreateDwarves(1));
        }
    }
}
