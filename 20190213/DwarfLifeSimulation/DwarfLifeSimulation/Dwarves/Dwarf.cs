using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Shops;
using DwarfLifeSimulation.Locations.Banks;

using System.Collections.Generic;
using DwarfLifeSimulation.Loggers;

namespace DwarfLifeSimulation.Dwarves
{
    public class Dwarf : IDwarf
    {
        public string _name { get; private set; }
        public IWorkStrategy _workStrategy { get; private set; }
        public IBuyStrategy _buyStrategy { get; private set; }
        public DwarfType _dwarfType { get; }
        public bool _isAlive { get; set; }
        public bool _hasWorked { get; set; }
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
            _isAlive = true;
            _hasWorked = false;
        }

        public Product Buy(int shopAccountId)
        {
            return _buyStrategy.Buy(_bankAccountId, shopAccountId);
        }

        public void Work(Shaft shaft, ILog logger)
        {
            _backPack = _workStrategy.Perform(shaft, logger);
        }


        public Dictionary<MineralType, int> EmptyBackpackContent()
        {
            Dictionary<MineralType, int> tempBackpack = new Dictionary<MineralType, int>();            
            foreach(var key in _backPack.Keys)
            {
                tempBackpack.Add(key, _backPack[key]);
            }
            _backPack.Clear();
            return tempBackpack;
        }

        public void GetMoney(decimal dailyIncome)
        {
            Bank.Instance.PayIntoAccount(_bankAccountId, dailyIncome);
        }
    }
}
