using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorinsCompany
{
    public class Mine
    {

        public List<Shaft> AllShafts = new List<Shaft>();
        public Foreman Foreman = new Foreman(); //it's supposed to be a kind of a parser.
        //It divides main list to smaller with that is of maximum count = 5;
        //it manages divided list of dwarves and sends them to each shaft;
        
        public Mine()
        {
            var AllShafts = Enumerable.Range(0, 2).Select(x => new Shaft()).ToList();
        }

        public void PerformMining(List<Dwarf> dwarves)
        {
            var dwarvesInShaft = Foreman.SendToShafts(dwarves);

            foreach (var shaft in AllShafts)
            {
                shaft.PerformAction();
            }
            foreach (var dwarf in dwarves)
            {
                dwarf.WorkingStrategy.StartWorking();
            }
        }



    }
}
