using Dwarf_Town.Interfaces;
using System.Collections.Generic;

namespace Dwarf_Town.Locations.Mine
{
    public class Shaft
    {
        public bool EfficientShaft;
        private IOutputWriter Presenter;

        public Shaft(IOutputWriter presenter)
        {
            EfficientShaft = true;
            Presenter = presenter;
        }

        public void PerformWork(List<IWork> dwarvesWorkingInShaft)
        {
            List<string> message = new List<string>();
            foreach (var dwarf in dwarvesWorkingInShaft)

            {
                int HowManyTimesDwarfHit = dwarf.Dig();

                if (HowManyTimesDwarfHit == -1)
                {
                    Presenter.WriteLine("Shaft destroyed.");
                    //Suicide attack
                    EfficientShaft = false;

                    break;
                }
                else
                {
                    //Normal work
                    for (int i = 0; i < HowManyTimesDwarfHit; i++)
                    {
                        int chanceForOre = dwarf.GenerateChance(1, 101);
                        dwarf.HideToBackpack(GiveSpecificOre.GetTheOre(chanceForOre));
                        Presenter.WriteLine($"Dwarf brought out {GiveSpecificOre.GetTheOre(chanceForOre)}.");
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