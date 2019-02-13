using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Locations.Mine;
using DwarfLifeSimulation.Locations.Shop;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Dwarves
{
    class Dwarf : IDwarf
    {
        public string Name { get;private set; }
        private IWorkStrategy workStrategy;
        private IBuyStrategy buyStrategy;
        private Dictionary<MineralType,int> backPack;
        private int bankAccountId;

        public Product Buy(int shopAccountId)
        {
            return buyStrategy.Buy(bankAccountId, shopAccountId);
        }

        public void Work(Shaft shaft)
        {
            backPack = workStrategy.Perform(shaft);
        }

    }
}
