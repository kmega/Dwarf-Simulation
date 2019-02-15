using DwarfLifeSimulation.Dwarves.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Graveyards
{
    public class Graveyard
    {
        private List<IDwarf> deadDwarves;
        
        public int DeadDwarvesAmount
        {
            get { return deadDwarves.Count; }
        }

        public Graveyard()
        {
            deadDwarves = new List<IDwarf>();
        }

        public void BuryDeadDwarves(List<IDwarf> dwarves)
        {

            for(int i = dwarves.Count-1; i>=0; i--)
            {
                if(dwarves[i]._isAlive == false)
                {
                    var dead = dwarves[i];
                    deadDwarves.Add(dead);
                    dwarves.Remove(dead);
                }
            }
        }
    }
}
