using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Dwarf_Town.Locations.Mine
{
    public class Shaft
    {
        public bool EfficientShaft;
       

        public Shaft()
        {
            EfficientShaft = true;
        }

        public void PerformWork(List<IWork> dwarvesWorkingInShaft)
        {
            foreach (var dwarf in dwarvesWorkingInShaft)
            {
                int HowManyTimesDwarfHit = dwarf.Dig();

                if (HowManyTimesDwarfHit == -1)
                {
                    //Suicide attack
                    EfficientShaft = false;
                    break;
                }
                else
                {
                    //Normal work
                    for (int i = 0; i < HowManyTimesDwarfHit; i++)
                    {
                        int chanceForOre = dwarf.GenerateChance(1, 100);
                        dwarf.HideToBackpack(GiveSpecificOre.GetTheOre(chanceForOre));
                    }
                }
            }

            if (EfficientShaft == false)
            {
                foreach (var dwarf in dwarvesWorkingInShaft)
                {
                    dwarf.DeathSentence();
                }
            }

        }
    }
}