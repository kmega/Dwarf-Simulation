using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Dwarf_Town.Locations.Mine
{
    public class Shaft
    {
        public bool EfficientShaft;
        private List<IWork> _dwarvesWorkingInShaft;
       

        public Shaft()
        {
            EfficientShaft = true;
            _dwarvesWorkingInShaft = new List<IWork>();
        }



        public void SendDwarvesDown(List<IWork> dwarves)
        {
            _dwarvesWorkingInShaft = dwarves;
        }


        public void PerformWork()
        {
            foreach (var dwarf in _dwarvesWorkingInShaft)
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
                foreach (var dwarf in _dwarvesWorkingInShaft)
                {
                    dwarf.DeathSentence();
                }
            }

            _dwarvesWorkingInShaft.Clear();

        }
    }
}