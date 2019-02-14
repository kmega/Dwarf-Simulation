using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfSimulation
{
    internal class Graveyard
    {
        internal List<Dwarf> DeleteDeadDwarfFromList(List<Dwarf> DwarfsPopulation, Raport raport)
        {
            int TodayDead = DwarfsPopulation.Where(dwarf => dwarf.IsAlive == false).Count();
            raport.DeathCount += TodayDead;
            Display(TodayDead);
            return DwarfsPopulation.Where(dwarf => dwarf.IsAlive == true).ToList();
        }

        internal bool AnybodyLives(List<Dwarf> DwarfsPopulation)
        {
            return DwarfsPopulation.Any();
        }

        void Display(int TodayDead)
        {
            List<string> output = new List<string>();
            Outputer outputer = new Outputer();
            output.Add("");
            output.Add("### Graveyard ###");
            output.Add("Funeral " + TodayDead +  " Dwarfs");
            outputer.Display(output);
        }
    }
}
