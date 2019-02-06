using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;

namespace MiningSimulatorByKPMM.PersonalItems
{
    public class Backpack
    {
        private List<Ore> ItemCollection = new List<Ore>();

        public void AddSingleOre(Ore mineral)
        {
            ItemCollection.Add(mineral);
        }

        public void RemoveSingleOre(Ore mineral)
        {
            ItemCollection.Remove(mineral);
        }

        public List<Ore> ShowBackpackContent()
        {
            return ItemCollection;
        }
    }
}
