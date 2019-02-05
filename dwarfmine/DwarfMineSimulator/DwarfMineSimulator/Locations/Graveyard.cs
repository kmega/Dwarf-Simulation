using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfMineSimulator
{
    class Graveyard
    {
         int DeadCounter = 0;

        internal List<Dwarf> DeleteDeadDwarfFromList(List<Dwarf> DwarfsPopulation)
        {
            DeadCounter += DwarfsPopulation.Where(dwarf => dwarf.Alive == false).Count();
            return DwarfsPopulation.Where(dwarf => dwarf.Alive == true).ToList();
        }

        internal int HowManyDead()
        {
            Display();
            return DeadCounter;
        }

        void Display()
        {
            Console.WriteLine("### Graveyard ###");
            Console.WriteLine("Funeral " + DeadCounter + " Dwarfs");
        }
    }
}
