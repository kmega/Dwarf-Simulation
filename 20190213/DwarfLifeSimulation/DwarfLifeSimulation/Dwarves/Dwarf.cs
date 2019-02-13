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
        public string _name { get;private set; }
        public IWorkStrategy _workStrategy { get; private set; }
        public IBuyStrategy _buyStrategy { get; private set; }
        private Dictionary<MaterialType,int> _backPack;
        private int _bankAccountId;

        public Dwarf(string name, IWorkStrategy howIWork, IBuyStrategy howIBuy)
        {
            _name = name;
            _workStrategy = howIWork;
            _buyStrategy = howIBuy;
            _backPack = new Dictionary<MaterialType, int>();
            _bankAccountId = Bank.Instance.CreateAccount();
        }

        public Product Buy(int shopAccountId)
        {            
            return _buyStrategy.Buy(_bankAccountId, shopAccountId);
        }

        public void Work(Shaft shaft)
        {
            _backPack = _workStrategy.Perform(shaft);
        }

    }
}
