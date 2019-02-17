using System;
using System.Collections.Generic;

namespace Mine2._0
{
    public class Hospital
    {
        public int _createdDwarfs { get; private set; }
        public IDwarfTypeRandomizer _typeRandomizer;
        public ITryBirth _tryBirthRandomizer;

        public Hospital(IDwarfTypeRandomizer typeRandomizer, ITryBirth isBirthRandomizer)
        {
            _typeRandomizer = typeRandomizer;
            _tryBirthRandomizer = isBirthRandomizer;
        }

        public Hospital()
        {
            _typeRandomizer = new DwarfTypeRandomizer();
            _tryBirthRandomizer = new DwarthIsBrithRandomizer();
        }

        public List<Dwarf> CreateInitialState(int amount)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            Random rand = new Random();

            for (int i = 0; i < amount; i++)
            {
                dwarves.Add(DwarfFactory.CreateSingleDwarf(_typeRandomizer.GetRandomDwarfType()));
            }

            return dwarves;
        }

        public Dwarf CreateSingleRandomDwarf()
        {
            return DwarfFactory.CreateSingleDwarf(_typeRandomizer.GetRandomDwarfType());
        }
    }
}
