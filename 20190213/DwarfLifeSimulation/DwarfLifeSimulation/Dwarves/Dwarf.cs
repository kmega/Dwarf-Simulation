using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Locations.Bank;
using DwarfLifeSimulation.Locations.Mine;
using DwarfLifeSimulation.Locations.Shop;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Dwarves
{
    public class Dwarf : IDwarf
    {
        public string Name { get;private set; }
<<<<<<< HEAD
        public IWorkStrategy workStrategy { get; private set; }
        public IBuyStrategy buyStrategy { get; private set; }
        private Dictionary<Material,int> backPack;
=======
        private IWorkStrategy workStrategy;
        private IBuyStrategy buyStrategy;
        private Dictionary<MaterialType,int> backPack;
>>>>>>> kozlovsky
        private int bankAccountId;

        public Dwarf(string name, IWorkStrategy howIWork, IBuyStrategy howIBuy)
        {
            Name = name;
            workStrategy = howIWork;
            buyStrategy = howIBuy;
            backPack = new Dictionary<Material, int>();
            bankAccountId = Bank.Instance.CreateAccount();
        }

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
