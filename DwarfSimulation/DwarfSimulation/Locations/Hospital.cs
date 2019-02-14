using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfSimulation
{
    internal class Hospital
    {
        internal List<Dwarf> BornDwarf(List<Dwarf> dwarves, bool chance)
        {
            if (chance)
            {
                Builder builder = new Builder();
               dwarves = dwarves.Concat(builder.CreateDwarves(1)).ToList();
                return dwarves;
            }
            return dwarves;
        }

        internal bool ChanceOfBirth()
        {
            Randomizer random = new Randomizer();
            int chance = random.ReturnFromTo(1, 100);
            return (chance == 1);
        }
    }
}
