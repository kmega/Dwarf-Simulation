using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Shops;
using System.Collections.Generic;

namespace DwarfLifeSimulation.Dwarves
{
    public class Dwarf : IDwarf
    {
        public string _name { get; private set; }
        public IWorkStrategy _workStrategy { get; private set; }
        public IBuyStrategy _buyStrategy { get; private set; }
        public DwarfType _dwarfType { get; }
        private Dictionary<MineralType, int> _backPack;
        private int _bankAccountId;

        public Dwarf(string name, DwarfType dwarfType, IWorkStrategy howIWork, IBuyStrategy howIBuy)
        {
            _name = name;
            _dwarfType = dwarfType;
            _workStrategy = howIWork;
            _buyStrategy = howIBuy;
            _backPack = new Dictionary<MineralType, int>();
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


        public Dictionary<MineralType, int> EmptyBackpackContent()
        {
            var tempBackpack = _backPack;
            //AddEmptyingBackpack
            return tempBackpack;
        }

        public void GetMoney(decimal dailyIncome)
        {
            Bank.Instance.PayIntoAccount(_bankAccountId, dailyIncome);
        }
    }
}
