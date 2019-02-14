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
           // WorkingStrategy workingStrategy;
            IShoppingStrategy shoppingStrategy;
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < howManyDwarfYouWantCreate; i++)
            {
                DwarfType dwarfTypes = randomizer.GenerateDwarfType(
                    randomizer.ReturnRandomNumber(1,100));
                switch(dwarfTypes)
                {
                    case DwarfType.Single:
                        //shoppingStrategy = new SingleShoppingStrategy();
                        break;
                    case DwarfType.Lazy:
                        break;
                    case DwarfType.Father:
                        break;
                    case DwarfType.Bomber:
                        break;
                }
                dwarves.Add(new Dwarf
                {
                    dwarfType = dwarfTypes
                });
            }           
            return dwarves;
        }

        public void TryGiveBirthToDwarf(List<Dwarf> dwarves)
        {
            if (_day0)
            {
                CreateDwarves(10);
                _day0 = false;
            }
                

            bool chanceToBorn = randomizer.WillHeBeBorn(randomizer.ReturnRandomNumber(1, 100));
            if (chanceToBorn)
                dwarves.AddRange(CreateDwarves(1));
        }
    }
}
