using System;
using System.Collections.Generic;
using Mine.Dwarfs;
using Mine.Locations.Interfaces;

namespace Mine.Locations
{
    public sealed class Hospital : IHospital
    {
        private static readonly Hospital _instance = new Hospital();
        private readonly double _sabotazystaBornProbability = 0.01;
        private readonly double _lenBornProbability = 0.1;
        private readonly double _ojciecBornProbablity = 0.5;
        public List<Dwarf> BornDwarfs { get; private set; }

        public static Hospital Instance
        {
            get
            {
                return _instance;
            }
        }
        public Hospital()
        {
            BornDwarfs = new List<Dwarf>();

            for (int i = 0; i < 9; i++)
            {
                BornDwarfs.Add(CreateDwarf());
            }

        }

        public Dwarf CreateDwarf()
        {
            Random rand = new Random();
            if (rand.NextDouble() < _sabotazystaBornProbability)
                return new Dwarf(DwarfType.Sabotazysta);
            if (rand.NextDouble() < _lenBornProbability)
                return new Dwarf(DwarfType.Len);
            if (rand.NextDouble() < _ojciecBornProbablity)
                return new Dwarf(DwarfType.Ojciec);

            return new Dwarf(DwarfType.Singel);
        }
    }
}
