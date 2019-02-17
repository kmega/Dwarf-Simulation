using DwarfMineSimulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Hospital 
    {
        RandomizerThorins randomizer = new RandomizerThorins();
        bool _day0 = true;

        public List<Dwarf> CreateDwarves(int howManyDwarfYouWantCreate)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < howManyDwarfYouWantCreate; i++)
            {
                DwarfType dwarfType = randomizer.GenerateDwarfType(
                    randomizer.ReturnRandomNumber(1,100));
                Dwarf dwarf = DwarfFactory.CreateDwarf(dwarfType);
                dwarves.Add(dwarf);
            }           
            return dwarves;
        }

        public void TryGiveBirthToDwarf(List<Dwarf> dwarves)
        {
            if (_day0)
            {
                dwarves.AddRange(CreateDwarves(10));
                _day0 = false;
            }
                
            bool chanceToBorn = randomizer.WillHeBeBorn(randomizer.ReturnRandomNumber(1, 100));
            if (chanceToBorn)
                dwarves.AddRange(CreateDwarves(1));
        }
    }
}
